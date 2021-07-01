namespace FFmpegSharp.Interop
{
    public unsafe partial struct SwsFilter
    {
        public SwsVector* lumH;

        public SwsVector* lumV;

        public SwsVector* chrH;

        public SwsVector* chrV;
    }
}
