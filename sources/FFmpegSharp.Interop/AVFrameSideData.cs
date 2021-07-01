namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVFrameSideData
    {
        [NativeTypeName("enum AVFrameSideDataType")]
        public AVFrameSideDataType type;

        [NativeTypeName("uint8_t *")]
        public byte* data;

        public int size;

        public AVDictionary* metadata;

        public AVBufferRef* buf;
    }
}
