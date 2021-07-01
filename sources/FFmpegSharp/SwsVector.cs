namespace FFmpegSharp
{
    public unsafe partial struct SwsVector
    {
        [NativeTypeName("double *")]
        public double* coeff;

        public int length;
    }
}
