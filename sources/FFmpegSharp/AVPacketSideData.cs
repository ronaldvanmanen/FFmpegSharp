namespace FFmpegSharp
{
    public unsafe partial struct AVPacketSideData
    {
        [NativeTypeName("uint8_t *")]
        public byte* data;

        public int size;

        [NativeTypeName("enum AVPacketSideDataType")]
        public AVPacketSideDataType type;
    }
}
