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
    public sealed unsafe class AVStreamCollection : IReadOnlyList<AVStream>
    {
        private readonly AVStream[] _streams;

        public AVStream this[int index] => _streams[index];

        public int Count => _streams.Length;

        public unsafe AVStreamCollection(Interop.AVStream** streams, uint count)
        {
            _streams = new AVStream[count];

            for (var index = 0; index < count; ++index)
            {
                _streams[index] = new AVStream(streams[index]);
            }
        }

        public IEnumerator<AVStream> GetEnumerator()
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
