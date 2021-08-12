// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with FFmpegSharp.  If not, see <https://www.gnu.org/licenses/>.

using System;
using Microsoft.Toolkit.HighPerformance;
using SDL2Sharp;
using SDL2Sharp.Interop;
using static SDL2Sharp.Interop.SDL;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class VideoRenderer : IPresentationClockSource
    {
        private readonly PresentationClock _presentationClock;

        private readonly IExternalClock _externalClock;

        private readonly Clock _internalClock;

        private SwsContext _videoSwsContext;

        private Texture _videoTexture;

        private SwsContext _subtitleSwsContext;

        private Texture _subtitleTexture;

        private AVFrame? _lastVideoFrame;

        private AVFrame? _nextVideoFrame;

        private AVSubtitle? _lastSubtitle;

        private AVSubtitle? _nextSubtitle;

        public IClock Clock => _internalClock;

        public Channel<AVFrame> VideoInput { get; set; } = null!;

        public Channel<AVSubtitle> SubtitleInput { get; set; } = null!;

        public VideoRenderer(PresentationClock presentationClock, IExternalClock externalClock)
        {
            _presentationClock = presentationClock ?? throw new ArgumentNullException(nameof(presentationClock));
            _externalClock = externalClock ?? throw new ArgumentNullException(nameof(externalClock));
            _internalClock = new Clock();
            _videoSwsContext = null!;
            _videoTexture = null!;
            _subtitleSwsContext = null!;
            _subtitleTexture = null!;
            _lastVideoFrame = null;
            _nextVideoFrame = null;
            _lastSubtitle = null;
            _nextSubtitle = null;
        }

        public void DrawVideo(Renderer renderer)
        {
            DrawVideo(renderer, false);
        }

        public void DrawVideo(Renderer renderer, bool forceRefresh)
        {
            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            UpdateVideoFrame();
            DrawVideoFrame(renderer);
            UpdateSubtitles();
            DrawSubtitles(renderer);
        }

        private void UpdateVideoFrame()
        {
            var videoInput = VideoInput;
            if (videoInput == null)
            {
                return;
            }

            var timeSource = _presentationClock.TimeSource;
            if (timeSource == null)
            {
                return;
            }

            var presentationTime = _presentationClock.Time;
            var timeBase = (AVTimeBase)videoInput.MetaData.TimeBase;
            var frameRate = (AVFrameRate)videoInput.MetaData.FrameRate;
            var duration = (AVRelativeTime)frameRate;

            if (_lastVideoFrame != null)
            {
                var lastPresentationTime = AVTimeStamp.IsUndefined(_lastVideoFrame.Pts) ? AVRelativeTime.Undefined : _lastVideoFrame.Pts * timeBase;
                if (lastPresentationTime <= presentationTime && presentationTime < lastPresentationTime + duration)
                {
                    return;
                }
            }

            while (true)
            {
                if (_nextVideoFrame == null && !videoInput.Reader.TryRead(out _nextVideoFrame))
                {
                    break;
                }

                var nextPresentationTime = AVTimeStamp.IsUndefined(_nextVideoFrame.Pts) ? AVRelativeTime.Undefined : _nextVideoFrame.Pts * timeBase;
                if (nextPresentationTime > presentationTime)
                {
                    break;
                }

                if (nextPresentationTime + duration < presentationTime)
                {
                    videoInput.Reader.Return(_nextVideoFrame);
                    _nextVideoFrame = null;
                    continue;
                }

                if (nextPresentationTime <= presentationTime)
                {
                    if (!AVRelativeTime.IsUndefined(nextPresentationTime))
                    {
                        _internalClock.SetTime(nextPresentationTime);
                        _externalClock.SyncTo(_internalClock);
                    }

                    if (_lastVideoFrame != null)
                    {
                        videoInput.Reader.Return(_lastVideoFrame);
                    }

                    _lastVideoFrame = _nextVideoFrame;
                    _nextVideoFrame = null;
                    break;
                }
            }
        }

        private void DrawVideoFrame(Renderer renderer)
        {
            if (_lastVideoFrame == null)
            {
                return;
            }

            var textureFormat = GetTextureFormat(_lastVideoFrame.PixelFormat);
            switch (textureFormat)
            {
                case PixelFormatEnum.Unknown:
                    DrawGenericImage(renderer, _lastVideoFrame);
                    break;

                case PixelFormatEnum.IYUV:
                    DrawYuvImage(renderer, _lastVideoFrame);
                    break;

                default:
                    DrawRawImage(renderer, textureFormat, _lastVideoFrame);
                    break;
            }
        }

        private unsafe void DrawGenericImage(Renderer renderer, AVFrame videoFrame)
        {
            _videoTexture = renderer.CreateOrReuseTexture(_videoTexture,
                TextureAccess.Streaming,
                PixelFormatEnum.ARGB8888,
                videoFrame.Width,
                videoFrame.Height,
                BlendMode.None);

            _videoSwsContext = SwsContext.GetCachedContext(_videoSwsContext,
                videoFrame.Width, videoFrame.Height, videoFrame.PixelFormat,
                videoFrame.Width, videoFrame.Height, AVPixelFormat.BGRA,
                SwsFlags.Bicubic);

            var pixels = stackalloc byte*[4];
            var pitch = stackalloc int[4];
            if (LockTexture(_videoTexture, null, (void**)pixels, pitch) == 0)
            {
                sws_scale(
                    _videoSwsContext,
                    videoFrame.Handle->extended_data,
                    videoFrame.Handle->linesize,
                    0,
                    videoFrame.Handle->height,
                    pixels,
                    pitch);

                UnlockTexture(_videoTexture);
            }

            renderer.Copy(_videoTexture);
        }

        private unsafe void DrawYuvImage(Renderer renderer, AVFrame videoFrame)
        {
            _videoTexture = renderer.CreateOrReuseTexture(_videoTexture, TextureAccess.Streaming, PixelFormatEnum.IYUV, videoFrame.Width, videoFrame.Height, BlendMode.None);

            if (videoFrame.Handle->linesize[0] > 0 && videoFrame.Handle->linesize[1] > 0 && videoFrame.Handle->linesize[2] > 0)
            {
                UpdateYUVTexture(_videoTexture, null,
                    videoFrame.Handle->data[0], videoFrame.Handle->linesize[0],
                    videoFrame.Handle->data[1], videoFrame.Handle->linesize[1],
                    videoFrame.Handle->data[2], videoFrame.Handle->linesize[2]);
            }
            else if (videoFrame.Handle->linesize[0] < 0 && videoFrame.Handle->linesize[1] < 0 && videoFrame.Handle->linesize[2] < 0)
            {
                UpdateYUVTexture(_videoTexture, null,
                    videoFrame.Handle->data[0] + videoFrame.Handle->linesize[0] * (videoFrame.Handle->height - 1), -videoFrame.Handle->linesize[0],
                    videoFrame.Handle->data[1] + videoFrame.Handle->linesize[1] * (AV_CEIL_RSHIFT(videoFrame.Handle->height, 1) - 1), -videoFrame.Handle->linesize[1],
                    videoFrame.Handle->data[2] + videoFrame.Handle->linesize[2] * (AV_CEIL_RSHIFT(videoFrame.Handle->height, 1) - 1), -videoFrame.Handle->linesize[2]);
            }
            else
            {
                //av_log(NULL, AV_LOG_ERROR, "Mixed negative and positive linesizes are not supported.\n");
                //return -1;
            }

            SetYUVConversionMode(videoFrame);
            renderer.Copy(_videoTexture);
            SetYUVConversionMode(null);
        }

        private unsafe void DrawRawImage(Renderer renderer, PixelFormatEnum pixelFormat, AVFrame videoFrame)
        {
            _videoTexture = renderer.CreateOrReuseTexture(_videoTexture,
                TextureAccess.Streaming,
                pixelFormat,
                videoFrame.Width,
                videoFrame.Height,
                BlendMode.None);

            var pixels = new Span2D<byte>(
                videoFrame.Handle->data[0],
                videoFrame.Width,
                videoFrame.Height,
                videoFrame.Handle->linesize[0]);
            _videoTexture.Update(pixels);

            renderer.Copy(_videoTexture);
        }

        private void UpdateSubtitles()
        {
            var subtitleInput = SubtitleInput;
            if (subtitleInput == null)
            {
                return;
            }

            var timeSource = _presentationClock.TimeSource;
            if (timeSource == null)
            {
                return;
            }

            var presentationTime = _presentationClock.Time;

            if (_lastSubtitle != null)
            {
                var lastPresentationTime = AVTimeStamp.IsUndefined(_lastSubtitle.Pts) ? AVRelativeTime.Undefined : _lastSubtitle.Pts * AVTimeBase.Internal;
                var lastStartDisplayTime = lastPresentationTime + _lastSubtitle.StartDisplayTime;
                var lastEndDisplayTime = lastPresentationTime + _lastSubtitle.EndDisplayTime;
                if (lastStartDisplayTime <= presentationTime && presentationTime < lastEndDisplayTime)
                {
                    return;
                }
            }

            while (true)
            {
                if (_nextSubtitle == null && !subtitleInput.Reader.TryRead(out _nextSubtitle))
                {
                    break;
                }

                var nextPresentationTime = AVTimeStamp.IsUndefined(_nextSubtitle.Pts) ? AVRelativeTime.Undefined : _nextSubtitle.Pts * AVTimeBase.Internal;
                var nextStartDisplayTime = nextPresentationTime + _nextSubtitle.StartDisplayTime;
                var nextEndDisplayTime = nextPresentationTime + _nextSubtitle.EndDisplayTime;
                if (nextStartDisplayTime > presentationTime)
                {
                    break;
                }

                if (nextEndDisplayTime < presentationTime)
                {
                    subtitleInput.Reader.Return(_nextSubtitle);
                    _nextVideoFrame = null;
                    continue;
                }

                if (nextStartDisplayTime <= presentationTime)
                {
                    if (_lastSubtitle != null)
                    {
                        subtitleInput.Reader.Return(_lastSubtitle);
                    }

                    _lastSubtitle = _nextSubtitle;
                    _nextSubtitle = null;
                    break;
                }
            }
        }

        private unsafe void DrawSubtitles(Renderer renderer)
        {
            var subtitleInput = SubtitleInput;
            if (subtitleInput == null)
            {
                return;
            }

            if (_lastSubtitle == null)
            {
                return;
            }

            var subtitlePixels = stackalloc byte*[4];
            var subtitlePitch = stackalloc int[4];
            var subtitleWidth = (int)subtitleInput.MetaData.Width;
            var subtitleHeight = (int)subtitleInput.MetaData.Height;

            _subtitleTexture = renderer.CreateOrReuseTexture(_subtitleTexture,
                TextureAccess.Streaming,
                PixelFormatEnum.ARGB8888,
                subtitleWidth,
                subtitleHeight,
                BlendMode.Blend);

            _subtitleTexture.Clear();

            foreach (var rectangle in _lastSubtitle.Rectangles)
            {
                rectangle.X = Math.Clamp(rectangle.X, 0, subtitleWidth);
                rectangle.Y = Math.Clamp(rectangle.Y, 0, subtitleHeight);
                rectangle.Width = Math.Clamp(rectangle.Width, 0, subtitleWidth - rectangle.X);
                rectangle.Height = Math.Clamp(rectangle.Height, 0, subtitleHeight - rectangle.Y);

                _subtitleSwsContext = SwsContext.GetCachedContext(_subtitleSwsContext,
                    rectangle.Width, rectangle.Height, AVPixelFormat.PAL8,
                    rectangle.Width, rectangle.Height, AVPixelFormat.BGRA,
                    SwsFlags.None);

                if (_subtitleSwsContext == null)
                {
                    //av_log(NULL, AV_LOG_FATAL, "Cannot initialize the conversion context\n");
                    return;
                }

                var rect = new SDL_Rect { x = rectangle.X, y = rectangle.Y, w = rectangle.Width, h = rectangle.Height };
                if (LockTexture(_subtitleTexture, &rect, (void**)subtitlePixels, subtitlePitch) == 0)
                {
                    fixed (byte** data = &rectangle.Handle->data[0])
                    {
                        sws_scale(
                            _subtitleSwsContext,
                            data,
                            rectangle.Handle->linesize,
                            0,
                            rectangle.Height,
                            subtitlePixels,
                            subtitlePitch);
                    }

                    UnlockTexture(_subtitleTexture);
                }
            }

            if (_subtitleTexture != null)
            {
                renderer.Copy(_subtitleTexture);
            }
        }

        private static void SetYUVConversionMode(AVFrame? frame)
        {
            var mode = SDL_YUV_CONVERSION_MODE.SDL_YUV_CONVERSION_AUTOMATIC;

            if (frame != null)
            {
                var format = frame.PixelFormat;
                if (format == AVPixelFormat.YUV420P || format == AVPixelFormat.YUYV422 || format == AVPixelFormat.UYVY422)
                {
                    if (frame.ColorRange == AVColorRange.Jpeg)
                    {
                        mode = SDL_YUV_CONVERSION_MODE.SDL_YUV_CONVERSION_JPEG;
                    }
                    else if (frame.ColorSpace == AVColorSpace.Bt709)
                    {
                        mode = SDL_YUV_CONVERSION_MODE.SDL_YUV_CONVERSION_BT709;
                    }
                    else if (frame.ColorSpace == AVColorSpace.Bt470Bg || frame.ColorSpace == AVColorSpace.Smpte170M || frame.ColorSpace == AVColorSpace.Smpte240M)
                    {
                        mode = SDL_YUV_CONVERSION_MODE.SDL_YUV_CONVERSION_BT601;
                    }
                }
            }

            SDL.SetYUVConversionMode(mode);
        }

        private static PixelFormatEnum GetTextureFormat(AVPixelFormat pixelFormat)
        {
            switch (pixelFormat)
            {
                case AVPixelFormat.RGB8: return PixelFormatEnum.RGB332;
                case AVPixelFormat.RGB444LE: return PixelFormatEnum.RGB444;
                case AVPixelFormat.RGB555LE: return PixelFormatEnum.RGB555;
                case AVPixelFormat.BGR555LE: return PixelFormatEnum.BGR555;
                case AVPixelFormat.RGB565LE: return PixelFormatEnum.RGB565;
                case AVPixelFormat.BGR565LE: return PixelFormatEnum.BGR565;
                case AVPixelFormat.RGB24: return PixelFormatEnum.RGB24;
                case AVPixelFormat.BGR24: return PixelFormatEnum.BGR24;
                case AVPixelFormat.RGB0: return PixelFormatEnum.RGB888;
                case AVPixelFormat.XBGR: return PixelFormatEnum.BGR888;
                case AVPixelFormat.ARGB: return PixelFormatEnum.ARGB8888;
                case AVPixelFormat.RGBA: return PixelFormatEnum.RGBA8888;
                case AVPixelFormat.ABGR: return PixelFormatEnum.ABGR8888;
                case AVPixelFormat.BGRA: return PixelFormatEnum.BGRA8888;
                case AVPixelFormat.YUV420P: return PixelFormatEnum.IYUV;
                case AVPixelFormat.YUYV422: return PixelFormatEnum.YUY2;
                case AVPixelFormat.UYVY422: return PixelFormatEnum.UYVY;
                case AVPixelFormat.None: return PixelFormatEnum.Unknown;
                default: return PixelFormatEnum.Unknown;
            }
        }
    }
}
