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

using System.Collections.Concurrent;
using System.Dynamic;
using FFmpegSharp.Extensions.ObjectPool;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class Channel<T> where T : new()
    {
        private const int Unbounded = 0;

        private readonly ChannelWriter<T> _writer;

        private readonly ChannelReader<T> _reader;

        private readonly BlockingCollection<T> _queue;

        private readonly ObjectPool<T> _pool;

        private readonly ExpandoObject _capabilities;

        public Channel()
        : this(Unbounded)
        { }

        public Channel(int boundedCapacity)
        {
            _queue = (boundedCapacity == Unbounded) ? new BlockingCollection<T>() : new BlockingCollection<T>(boundedCapacity);
            _pool = new ObjectPool<T>(() => new T());
            _writer = new ChannelWriter<T>(_queue, _pool);
            _reader = new ChannelReader<T>(_queue, _pool);
            _capabilities = new ExpandoObject();
        }

        public dynamic MetaData => _capabilities;

        public ChannelWriter<T> Writer => _writer;

        public ChannelReader<T> Reader => _reader;
    }
}
