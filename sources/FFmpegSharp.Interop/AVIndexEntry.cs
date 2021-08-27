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
