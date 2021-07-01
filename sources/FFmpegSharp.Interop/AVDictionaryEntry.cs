namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVDictionaryEntry
    {
        [NativeTypeName("char *")]
        public sbyte* key;

        [NativeTypeName("char *")]
        public sbyte* value;
    }
}
