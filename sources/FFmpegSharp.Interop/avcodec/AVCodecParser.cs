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
    public unsafe partial struct AVCodecParser
    {
        [NativeTypeName("int[5]")]
        public fixed int codec_ids[5];

        public int priv_data_size;

        [NativeTypeName("int (*)(AVCodecParserContext *)")]
        public IntPtr parser_init;

        [NativeTypeName("int (*)(AVCodecParserContext *, AVCodecContext *, const uint8_t **, int *, const uint8_t *, int)")]
        public IntPtr parser_parse;

        [NativeTypeName("void (*)(AVCodecParserContext *)")]
        public IntPtr parser_close;

        [NativeTypeName("int (*)(AVCodecContext *, const uint8_t *, int)")]
        public IntPtr split;

        [NativeTypeName("struct AVCodecParser *")]
        [Obsolete]
        public AVCodecParser* next;
    }
}
