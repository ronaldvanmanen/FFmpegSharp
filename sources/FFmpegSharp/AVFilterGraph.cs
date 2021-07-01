using System;

namespace FFmpegSharp
{
    public unsafe partial struct AVFilterGraph
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        [NativeTypeName("AVFilterContext **")]
        public AVFilterContext** filters;

        [NativeTypeName("unsigned int")]
        public uint nb_filters;

        [NativeTypeName("char *")]
        public sbyte* scale_sws_opts;

        [NativeTypeName("char *")]
        public sbyte* resample_lavr_opts;

        public int thread_type;

        public int nb_threads;

        [NativeTypeName("AVFilterGraphInternal *")]
        public AVFilterGraphInternal* @internal;

        [NativeTypeName("void *")]
        public void* opaque;

        [NativeTypeName("avfilter_execute_func *")]
        public IntPtr* execute;

        [NativeTypeName("char *")]
        public sbyte* aresample_swr_opts;

        [NativeTypeName("AVFilterLink **")]
        public AVFilterLink** sink_links;

        public int sink_links_count;

        [NativeTypeName("unsigned int")]
        public uint disable_auto_convert;
    }
}
