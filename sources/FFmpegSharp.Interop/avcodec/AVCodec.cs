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
    public unsafe partial struct AVCodec
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* long_name;

        [NativeTypeName("enum AVMediaType")]
        public AVMediaType type;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID id;

        public int capabilities;

        [NativeTypeName("const AVRational *")]
        public AVRational* supported_framerates;

        [NativeTypeName("const enum AVPixelFormat *")]
        public AVPixelFormat* pix_fmts;

        [NativeTypeName("const int *")]
        public int* supported_samplerates;

        [NativeTypeName("const enum AVSampleFormat *")]
        public AVSampleFormat* sample_fmts;

        [NativeTypeName("const uint64_t *")]
        public ulong* channel_layouts;

        [NativeTypeName("uint8_t")]
        public byte max_lowres;

        [NativeTypeName("const AVClass *")]
        public AVClass* priv_class;

        [NativeTypeName("const AVProfile *")]
        public AVProfile* profiles;

        [NativeTypeName("const char *")]
        public sbyte* wrapper_name;

        public int priv_data_size;

        [NativeTypeName("struct AVCodec *")]
        public AVCodec* next;

        [NativeTypeName("int (*)(struct AVCodecContext *, const struct AVCodecContext *)")]
        public IntPtr update_thread_context;

        [NativeTypeName("const AVCodecDefault *")]
        public AVCodecDefault* defaults;

        [NativeTypeName("void (*)(struct AVCodec *)")]
        public IntPtr init_static_data;

        [NativeTypeName("int (*)(struct AVCodecContext *)")]
        public IntPtr init;

        [NativeTypeName("int (*)(struct AVCodecContext *, uint8_t *, int, const struct AVSubtitle *)")]
        public IntPtr encode_sub;

        [NativeTypeName("int (*)(struct AVCodecContext *, struct AVPacket *, const struct AVFrame *, int *)")]
        public IntPtr encode2;

        [NativeTypeName("int (*)(struct AVCodecContext *, void *, int *, struct AVPacket *)")]
        public IntPtr decode;

        [NativeTypeName("int (*)(struct AVCodecContext *)")]
        public IntPtr close;

        [NativeTypeName("int (*)(struct AVCodecContext *, struct AVPacket *)")]
        public IntPtr receive_packet;

        [NativeTypeName("int (*)(struct AVCodecContext *, struct AVFrame *)")]
        public IntPtr receive_frame;

        [NativeTypeName("void (*)(struct AVCodecContext *)")]
        public IntPtr flush;

        public int caps_internal;

        [NativeTypeName("const char *")]
        public sbyte* bsfs;

        [NativeTypeName("const struct AVCodecHWConfigInternal *const *")]
        public AVCodecHWConfigInternal** hw_configs;

        [NativeTypeName("const uint32_t *")]
        public uint* codec_tags;

        public partial struct AVCodecHWConfigInternal
        {
        }
    }
}
