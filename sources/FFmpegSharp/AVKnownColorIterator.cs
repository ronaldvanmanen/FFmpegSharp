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

using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    internal sealed unsafe class AVKnownColorIterator
    {
        private int _index = 0;

        private AVKnownColor _current = new AVKnownColor(string.Empty, 0, 0, 0);

        public bool MoveNext()
        {
            byte* rgb;
            sbyte* name = av_get_known_color_name(_index++, &rgb);
            if (name != null)
            {
                _current = new AVKnownColor(new string(name), rgb[0], rgb[1], rgb[2]);
            }
            return name != null;
        }

        public AVKnownColor Current => _current;
    }
}
