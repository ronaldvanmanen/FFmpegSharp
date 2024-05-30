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
using System.Runtime.CompilerServices;

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVFrame
    {
        [NativeTypeName("uint8_t *[8]")]
        public _data_e__FixedBuffer data;

        [NativeTypeName("int[8]")]
        public fixed int linesize[8];

        [NativeTypeName("uint8_t **")]
        public byte** extended_data;

        public int width;

        public int height;

        public int nb_samples;

        public int format;

        public int key_frame;

        [NativeTypeName("enum AVPictureType")]
        public AVPictureType pict_type;

        public AVRational sample_aspect_ratio;

        [NativeTypeName("int64_t")]
        public long pts;

        [NativeTypeName("int64_t")]
        [Obsolete]
        public long pkt_pts;

        [NativeTypeName("int64_t")]
        public long pkt_dts;

        public int coded_picture_number;

        public int display_picture_number;

        public int quality;

        public void* opaque;

        [NativeTypeName("uint64_t[8]")]
        [Obsolete]
        public fixed ulong error[8];

        public int repeat_pict;

        public int interlaced_frame;

        public int top_field_first;

        public int palette_has_changed;

        [NativeTypeName("int64_t")]
        public long reordered_opaque;

        public int sample_rate;

        [NativeTypeName("uint64_t")]
        public ulong channel_layout;

        [NativeTypeName("AVBufferRef *[8]")]
        public _buf_e__FixedBuffer buf;

        public AVBufferRef** extended_buf;

        public int nb_extended_buf;

        public AVFrameSideData** side_data;

        public int nb_side_data;

        public int flags;

        [NativeTypeName("enum AVColorRange")]
        public AVColorRange color_range;

        [NativeTypeName("enum AVColorPrimaries")]
        public AVColorPrimaries color_primaries;

        [NativeTypeName("enum AVColorTransferCharacteristic")]
        public AVColorTransferCharacteristic color_trc;

        [NativeTypeName("enum AVColorSpace")]
        public AVColorSpace colorspace;

        [NativeTypeName("enum AVChromaLocation")]
        public AVChromaLocation chroma_location;

        [NativeTypeName("int64_t")]
        public long best_effort_timestamp;

        [NativeTypeName("int64_t")]
        public long pkt_pos;

        [NativeTypeName("int64_t")]
        public long pkt_duration;

        public AVDictionary* metadata;

        public int decode_error_flags;

        public int channels;

        public int pkt_size;

        [NativeTypeName("int8_t *")]
        [Obsolete]
        public sbyte* qscale_table;

        [Obsolete]
        public int qstride;

        [Obsolete]
        public int qscale_type;

        [Obsolete]
        public AVBufferRef* qp_table_buf;

        public AVBufferRef* hw_frames_ctx;

        public AVBufferRef* opaque_ref;

        [NativeTypeName("size_t")]
        public UIntPtr crop_top;

        [NativeTypeName("size_t")]
        public UIntPtr crop_bottom;

        [NativeTypeName("size_t")]
        public UIntPtr crop_left;

        [NativeTypeName("size_t")]
        public UIntPtr crop_right;

        public AVBufferRef* private_ref;

        public unsafe partial struct _data_e__FixedBuffer
        {
            public byte* e0;
            public byte* e1;
            public byte* e2;
            public byte* e3;
            public byte* e4;
            public byte* e5;
            public byte* e6;
            public byte* e7;

            public ref byte* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (byte** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }

        public unsafe partial struct _buf_e__FixedBuffer
        {
            public AVBufferRef* e0;
            public AVBufferRef* e1;
            public AVBufferRef* e2;
            public AVBufferRef* e3;
            public AVBufferRef* e4;
            public AVBufferRef* e5;
            public AVBufferRef* e6;
            public AVBufferRef* e7;

            public ref AVBufferRef* this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    fixed (AVBufferRef** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }
}
