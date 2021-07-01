namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVBufferRef
    {
        public AVBuffer* buffer;

        [NativeTypeName("uint8_t *")]
        public byte* data;

        public int size;
    }
}
