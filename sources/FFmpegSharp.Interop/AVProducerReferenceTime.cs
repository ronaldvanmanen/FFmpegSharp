namespace FFmpegSharp.Interop
{
    public partial struct AVProducerReferenceTime
    {
        [NativeTypeName("int64_t")]
        public long wallclock;

        public int flags;
    }
}
