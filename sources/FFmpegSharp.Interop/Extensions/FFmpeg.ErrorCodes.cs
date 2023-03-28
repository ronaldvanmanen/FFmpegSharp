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

using static FFmpegSharp.Interop.Std;

namespace FFmpegSharp.Interop
{
    public static unsafe partial class FFmpeg
    {
        public static readonly int AVERROR_EOF = FFERRTAG('E', 'O', 'F', ' ');

        public static readonly int AVERROR_STREAM_NOT_FOUND = FFERRTAG(0xF8, 'S', 'T', 'R');

        public static readonly int AVERROR_EAGAIN = AVERROR(EAGAIN);

        public static int FFERRTAG(uint a, uint b, uint c, uint d) => (-(int)MKTAG(a, b, c, d));

        public static uint MKTAG(uint a, uint b, uint c, uint d) => (a & 0xFF) | ((b & 0xFF) << 8) | ((c & 0xFF) << 16) | ((d & 0xFF) << 24);

        public static int AVERROR(int e) => -e;
    }
}
