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

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVCodecParameters
    {
        [NativeTypeName("enum AVMediaType")]
        public AVMediaType codec_type;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID codec_id;

        [NativeTypeName("uint32_t")]
        public uint codec_tag;

        [NativeTypeName("uint8_t *")]
        public byte* extradata;

        public int extradata_size;

        public int format;

        [NativeTypeName("int64_t")]
        public long bit_rate;

        public int bits_per_coded_sample;

        public int bits_per_raw_sample;

        public int profile;

        public int level;

        public int width;

        public int height;

        public AVRational sample_aspect_ratio;

        [NativeTypeName("enum AVFieldOrder")]
        public AVFieldOrder field_order;

        [NativeTypeName("enum AVColorRange")]
        public AVColorRange color_range;

        [NativeTypeName("enum AVColorPrimaries")]
        public AVColorPrimaries color_primaries;

        [NativeTypeName("enum AVColorTransferCharacteristic")]
        public AVColorTransferCharacteristic color_trc;

        [NativeTypeName("enum AVColorSpace")]
        public AVColorSpace color_space;

        [NativeTypeName("enum AVChromaLocation")]
        public AVChromaLocation chroma_location;

        public int video_delay;

        [NativeTypeName("uint64_t")]
        public ulong channel_layout;

        public int channels;

        public int sample_rate;

        public int block_align;

        public int frame_size;

        public int initial_padding;

        public int trailing_padding;

        public int seek_preroll;
    }
}
