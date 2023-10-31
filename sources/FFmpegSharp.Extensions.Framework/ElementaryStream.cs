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

using System.Collections.Concurrent;
using System.Threading;

namespace FFmpegSharp.Extensions.Framework
{
    public abstract class ElementaryStream<T>
    {
        private readonly BlockingCollection<T> _samples;

        public ElementaryStream(int bufferSize)
        {
            _samples = new BlockingCollection<T>(bufferSize);
        }

        public void Write(T sample, CancellationToken cancellationToken)
        {
            _samples.Add(sample, cancellationToken);
        }

        public T Read(CancellationToken cancellationToken)
        {
            return _samples.Take(cancellationToken);
        }
    }
}
