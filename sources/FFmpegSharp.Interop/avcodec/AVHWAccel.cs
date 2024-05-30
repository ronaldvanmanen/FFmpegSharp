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

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVHWAccel
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("enum AVMediaType")]
        public AVMediaType type;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID id;

        [NativeTypeName("enum AVPixelFormat")]
        public AVPixelFormat pix_fmt;

        public int capabilities;

        [NativeTypeName("int (*)(AVCodecContext *, AVFrame *)")]
        public IntPtr alloc_frame;

        [NativeTypeName("int (*)(AVCodecContext *, const uint8_t *, uint32_t)")]
        public IntPtr start_frame;

        [NativeTypeName("int (*)(AVCodecContext *, int, const uint8_t *, uint32_t)")]
        public IntPtr decode_params;

        [NativeTypeName("int (*)(AVCodecContext *, const uint8_t *, uint32_t)")]
        public IntPtr decode_slice;

        [NativeTypeName("int (*)(AVCodecContext *)")]
        public IntPtr end_frame;

        public int frame_priv_data_size;

        [NativeTypeName("void (*)(struct MpegEncContext *)")]
        public IntPtr decode_mb;

        [NativeTypeName("int (*)(AVCodecContext *)")]
        public IntPtr init;

        [NativeTypeName("int (*)(AVCodecContext *)")]
        public IntPtr uninit;

        public int priv_data_size;

        public int caps_internal;

        [NativeTypeName("int (*)(AVCodecContext *, AVBufferRef *)")]
        public IntPtr frame_params;
    }
}
