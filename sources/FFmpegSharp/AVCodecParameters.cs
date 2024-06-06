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
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVCodecParameters : IDisposable
    {
        private readonly Interop.AVCodecParameters* _handle;

        private readonly bool _ownsHandle;

        public AVMediaType CodecType
        {
            get
            {
                ThrowIfDisposed();

                return (AVMediaType)_handle->codec_type;
            }
        }

        public AVCodecID CodecID
        {
            get
            {
                ThrowIfDisposed();

                return (AVCodecID)_handle->codec_id;
            }
        }

        public uint CodecTag
        {
            get
            {
                ThrowIfDisposed();

                return _handle->codec_tag;
            }
        }

        public byte* ExtraData
        {
            get
            {
                ThrowIfDisposed();

                return _handle->extradata;
            }
        }

        public int ExtraDataSize
        {
            get
            {
                ThrowIfDisposed();

                return _handle->extradata_size;
            }
        }

        public int Format
        {
            get
            {
                ThrowIfDisposed();

                return _handle->format;
            }
        }

        public long BitRate
        {
            get
            {
                ThrowIfDisposed();

                return _handle->bit_rate;
            }
        }

        public int BitsPerCodecSample
        {
            get
            {
                ThrowIfDisposed();

                return _handle->bits_per_coded_sample;
            }
        }

        public int BitsPerRawSample
        {
            get
            {
                ThrowIfDisposed();

                return _handle->bits_per_raw_sample;
            }
        }

        public int Profile
        {
            get
            {
                ThrowIfDisposed();

                return _handle->profile;
            }
        }

        public int Level
        {
            get
            {
                ThrowIfDisposed();

                return _handle->level;
            }
        }

        public int Width
        {
            get
            {
                ThrowIfDisposed();

                return _handle->width;
            }
        }

        public int Height
        {
            get
            {
                ThrowIfDisposed();

                return _handle->height;
            }
        }

        public AVRational SampleAspectRatio
        {
            get
            {
                ThrowIfDisposed();

                return _handle->sample_aspect_ratio;
            }
        }

        public AVFieldOrder FieldOrder
        {
            get
            {
                ThrowIfDisposed();

                return (AVFieldOrder)_handle->field_order;
            }
        }

        public AVColorRange ColorRange
        {
            get
            {
                ThrowIfDisposed();

                return (AVColorRange)_handle->color_range;
            }
        }

        public AVColorPrimaries ColorPrimaries
        {
            get
            {
                ThrowIfDisposed();

                return (AVColorPrimaries)_handle->color_primaries;
            }
        }

        public AVColorTransferCharacteristic ColorTransferCharacteristic
        {
            get
            {
                ThrowIfDisposed();

                return (AVColorTransferCharacteristic)_handle->color_trc;
            }
        }

        public AVColorSpace ColorSpace
        {
            get
            {
                ThrowIfDisposed();

                return (AVColorSpace)_handle->color_space;
            }
        }

        public AVChromaLocation ChromaLocation
        {
            get
            {
                ThrowIfDisposed();

                return (AVChromaLocation)_handle->chroma_location;
            }
        }

        public int VideoDelay
        {
            get
            {
                ThrowIfDisposed();

                return _handle->video_delay;
            }
        }

        public ulong ChannelLayout
        {
            get
            {
                ThrowIfDisposed();

                return _handle->channel_layout;
            }
        }

        public int Channels
        {
            get
            {
                ThrowIfDisposed();

                return _handle->channels;
            }
        }

        public int SampleRate
        {
            get
            {
                ThrowIfDisposed();

                return _handle->sample_rate;
            }
        }

        public int BlockAlign
        {
            get
            {
                ThrowIfDisposed();

                return _handle->block_align;
            }
        }

        public int FrameSize
        {
            get
            {
                ThrowIfDisposed();

                return _handle->frame_size;
            }
        }

        public int InitialPadding
        {
            get
            {
                ThrowIfDisposed();

                return _handle->initial_padding;
            }
        }

        public int TrailingPadding
        {
            get
            {
                ThrowIfDisposed();

                return _handle->trailing_padding;
            }
        }

        public int SeekPreroll
        {
            get
            {
                ThrowIfDisposed();

                return _handle->seek_preroll;
            }
        }

        public AVCodecParameters()
        : this(avcodec_parameters_alloc(), true)
        { }

        public AVCodecParameters(AVCodecParameters other)
        : this(avcodec_parameters_alloc(), true)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            AVError.ThrowOnError(
                avcodec_parameters_copy(_handle, other._handle)
            );
        }

        public AVCodecParameters(Interop.AVCodecParameters* handle, bool ownsHandle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
            _ownsHandle = ownsHandle;
        }

        ~AVCodecParameters()
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
                fixed (Interop.AVCodecParameters** handle = &_handle)
                {
                    avcodec_parameters_free(handle);
                }
            }
        }

        private void ThrowIfDisposed()
        {
            if (_handle == null)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        public static implicit operator Interop.AVCodecParameters*(AVCodecParameters value)
        {
            return value._handle;
        }
    }
}
