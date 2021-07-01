namespace FFmpegSharp.Interop
{
    public partial struct FFTComplex
    {
        [NativeTypeName("FFTSample")]
        public float re;

        [NativeTypeName("FFTSample")]
        public float im;
    }
}
