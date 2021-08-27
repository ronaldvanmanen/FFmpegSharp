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
    public unsafe partial struct AVSubtitle
    {
        [NativeTypeName("uint16_t")]
        public ushort format;

        [NativeTypeName("uint32_t")]
        public uint start_display_time;

        [NativeTypeName("uint32_t")]
        public uint end_display_time;

        [NativeTypeName("unsigned int")]
        public uint num_rects;

        public AVSubtitleRect** rects;

        [NativeTypeName("int64_t")]
        public long pts;
    }

    public partial struct AVSubtitle
    {
    }
}
