namespace FFmpegSharp.Interop
{
    public partial struct AVIndexEntry
    {
        [NativeTypeName("int64_t")]
        public long pos;

        [NativeTypeName("int64_t")]
        public long timestamp;

        public int _bitfield;

        [NativeTypeName("int : 2")]
        public int flags
        {
            get
            {
                return _bitfield & 0x3;
            }

            set
            {
                _bitfield = (_bitfield & ~0x3) | (value & 0x3);
            }
        }

        [NativeTypeName("int : 30")]
        public int size
        {
            get
            {
                return (_bitfield >> 2) & 0x3FFFFFFF;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFF << 2)) | ((value & 0x3FFFFFFF) << 2);
            }
        }

        public int min_distance;
    }
}
