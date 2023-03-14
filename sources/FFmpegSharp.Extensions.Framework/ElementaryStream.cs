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

using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace FFmpegSharp.Extensions.Framework
{
    public abstract class ElementaryStream<T> where T : new()
    {
        private readonly T[] _buffer;

        private readonly ManualResetEventSlim _canWrite;

        private readonly ManualResetEventSlim _canRead;

        private volatile int _writeIndex;

        private volatile int _readIndex;

        public ElementaryStream(int capacity)
        {
            _buffer = new T[capacity];
            _canWrite = new ManualResetEventSlim(true);
            _canRead = new ManualResetEventSlim(false);
            _writeIndex = 0;
            _readIndex = 0;

            for (var i = 0; i < capacity; ++i)
            {
                _buffer[i] = new T();
            }
        }

        public T PeekWritable()
        {
            return PeekWritable(CancellationToken.None);
        }

        public T PeekWritable(CancellationToken cancellationToken)
        {
            _canWrite.Wait(cancellationToken);
            var item = _buffer[_writeIndex];
            return item;
        }

        public void PushWritable(CancellationToken cancellationToken)
        {
            _canWrite.Wait(cancellationToken);
            _writeIndex = ++_writeIndex % _buffer.Length;
            if (_writeIndex == _readIndex)
            {
                _canWrite.Reset();
            }
            _canRead.Set();
        }

        public T PeekReadable()
        {
            return PeekReadable(CancellationToken.None);
        }

        public T PeekReadable(CancellationToken cancellationToken)
        {
            _canRead.Wait(cancellationToken);
            var item = _buffer[_readIndex];
            return item;
        }

        public bool TryPeekReadable([MaybeNullWhen(false)] out T item)
        {
            bool canRead = _canRead.Wait(0);
            item = canRead ? _buffer[_readIndex] : default;
            return canRead;
        }

        public void PushReadable()
        {
            PushReadable(CancellationToken.None);
        }

        public void PushReadable(CancellationToken cancellationToken)
        {
            _canRead.Wait(cancellationToken);
            _readIndex = ++_readIndex % _buffer.Length;
            if (_readIndex == _writeIndex)
            {
                _canRead.Reset();
            }
            _canWrite.Set();
        }
    }
}
