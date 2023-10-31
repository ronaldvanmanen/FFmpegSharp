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
    public unsafe partial struct AVClass
    {
        [NativeTypeName("const char *")]
        public sbyte* class_name;

        [NativeTypeName("const char *(*)(void *)")]
        public IntPtr item_name;

        [NativeTypeName("const struct AVOption *")]
        public AVOption* option;

        public int version;

        public int log_level_offset_offset;

        public int parent_log_context_offset;

        [NativeTypeName("void *(*)(void *, void *)")]
        public IntPtr child_next;

        [NativeTypeName("const struct AVClass *(*)(const struct AVClass *)")]
        [Obsolete]
        public IntPtr child_class_next;

        public AVClassCategory category;

        [NativeTypeName("AVClassCategory (*)(void *)")]
        public IntPtr get_category;

        [NativeTypeName("int (*)(struct AVOptionRanges **, void *, const char *, int)")]
        public IntPtr query_ranges;

        [NativeTypeName("const struct AVClass *(*)(void **)")]
        public IntPtr child_class_iterate;
    }
}
