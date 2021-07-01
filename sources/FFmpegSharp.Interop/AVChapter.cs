namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVChapter
    {
        public int id;

        public AVRational time_base;

        [NativeTypeName("int64_t")]
        public long start;

        [NativeTypeName("int64_t")]
        public long end;

        public AVDictionary* metadata;
    }
}
