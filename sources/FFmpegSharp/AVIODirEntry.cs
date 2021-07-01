namespace FFmpegSharp
{
    public unsafe partial struct AVIODirEntry
    {
        [NativeTypeName("char *")]
        public sbyte* name;

        public int type;

        public int utf8;

        [NativeTypeName("int64_t")]
        public long size;

        [NativeTypeName("int64_t")]
        public long modification_timestamp;

        [NativeTypeName("int64_t")]
        public long access_timestamp;

        [NativeTypeName("int64_t")]
        public long status_change_timestamp;

        [NativeTypeName("int64_t")]
        public long user_id;

        [NativeTypeName("int64_t")]
        public long group_id;

        [NativeTypeName("int64_t")]
        public long filemode;
    }
}
