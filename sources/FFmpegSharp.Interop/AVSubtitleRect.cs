namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVSubtitleRect
    {
        public int x;

        public int y;

        public int w;

        public int h;

        public int nb_colors;

        public AVPicture pict;

        [NativeTypeName("uint8_t *[4]")]
        public _data_e__FixedBuffer data;

        [NativeTypeName("int [4]")]
        public fixed int linesize[4];

        [NativeTypeName("enum AVSubtitleType")]
        public AVSubtitleType type;

        [NativeTypeName("char *")]
        public sbyte* text;

        [NativeTypeName("char *")]
        public sbyte* ass;

        public int flags;

        public unsafe partial struct _data_e__FixedBuffer
        {
            public byte* e0;
            public byte* e1;
            public byte* e2;
            public byte* e3;

            public ref byte* this[int index]
            {
                get
                {
                    fixed (byte** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }
}
