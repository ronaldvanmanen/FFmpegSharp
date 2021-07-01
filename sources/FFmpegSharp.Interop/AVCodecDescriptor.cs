namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVCodecDescriptor
    {
        [NativeTypeName("enum AVCodecID")]
        public AVCodecID id;

        [NativeTypeName("enum AVMediaType")]
        public AVMediaType type;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* long_name;

        public int props;

        [NativeTypeName("const char *const *")]
        public sbyte** mime_types;

        [NativeTypeName("const struct AVProfile *")]
        public AVProfile* profiles;

        public partial struct AVProfile
        {
        }
    }
}
