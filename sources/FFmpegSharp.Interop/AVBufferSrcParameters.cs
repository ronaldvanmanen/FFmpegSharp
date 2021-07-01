namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVBufferSrcParameters
    {
        public int format;

        public AVRational time_base;

        public int width;

        public int height;

        public AVRational sample_aspect_ratio;

        public AVRational frame_rate;

        [NativeTypeName("AVBufferRef *")]
        public AVBufferRef* hw_frames_ctx;

        public int sample_rate;

        [NativeTypeName("uint64_t")]
        public ulong channel_layout;
    }
}
