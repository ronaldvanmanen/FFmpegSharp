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

using System;
using System.Collections.Concurrent;
using System.Threading;
using FFmpegSharp.Extensions.ObjectPool;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class ChannelWriter<T>
    {
        private readonly BlockingCollection<T> _queue;

        private readonly ObjectPool<T> _pool;

        internal ChannelWriter(BlockingCollection<T> queue, ObjectPool<T> pool)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
            _pool = pool ?? throw new ArgumentNullException(nameof(pool));
        }

        public void Complete()
        {
            _queue.CompleteAdding();
        }

        public void Write(T item)
        {
            _queue.Add(item);
        }

        public void Write(T item, CancellationToken cancellationToken)
        {
            _queue.Add(item, cancellationToken);
        }

        public T Get()
        {
            return _pool.Get();
        }
    }
}
