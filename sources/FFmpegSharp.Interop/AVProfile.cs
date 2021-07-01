namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVProfile
    {
        public int profile;

        [NativeTypeName("const char *")]
        public sbyte* name;
    }
}
