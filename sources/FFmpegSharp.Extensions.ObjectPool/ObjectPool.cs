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

namespace FFmpegSharp.Extensions.ObjectPool
{
    public sealed class ObjectPool<T>
    {
        private readonly IProducerConsumerCollection<T> _objectCollection;

        private readonly Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        : this(objectGenerator, new ConcurrentQueue<T>())
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
            _objectCollection = new ConcurrentQueue<T>();
        }

        public ObjectPool(Func<T> objectGenerator, IProducerConsumerCollection<T> objectCollection)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
            _objectCollection = objectCollection ?? throw new ArgumentNullException(nameof(objectCollection));
        }

        public T Get()
        {
            if (_objectCollection.TryTake(out var item))
            {
                return item;
            }
            return _objectGenerator();
        }

        public void Return(T item)
        {
            while (!_objectCollection.TryAdd(item)) { };
        }
    }
}
