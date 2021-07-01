namespace FFmpegSharp
{
    public unsafe partial struct SwsFilter
    {
        [NativeTypeName("SwsVector *")]
        public SwsVector* lumH;

        [NativeTypeName("SwsVector *")]
        public SwsVector* lumV;

        [NativeTypeName("SwsVector *")]
        public SwsVector* chrH;

        [NativeTypeName("SwsVector *")]
        public SwsVector* chrV;
    }
}
