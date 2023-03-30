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
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVCodecParameters : IDisposable
    {
        private readonly Interop.AVCodecParameters* _handle;

        private readonly bool _ownsHandle;

        public AVMediaType CodecType => (AVMediaType)_handle->codec_type;

        public AVCodecID CodecID => (AVCodecID)_handle->codec_id;

        public uint CodecTag => _handle->codec_tag;

        public byte* ExtraData => _handle->extradata;

        public int ExtraDataSize => _handle->extradata_size;

        public int Format => _handle->format;

        public long BitRate => _handle->bit_rate;

        public int BitsPerCodecSample => _handle->bits_per_coded_sample;

        public int BitsPerRawSample => _handle->bits_per_raw_sample;

        public int Profile => _handle->profile;

        public int Level => _handle->level;

        public int Width => _handle->width;

        public int Height => _handle->height;

        public AVRational SampleAspectRatio => _handle->sample_aspect_ratio;

        public AVFieldOrder FieldOrder => (AVFieldOrder)_handle->field_order;

        public AVColorRange ColorRange => (AVColorRange)_handle->color_range;

        public AVColorPrimaries ColorPrimaries => (AVColorPrimaries)_handle->color_primaries;

        public AVColorTransferCharacteristic ColorTransferCharacteristic => (AVColorTransferCharacteristic)_handle->color_trc;

        public AVColorSpace ColorSpace => (AVColorSpace)_handle->color_space;

        public AVChromaLocation ChromaLocation => (AVChromaLocation)_handle->chroma_location;

        public int VideoDelay => _handle->video_delay;

        public ulong ChannelLayout => _handle->channel_layout;

        public int Channels => _handle->channels;

        public int SampleRate => _handle->sample_rate;

        public int BlockAlign => _handle->block_align;

        public int FrameSize => _handle->frame_size;

        public int InitialPadding => _handle->initial_padding;

        public int TrailingPadding => _handle->trailing_padding;

        public int SeekPreroll => _handle->seek_preroll;

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

        public static implicit operator Interop.AVCodecParameters*(AVCodecParameters value)
        {
            return value._handle;
        }
    }
}
