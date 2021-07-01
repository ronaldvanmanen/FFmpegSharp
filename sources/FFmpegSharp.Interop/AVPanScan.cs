namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVPanScan
    {
        public int id;

        public int width;

        public int height;

        [NativeTypeName("int16_t [3][2]")]
        public fixed short position[3 * 2];
    }
}
