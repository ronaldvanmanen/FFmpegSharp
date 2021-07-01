namespace FFmpegSharp
{
    public partial struct AVRegionOfInterest
    {
        [NativeTypeName("uint32_t")]
        public uint self_size;

        public int top;

        public int bottom;

        public int left;

        public int right;

        public AVRational qoffset;
    }
}
