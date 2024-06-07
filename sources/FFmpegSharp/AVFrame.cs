// Copyright (C) 2021-2024 Ronald van Manen
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
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVFrame : IDisposable
    {
        private readonly Interop.AVFrame* _handle;

        private readonly bool _ownsHandle;

        public Interop.AVFrame* Handle => _handle;

        public AVTimeStamp BestEffortTimestamp
        {
            get
            {
                ThrowIfDisposed();

                return new(_handle->best_effort_timestamp);
            }
            set
            {
                ThrowIfDisposed();

                _handle->best_effort_timestamp = (long)value;
            }
        }

        public AVTimeStamp Pts
        {
            get
            {
                ThrowIfDisposed();

                return new(_handle->pts);
            }
            set
            {
                ThrowIfDisposed();

                _handle->pts = (long)value;
            }
        }

        public AVTimeStamp PacketPts
        {
            get
            {
                ThrowIfDisposed();

                return new(_handle->pts);
            }
            set
            {
                ThrowIfDisposed();

                _handle->pts = (long)value;
            }
        }

        public AVTimeStamp PacketDts
        {
            get
            {
                ThrowIfDisposed();

                return new(_handle->pkt_dts);
            }
            set
            {
                ThrowIfDisposed();

                _handle->pkt_dts = (long)value;
            }
        }

        public long PacketPosition
        {
            get
            {
                ThrowIfDisposed();

                return _handle->pkt_pos;
            }
            set
            {
                ThrowIfDisposed();

                _handle->pkt_pos = value;
            }
        }

        public AVRational SampleAspectRatio
        {
            get
            {
                ThrowIfDisposed();

                return _handle->sample_aspect_ratio;
            }
            set
            {
                ThrowIfDisposed();

                _handle->sample_aspect_ratio = value;
            }
        }

        public int Format
        {
            get
            {
                ThrowIfDisposed();

                return _handle->format;
            }
            set
            {
                ThrowIfDisposed();

                _handle->format = value;
            }
        }

        public AVSampleFormat SampleFormat
        {
            get
            {
                ThrowIfDisposed();

                return (AVSampleFormat)_handle->format;
            }
            set
            {
                ThrowIfDisposed();

                _handle->format = (int)value;
            }
        }

        public AVPixelFormat PixelFormat
        {
            get
            {
                ThrowIfDisposed();

                return (AVPixelFormat)_handle->format;
            }
            set
            {
                ThrowIfDisposed();

                _handle->format = (int)value;
            }
        }

        public int Width
        {
            get
            {
                ThrowIfDisposed();

                return _handle->width;
            }
            set
            {
                ThrowIfDisposed();

                _handle->width = value;
            }
        }

        public int Height
        {
            get
            {
                ThrowIfDisposed();

                return _handle->height;
            }
            set
            {
                ThrowIfDisposed();

                _handle->height = value;
            }
        }

        public int ChannelCount
        {
            get
            {
                ThrowIfDisposed();

                return _handle->channels;
            }
            set
            {
                ThrowIfDisposed();

                _handle->channels = value;
            }
        }

        public AVChannelLayout ChannelLayout
        {
            get
            {
                ThrowIfDisposed();

                return (AVChannelLayout)_handle->channel_layout;
            }
            set
            {
                ThrowIfDisposed();

                _handle->channel_layout = (ulong)value;
            }
        }

        public int SampleCount
        {
            get
            {
                ThrowIfDisposed();

                return _handle->nb_samples;
            }
            set
            {
                ThrowIfDisposed();

                _handle->nb_samples = value;
            }
        }

        public int SampleRate
        {
            get
            {
                ThrowIfDisposed();

                return _handle->sample_rate;
            }
            set
            {
                ThrowIfDisposed();

                _handle->sample_rate = value;
            }
        }

        public AVFrame()
        : this(av_frame_alloc(), true)
        { }

        public AVFrame(Interop.AVFrame* handle, bool ownsHandle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
            _ownsHandle = ownsHandle;
        }

        ~AVFrame()
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
                fixed (Interop.AVFrame** handle = &_handle)
                {
                    av_frame_free(handle);
                }
            }
        }

        public void CopyProps(AVFrame destination)
        {
            ThrowIfDisposed();

            AVError.ThrowOnError(
                av_frame_copy_props(destination._handle, _handle)
            );
        }

        public void MoveRef(AVFrame destination)
        {
            ThrowIfDisposed();

            av_frame_move_ref(destination._handle, _handle);
        }

        public void Unref()
        {
            ThrowIfDisposed();

            av_frame_unref(_handle);
        }

        private void ThrowIfDisposed()
        {
            if (_handle == null)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        public static implicit operator Interop.AVFrame*(AVFrame value)
        {
            return value._handle;
        }
    }
}
