namespace FFmpegSharp.Interop
{
    public partial struct AVPacket
    {
    }

    public unsafe partial struct AVPacket
    {
        public AVBufferRef* buf;

        [NativeTypeName("int64_t")]
        public long pts;

        [NativeTypeName("int64_t")]
        public long dts;

        [NativeTypeName("uint8_t *")]
        public byte* data;

        public int size;

        public int stream_index;

        public int flags;

        public AVPacketSideData* side_data;

        public int side_data_elems;

        [NativeTypeName("int64_t")]
        public long duration;

        [NativeTypeName("int64_t")]
        public long pos;

        [NativeTypeName("int64_t")]
        public long convergence_duration;
    }
}
