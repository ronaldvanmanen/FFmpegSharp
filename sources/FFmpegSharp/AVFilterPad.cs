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
    public sealed unsafe class AVFilterPad
    {
        private readonly Interop.AVFilterPad* _pads;

        private readonly int _index;

        public unsafe AVFilterPad(Interop.AVFilterPad* pads, int index)
        {
            _pads = pads;
            _index = index;
        }

        public AVMediaType Type => (AVMediaType)avfilter_pad_get_type(_pads, _index);
    }
}
