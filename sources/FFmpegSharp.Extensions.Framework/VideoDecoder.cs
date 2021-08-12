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
using System.Threading;
using static FFmpegSharp.Interop.FFmpeg;
using static FFmpegSharp.Interop.Std;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class VideoDecoder
    {
        private const int MaxQueueSize = 3;

        private readonly Channel<AVPacket> _videoInput;

        private readonly Channel<AVFrame> _videoOutput;

        private readonly AVCodecContext _codecContext;

        private readonly AVCodec _codec;

        private readonly Thread _thread;

        private readonly CancellationTokenSource _cancellationTokenSource;

        public Channel<AVFrame> VideoOutput => _videoOutput;

        public VideoDecoder(Channel<AVPacket> videoInput)
        : this(videoInput, VideoDecoderOptions.Default)
        { }

        public VideoDecoder(Channel<AVPacket> videoInput, VideoDecoderOptions options)
        {
            _videoInput = videoInput ?? throw new ArgumentNullException(nameof(videoInput));

            _videoOutput = new Channel<AVFrame>(MaxQueueSize);
            _videoOutput.MetaData.TimeBase = _videoInput.MetaData.TimeBase;
            _videoOutput.MetaData.FrameRate = _videoInput.MetaData.FrameRate;

            _codec = AVCodec.FindDecoder((AVCodecID)_videoInput.MetaData.CodecID) ?? throw new InvalidOperationException();
            _codecContext = new AVCodecContext(_videoInput.MetaData.CodecParameters);
            _codecContext.PacketTimeBase = _videoInput.MetaData.TimeBase;
            _codecContext.Flags2 |= options.Fast ? AVCodecFlags2.Fast : AVCodecFlags2.None;
            _codecContext.Open(_codec, new AVDictionary
            {
                { "threads", "auto" },
                { "refcounted_frames", "1" }
            });

            _thread = new Thread(Decode);
            _thread.Name = "Video Decoder Thread";
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            _thread.Start();
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            _thread.Join();
        }

        private void Decode()
        {
            try
            {
                AVPacket? packet = null;

                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    while (!_cancellationTokenSource.IsCancellationRequested)
                    {
                        if (packet != null || _videoInput.Reader.TryRead(out packet, Timeout.Infinite, _cancellationTokenSource.Token))
                        {
                            var retval = _codecContext.Send(packet);
                            if (retval == AVERROR_EOF)
                            {
                                return;
                            }

                            if (retval == AVERROR(EAGAIN))
                            {
                                break;
                            }

                            if (retval == 0)
                            {
                                packet.Unref();
                                _videoInput.Reader.Return(packet);
                                packet = null;
                                break;
                            }
                        }
                        else
                        {
                            if (_videoInput.Reader.IsCompleted)
                            {
                                _codecContext.Send(AVPacket.Null);
                                break;
                            }
                        }
                    }

                    while (!_cancellationTokenSource.IsCancellationRequested)
                    {
                        var frame = _videoOutput.Writer.Get();
                        var retval = _codecContext.Receive(frame);
                        if (retval == AVERROR_EOF)
                        {
                            _codecContext.FlushBuffers();
                            _videoOutput.Writer.Complete();
                            return;
                        }

                        if (retval == AVERROR(EAGAIN))
                        {
                            break;
                        }

                        if (retval == 0)
                        {
                            _videoOutput.Writer.Write(frame, _cancellationTokenSource.Token);
                            break;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    }
}
