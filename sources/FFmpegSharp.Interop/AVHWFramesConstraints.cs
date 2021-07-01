namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVHWFramesConstraints
    {
        [NativeTypeName("enum AVPixelFormat *")]
        public AVPixelFormat* valid_hw_formats;

        [NativeTypeName("enum AVPixelFormat *")]
        public AVPixelFormat* valid_sw_formats;

        public int min_width;

        public int min_height;

        public int max_width;

        public int max_height;
    }
}
