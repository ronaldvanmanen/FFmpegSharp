namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVSubtitle
    {
        [NativeTypeName("uint16_t")]
        public ushort format;

        [NativeTypeName("uint32_t")]
        public uint start_display_time;

        [NativeTypeName("uint32_t")]
        public uint end_display_time;

        [NativeTypeName("unsigned int")]
        public uint num_rects;

        public AVSubtitleRect** rects;

        [NativeTypeName("int64_t")]
        public long pts;
    }

    public partial struct AVSubtitle
    {
    }
}
