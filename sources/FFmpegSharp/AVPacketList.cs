namespace FFmpegSharp
{
    public unsafe partial struct AVPacketList
    {
        public AVPacket pkt;

        [NativeTypeName("struct AVPacketList *")]
        public AVPacketList* next;
    }
}
