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
    public unsafe partial struct AVIODirEntry
    {
        [NativeTypeName("char *")]
        public sbyte* name;

        public int type;

        public int utf8;

        [NativeTypeName("int64_t")]
        public long size;

        [NativeTypeName("int64_t")]
        public long modification_timestamp;

        [NativeTypeName("int64_t")]
        public long access_timestamp;

        [NativeTypeName("int64_t")]
        public long status_change_timestamp;

        [NativeTypeName("int64_t")]
        public long user_id;

        [NativeTypeName("int64_t")]
        public long group_id;

        [NativeTypeName("int64_t")]
        public long filemode;
    }
}
