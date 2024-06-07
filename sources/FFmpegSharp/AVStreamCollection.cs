// Copyright (C) 2021-2024 Ronald van Manen
//
// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with FFmpegSharp; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA

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
