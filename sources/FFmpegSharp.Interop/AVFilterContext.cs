namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVFilterContext
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        [NativeTypeName("const AVFilter *")]
        public AVFilter* filter;

        [NativeTypeName("char *")]
        public sbyte* name;

        [NativeTypeName("AVFilterPad *")]
        public AVFilterPad* input_pads;

        [NativeTypeName("AVFilterLink **")]
        public AVFilterLink** inputs;

        [NativeTypeName("unsigned int")]
        public uint nb_inputs;

        [NativeTypeName("AVFilterPad *")]
        public AVFilterPad* output_pads;

        [NativeTypeName("AVFilterLink **")]
        public AVFilterLink** outputs;

        [NativeTypeName("unsigned int")]
        public uint nb_outputs;

        [NativeTypeName("void *")]
        public void* priv;

        [NativeTypeName("struct AVFilterGraph *")]
        public AVFilterGraph* graph;

        public int thread_type;

        [NativeTypeName("AVFilterInternal *")]
        public AVFilterInternal* @internal;

        [NativeTypeName("struct AVFilterCommand *")]
        public AVFilterCommand* command_queue;

        [NativeTypeName("char *")]
        public sbyte* enable_str;

        [NativeTypeName("void *")]
        public void* enable;

        [NativeTypeName("double *")]
        public double* var_values;

        public int is_disabled;

        [NativeTypeName("AVBufferRef *")]
        public AVBufferRef* hw_device_ctx;

        public int nb_threads;

        [NativeTypeName("unsigned int")]
        public uint ready;

        public int extra_hw_frames;

        public partial struct AVFilterCommand
        {
        }
    }
}
