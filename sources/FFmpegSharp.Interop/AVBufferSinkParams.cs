namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVBufferSinkParams
    {
        [NativeTypeName("const enum AVPixelFormat *")]
        public AVPixelFormat* pixel_fmts;
    }
}
