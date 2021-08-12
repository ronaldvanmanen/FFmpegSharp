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
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using FFmpegSharp.Extensions.ObjectPool;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class ChannelReader<T>
    {
        private readonly BlockingCollection<T> _queue;

        private readonly ObjectPool<T> _pool;

        public bool IsCompleted => _queue.IsCompleted;

        internal ChannelReader(BlockingCollection<T> queue, ObjectPool<T> pool)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
            _pool = pool ?? throw new ArgumentNullException(nameof(pool));
        }

        public bool TryRead([MaybeNullWhen(false)] out T item)
        {
            return _queue.TryTake(out item);
        }

        public bool TryRead([MaybeNullWhen(false)] out T item, int millisecondsTimeout)
        {
            return _queue.TryTake(out item, millisecondsTimeout);
        }

        public bool TryRead([MaybeNullWhen(false)] out T item, int millisecondsTimeout, CancellationToken cancellationToken)
        {
            return _queue.TryTake(out item, millisecondsTimeout, cancellationToken);
        }

        public T Read()
        {
            return _queue.Take();
        }

        public T Read(CancellationToken cancellationToken)
        {
            return _queue.Take(cancellationToken);
        }

        public void Return(T item)
        {
            _pool.Return(item);
        }
    }
}
