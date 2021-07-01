namespace FFmpegSharp
{
    public unsafe partial struct AVABufferSinkParams
    {
        [NativeTypeName("const enum AVSampleFormat *")]
        public AVSampleFormat* sample_fmts;

        [NativeTypeName("const int64_t *")]
        public long* channel_layouts;

        [NativeTypeName("const int *")]
        public int* channel_counts;

        public int all_channel_counts;

        [NativeTypeName("int *")]
        public int* sample_rates;
    }
}
