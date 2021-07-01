namespace FFmpegSharp
{
    public unsafe partial struct AVClass
    {
        [NativeTypeName("const char *")]
        public sbyte* class_name;

        [NativeTypeName("const char *(*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, sbyte*> item_name;

        [NativeTypeName("const struct AVOption *")]
        public AVOption* option;

        public int version;

        public int log_level_offset_offset;

        public int parent_log_context_offset;

        [NativeTypeName("void *(*)(void *, void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*> child_next;

        [NativeTypeName("const struct AVClass *(*)(const struct AVClass *)")]
        public delegate* unmanaged[Cdecl]<AVClass*, AVClass*> child_class_next;

        public AVClassCategory category;

        [NativeTypeName("AVClassCategory (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, AVClassCategory> get_category;

        [NativeTypeName("int (*)(struct AVOptionRanges **, void *, const char *, int)")]
        public delegate* unmanaged[Cdecl]<AVOptionRanges**, void*, sbyte*, int, int> query_ranges;

        [NativeTypeName("const struct AVClass *(*)(void **)")]
        public delegate* unmanaged[Cdecl]<void**, AVClass*> child_class_iterate;

        public partial struct AVOption
        {
        }
    }
}
