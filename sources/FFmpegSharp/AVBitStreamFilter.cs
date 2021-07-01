using System;

namespace FFmpegSharp
{
    public unsafe partial struct AVBitStreamFilter
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const enum AVCodecID *")]
        public AVCodecID* codec_ids;

        [NativeTypeName("const AVClass *")]
        public AVClass* priv_class;

        public int priv_data_size;

        [NativeTypeName("int (*)(AVBSFContext *)")]
        public IntPtr init;

        [NativeTypeName("int (*)(AVBSFContext *, AVPacket *)")]
        public IntPtr filter;

        [NativeTypeName("void (*)(AVBSFContext *)")]
        public IntPtr close;

        [NativeTypeName("void (*)(AVBSFContext *)")]
        public IntPtr flush;
    }
}
