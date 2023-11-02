// Copyright (c) 2021-2023 Ronald van Manen
//
// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with FFmpegSharp; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA

using System;
using System.Diagnostics.CodeAnalysis;
using static FFmpegSharp.Interop.FFmpeg;
using static FFmpegSharp.AVError;

namespace FFmpegSharp
{
    public sealed unsafe class AVCodecContext : IDisposable
    {
        private readonly Interop.AVCodecContext* _handle;

        private readonly bool _ownsHandle;

        public AVMediaType CodecType => (AVMediaType)_handle->codec_type;

        public AVCodec Codec => new(_handle->codec);

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
            get => new(_handle->time_base);

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
            get => new(_handle->pkt_timebase);

            set => _handle->pkt_timebase = (AVRational)value;
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
            ThrowOnError(
                avcodec_parameters_to_context(_handle, codecParameters)
            );
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
            ThrowIfDisposed();

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
                ThrowOnError(
                    av_dict_copy(&optionsHandle, options.Handle, 0)
                );
            }

            ThrowOnError(
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
            ThrowOnError(
                avcodec_close(_handle)
            );
        }

        public void FlushBuffers()
        {
            ThrowIfDisposed();

            avcodec_flush_buffers(_handle);
        }

        public void Send(in AVPacket packet)
        {
            if (!TrySend(packet, out var error))
            {
                throw error;
            }
        }

        public bool TrySend(in AVPacket packet, [NotNullWhen(false)] out AVError? error)
        {
            ThrowIfDisposed();

            var returnCode = avcodec_send_packet(_handle, packet);
            var success = !ReturnOnFailure(returnCode, out error);
            return success;
        }

        public void Receive(ref AVFrame frame)
        {
            if (!TryReceive(ref frame, out var error))
            {
                throw error;
            }
        }

        public bool TryReceive(ref AVFrame frame, [NotNullWhen(false)] out AVError? error)
        {
            ThrowIfDisposed();

            var returnCode = avcodec_receive_frame(_handle, frame);
            var success = !ReturnOnFailure(returnCode, out error);
            return success;
        }

        private void ThrowIfDisposed()
        {
            if (_handle == null)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        public static explicit operator Interop.AVCodecContext*(AVCodecContext value)
        {
            return value._handle;
        }
    }
}
