namespace FFmpegSharp.Interop
{
    public partial struct AVCodecHWConfig
    {
        [NativeTypeName("enum AVPixelFormat")]
        public AVPixelFormat pix_fmt;

        public int methods;

        [NativeTypeName("enum AVHWDeviceType")]
        public AVHWDeviceType device_type;
    }
}
