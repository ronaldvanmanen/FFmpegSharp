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

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVFilterGraph
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        public AVFilterContext** filters;

        [NativeTypeName("unsigned int")]
        public uint nb_filters;

        [NativeTypeName("char *")]
        public sbyte* scale_sws_opts;

        [NativeTypeName("char *")]
        [Obsolete]
        public sbyte* resample_lavr_opts;

        public int thread_type;

        public int nb_threads;

        public AVFilterGraphInternal* @internal;

        public void* opaque;

        [NativeTypeName("avfilter_execute_func *")]
        public IntPtr execute;

        [NativeTypeName("char *")]
        public sbyte* aresample_swr_opts;

        public AVFilterLink** sink_links;

        public int sink_links_count;

        [NativeTypeName("unsigned int")]
        public uint disable_auto_convert;
    }
}
