namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVFilterInOut
    {
        [NativeTypeName("char *")]
        public sbyte* name;

        [NativeTypeName("AVFilterContext *")]
        public AVFilterContext* filter_ctx;

        public int pad_idx;

        [NativeTypeName("struct AVFilterInOut *")]
        public AVFilterInOut* next;
    }
}
