namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVProbeData
    {
        [NativeTypeName("const char *")]
        public sbyte* filename;

        [NativeTypeName("unsigned char *")]
        public byte* buf;

        public int buf_size;

        [NativeTypeName("const char *")]
        public sbyte* mime_type;
    }
}
