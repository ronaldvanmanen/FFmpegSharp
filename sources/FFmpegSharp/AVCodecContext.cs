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
using FFmpegSharp.Internals;
using static FFmpegSharp.Interop.FFmpeg;
using static FFmpegSharp.Interop.Std;

namespace FFmpegSharp
{
    public sealed unsafe class AVCodecContext : IDisposable
    {
        private readonly Interop.AVCodecContext* _handle;

        private readonly bool _ownsHandle;

        public AVMediaType CodecType => (AVMediaType)_handle->codec_type;

        public AVCodec Codec => new AVCodec(_handle->codec);

        public AVCodecID CodecID => (AVCodecID)_handle->codec_id;

        public long BitRate => _handle->bit_rate;

        public int BitRateTolerance => _handle->bit_rate_tolerance;

        public int GlobalQuality => _handle->global_quality;

        public int CompressionLevel => _handle->compression_level;

        public AVCodecFlags Flags
        {
            get => (AVCodecFlags)_handle->flags;

            set => _handle->flags = (int)value;
        }

        public AVCodecFlags2 Flags2
        {
            get => (AVCodecFlags2)_handle->flags2;

            set => _handle->flags2 = (int)value;
        }

        public AVTimeBase TimeBase
        {
            get => new AVTimeBase(_handle->time_base);

            set => _handle->time_base = (AVRational)value;
        }

        public int Width => _handle->width;

        public int Height => _handle->height;

        public int SampleRate => _handle->sample_rate;

        public int ChannelCount => _handle->channels;

        public AVSampleFormat SampleFormat => (AVSampleFormat)_handle->sample_fmt;

        public AVChannelLayout ChannelLayout => (AVChannelLayout)_handle->channel_layout;

        public AVTimeBase PacketTimeBase
        {
            get => new AVTimeBase(_handle->pkt_timebase);

            set => _handle->pkt_timebase = (AVRational)value;
        }

        public AVFrameRate FrameRate
        {
            get => new AVFrameRate(_handle->framerate);

            set => _handle->framerate = (AVRational)value;
        }

        public AVCodecContext()
        : this(avcodec_alloc_context3(null), true)
        { }

        public AVCodecContext(AVCodec codec)
        : this(avcodec_alloc_context3(codec), true)
        { }

        public AVCodecContext(AVCodecParameters codecParameters)
        : this(avcodec_alloc_context3(null), true)
        {
            avcodec_parameters_to_context(_handle, codecParameters);
        }

        public AVCodecContext(Interop.AVCodecContext* handle, bool ownsHandle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
            _ownsHandle = ownsHandle;
        }

        ~AVCodecContext()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool _)
        {
            if (_ownsHandle && _handle != null)
            {
                fixed (Interop.AVCodecContext** handle = &_handle)
                {
                    avcodec_free_context(handle);
                }
            }
        }

        public void Open(AVCodec codec)
        {
            Open(codec, null, out _);
        }

        public void Open(AVCodec codec, AVDictionary? options)
        {
            Open(codec, options, out _);
        }

        public void Open(AVCodec codec, AVDictionary? options, out AVDictionary? unknownOptions)
        {
            if (codec is null)
            {
                throw new ArgumentNullException(nameof(codec));
            }

            // Note: We need to create a copy of the options dictionary because
            // avcodec_open2 frees the AVDictionary passed to it before returning
            // causing the AVDictionary wrapper to throw an exception on dispose
            // or finalize.
            Interop.AVDictionary* optionsHandle = null;

            if (options != null)
            {
                AVError.ThrowOnFailure(
                    av_dict_copy(&optionsHandle, options.Handle, 0)
                );
            }

            AVError.ThrowOnFailure(
                avcodec_open2(_handle, codec, &optionsHandle)
            );

            if (optionsHandle != null)
            {
                unknownOptions = new AVDictionary(optionsHandle);
            }
            else
            {
                unknownOptions = null;
            }
        }

        public void Close()
        {
            AVError.ThrowOnFailure(
                avcodec_close(_handle)
            );
        }

        public int DecodeSubtitle2(AVPacket packet, AVSubtitle subtitle, out bool subtitleDecoded)
        {
            fixed (Interop.AVSubtitle* subtitleHandle = &subtitle.Handle)
            {
                var gotSubtitle = 0;
                var retval = avcodec_decode_subtitle2(_handle, subtitleHandle, &gotSubtitle, packet);
                subtitleDecoded = gotSubtitle != 0;
                return retval;
            }
        }

        public void FlushBuffers()
        {
            avcodec_flush_buffers(_handle);
        }

        public int Send(AVPacket packet)
        {
            if (packet is null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            var retval = avcodec_send_packet(_handle, packet);
            if (retval == 0 || retval == AVERROR_EOF || retval == AVERROR(EAGAIN))
            {
                return retval;
            }
            else
            {
                throw new AVError(retval);
            }
        }

        public int Receive(AVFrame frame)
        {
            if (frame is null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            var retval = avcodec_receive_frame(_handle, frame);
            if (retval == 0 || retval == AVERROR_EOF || retval == AVERROR(EAGAIN))
            {
                return retval;
            }
            else
            {
                throw new AVError(retval);
            }
        }

        public static explicit operator Interop.AVCodecContext*(AVCodecContext value)
        {
            return value._handle;
        }
    }
}
