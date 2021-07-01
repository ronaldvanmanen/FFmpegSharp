namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVFifoBuffer
    {
        [NativeTypeName("uint8_t *")]
        public byte* buffer;

        [NativeTypeName("uint8_t *")]
        public byte* rptr;

        [NativeTypeName("uint8_t *")]
        public byte* wptr;

        [NativeTypeName("uint8_t *")]
        public byte* end;

        [NativeTypeName("uint32_t")]
        public uint rndx;

        [NativeTypeName("uint32_t")]
        public uint wndx;
    }
}
