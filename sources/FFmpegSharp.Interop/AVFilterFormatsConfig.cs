namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVFilterFormatsConfig
    {
        [NativeTypeName("AVFilterFormats *")]
        public AVFilterFormats* formats;

        [NativeTypeName("AVFilterFormats *")]
        public AVFilterFormats* samplerates;

        [NativeTypeName("AVFilterChannelLayouts *")]
        public AVFilterChannelLayouts* channel_layouts;
    }
}
