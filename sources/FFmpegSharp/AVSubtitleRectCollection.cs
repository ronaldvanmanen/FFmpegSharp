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

using System.Collections;
using System.Collections.Generic;

namespace FFmpegSharp
{
    public sealed unsafe class AVSubtitleRectCollection : IReadOnlyList<AVSubtitleRect>
    {
        private readonly Interop.AVSubtitleRect** _items;

        private readonly uint _count;

        public int Count => (int)_count;

        public AVSubtitleRectCollection(Interop.AVSubtitleRect** items, uint count)
        {
            _items = items;
            _count = count;
        }

        public AVSubtitleRect this[int index] => new AVSubtitleRect(_items[index]);

        public IEnumerator<AVSubtitleRect> GetEnumerator()
        {
            for (var index = 0; index < Count; ++index)
            {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
