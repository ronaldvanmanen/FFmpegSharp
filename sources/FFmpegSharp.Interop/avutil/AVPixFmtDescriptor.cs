// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with FFmpegSharp.  If not, see <https://www.gnu.org/licenses/>.

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

        [NativeTypeName("AVComponentDescriptor[4]")]
        public _comp_e__FixedBuffer comp;

        [NativeTypeName("const char *")]
        public sbyte* alias;

        public partial struct _comp_e__FixedBuffer
        {
            public AVComponentDescriptor e0;
            public AVComponentDescriptor e1;
            public AVComponentDescriptor e2;
            public AVComponentDescriptor e3;

            public unsafe ref AVComponentDescriptor this[int index]
            {
                get
                {
                    fixed (AVComponentDescriptor* pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }
}
