namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVBSFContext
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        [NativeTypeName("const struct AVBitStreamFilter *")]
        public AVBitStreamFilter* filter;

        public AVBSFInternal* @internal;

        public void* priv_data;

        public AVCodecParameters* par_in;

        public AVCodecParameters* par_out;

        public AVRational time_base_in;

        public AVRational time_base_out;
    }
}
