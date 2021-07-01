namespace FFmpegSharp.Interop
{
    public partial struct AVCPBProperties
    {
        public int max_bitrate;

        public int min_bitrate;

        public int avg_bitrate;

        public int buffer_size;

        [NativeTypeName("uint64_t")]
        public ulong vbv_delay;
    }
}
