namespace FFmpegSharp
{
    public unsafe partial struct AVProgram
    {
        public int id;

        public int flags;

        [NativeTypeName("enum AVDiscard")]
        public AVDiscard discard;

        [NativeTypeName("unsigned int *")]
        public uint* stream_index;

        [NativeTypeName("unsigned int")]
        public uint nb_stream_indexes;

        [NativeTypeName("AVDictionary *")]
        public AVDictionary* metadata;

        public int program_num;

        public int pmt_pid;

        public int pcr_pid;

        public int pmt_version;

        [NativeTypeName("int64_t")]
        public long start_time;

        [NativeTypeName("int64_t")]
        public long end_time;

        [NativeTypeName("int64_t")]
        public long pts_wrap_reference;

        public int pts_wrap_behavior;
    }
}
