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
        public sbyte* resample_lavr_opts;

        public int thread_type;

        public int nb_threads;

        public AVFilterGraphInternal* @internal;

        public void* opaque;

        [NativeTypeName("avfilter_execute_func *")]
        public delegate* unmanaged[Cdecl]<AVFilterContext*, delegate* unmanaged[Cdecl]<AVFilterContext*, void*, int, int, int>*, void*, int*, int, int>* execute;

        [NativeTypeName("char *")]
        public sbyte* aresample_swr_opts;

        public AVFilterLink** sink_links;

        public int sink_links_count;

        [NativeTypeName("unsigned int")]
        public uint disable_auto_convert;
    }
}
