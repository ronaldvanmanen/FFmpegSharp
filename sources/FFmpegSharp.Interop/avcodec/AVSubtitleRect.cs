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
