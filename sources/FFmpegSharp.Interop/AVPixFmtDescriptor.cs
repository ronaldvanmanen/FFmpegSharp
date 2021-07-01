using System;
using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVPixFmtDescriptor
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("uint8_t")]
        public byte nb_components;

        [NativeTypeName("uint8_t")]
        public byte log2_chroma_w;

        [NativeTypeName("uint8_t")]
        public byte log2_chroma_h;

        [NativeTypeName("uint64_t")]
        public ulong flags;

        [NativeTypeName("AVComponentDescriptor [4]")]
        public _comp_e__FixedBuffer comp;

        [NativeTypeName("const char *")]
        public sbyte* alias;

        public partial struct _comp_e__FixedBuffer
        {
            public AVComponentDescriptor e0;
            public AVComponentDescriptor e1;
            public AVComponentDescriptor e2;
            public AVComponentDescriptor e3;

            public ref AVComponentDescriptor this[int index]
            {
                get
                {
                    return ref AsSpan()[index];
                }
            }

            public Span<AVComponentDescriptor> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 4);
        }
    }
}
