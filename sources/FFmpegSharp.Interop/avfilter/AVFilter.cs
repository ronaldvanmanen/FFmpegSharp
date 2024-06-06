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
    public unsafe partial struct AVFilter
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* description;

        [NativeTypeName("const AVFilterPad *")]
        public AVFilterPad* inputs;

        [NativeTypeName("const AVFilterPad *")]
        public AVFilterPad* outputs;

        [NativeTypeName("const AVClass *")]
        public AVClass* priv_class;

        public int flags;

        [NativeTypeName("int (*)(AVFilterContext *)")]
        public IntPtr preinit;

        [NativeTypeName("int (*)(AVFilterContext *)")]
        public IntPtr init;

        [NativeTypeName("int (*)(AVFilterContext *, AVDictionary **)")]
        public IntPtr init_dict;

        [NativeTypeName("void (*)(AVFilterContext *)")]
        public IntPtr uninit;

        [NativeTypeName("int (*)(AVFilterContext *)")]
        public IntPtr query_formats;

        public int priv_size;

        public int flags_internal;

        [NativeTypeName("struct AVFilter *")]
        public AVFilter* next;

        [NativeTypeName("int (*)(AVFilterContext *, const char *, const char *, char *, int, int)")]
        public IntPtr process_command;

        [NativeTypeName("int (*)(AVFilterContext *, void *)")]
        public IntPtr init_opaque;

        [NativeTypeName("int (*)(AVFilterContext *)")]
        public IntPtr activate;
    }
}
