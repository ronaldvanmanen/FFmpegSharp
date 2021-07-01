using System;

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVCodecParser
    {
        [NativeTypeName("int [5]")]
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
        public AVCodecParser* next;
    }
}
