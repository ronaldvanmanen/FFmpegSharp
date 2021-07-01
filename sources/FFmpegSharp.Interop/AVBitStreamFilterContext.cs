namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVBitStreamFilterContext
    {
        public void* priv_data;

        [NativeTypeName("const struct AVBitStreamFilter *")]
        public AVBitStreamFilter* filter;

        public AVCodecParserContext* parser;

        [NativeTypeName("struct AVBitStreamFilterContext *")]
        public AVBitStreamFilterContext* next;

        [NativeTypeName("char *")]
        public sbyte* args;
    }
}
