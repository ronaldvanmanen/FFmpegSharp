// Copyright (c) 2021-2023 Ronald van Manen
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

using System;
using System.Collections;
using System.Collections.Generic;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVFilterPadCollection : IReadOnlyList<AVFilterPad>
    {
        private readonly Interop.AVFilterPad* _pads;

        public AVFilterPadCollection(Interop.AVFilterPad* pads)
        {
            _pads = pads;
        }

        public AVFilterPad this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "index cannot be less than zero");
                }

                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "index cannot be greater than or equal to the number of items in this collection");
                }

                return new AVFilterPad(_pads, index);
            }
        }

        public int Count => _pads != null ? avfilter_pad_count(_pads) : 0;

        public IEnumerator<AVFilterPad> GetEnumerator()
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
