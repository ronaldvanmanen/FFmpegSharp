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
using System.Threading;

namespace FFmpegSharp.Extensions.Collections
{
    public sealed class CircularBuffer<T> : IEnumerable<T>, ICollection
    {
        public struct Enumerator : IEnumerator<T>
        {
            private readonly CircularBuffer<T> _buffer;

            private int _index;

            internal Enumerator(CircularBuffer<T> buffer)
            {
                if (buffer == null)
                    throw new ArgumentNullException(nameof(buffer));
                _buffer = buffer;
                _index = 0;
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                ++_index;

                return _index < _buffer.Count;
            }

            public void Reset()
            {
                _index = 0;
            }

            public T Current
            {
                get { return _buffer[_index]; }
            }

            object IEnumerator.Current
            {
                get { return _buffer[_index]!; }
            }
        }

        private readonly int _capacity;

        private int _size;

        private int _head;

        private int _tail;

        private bool _allowOverflow;

        private readonly T[] _elements;

        private object _syncRoot;

        public CircularBuffer(int capacity, bool allowOverflow)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(capacity), "cannot be less than or equal to zero");

            _capacity = capacity;
            _size = 0;
            _head = 0;
            _tail = 0;
            _allowOverflow = allowOverflow;
            _elements = new T[capacity];
            _syncRoot = null!;
        }

        public void Enqueue(T element)
        {
            if (_size == _capacity)
            {
                if (!_allowOverflow)
                    throw new InvalidOperationException(
                        "The circular buffer is not allowed to overflow.");

                _elements[_tail] = element;
                ++_tail;
                _tail %= _capacity;
                _head = _tail;
            }
            else
            {
                _elements[_tail] = element;
                ++_tail;
                _tail %= _capacity;
                ++_size;
            }
        }

        public void Enqueue(Span<T> span)
        {
            for (var i = 0; i < span.Length; ++i)
            {
                if (_size == _capacity)
                {
                    if (!_allowOverflow)
                    {
                        break;
                    }

                    _elements[_tail] = span[i];
                    ++_tail;
                    _tail %= _capacity;
                    _head = _tail;
                }
                else
                {
                    _elements[_tail] = span[i];
                    ++_tail;
                    _tail %= _capacity;
                    ++_size;
                }
            }
        }

        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException(
                    "The circular buffer is empty.");

            var element = _elements[_head];
            ++_head;
            _head %= _capacity;
            --_size;
            return element;
        }

        public void Dequeue(Span<T> span)
        {
            for (var index = 0; index < span.Length; ++index)
            {
                if (_size == 0)
                {
                    break;
                }

                span[index] = _elements[_head];
                ++_head;
                _head %= _capacity;
                --_size;
            }
        }

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = 0;
        }

        public bool Contains(T item)
        {
            var bufferIndex = _head;
            for (var i = 0; i < _size; ++i, bufferIndex = (bufferIndex + 1) % _capacity)
                if (_elements[bufferIndex]!.Equals(item))
                    return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(
                    nameof(array), "The array cannot be null.");

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(arrayIndex), "The array index is less than zero.");

            if (arrayIndex + _size > array.Length)
                throw new ArgumentException(
                    "The number of elements in the circular buffer is greater " +
                    "than the available space from the array index to the end " +
                    "of the array.");

            var bufferIndex = _head;
            for (var i = 0; i < _size; ++i)
            {
                array[arrayIndex] = _elements[bufferIndex];
                ++bufferIndex;
                bufferIndex %= _capacity;
                ++arrayIndex;
            }
        }

        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(
                    nameof(array), "The array cannot be null.");

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(arrayIndex), "The array index is less than zero.");

            if (arrayIndex + _size > array.Length)
                throw new ArgumentException(
                    "The number of elements in the circular buffer is greater " +
                    "than the available space from the array index to the end " +
                    "of the array.");

            var bufferIndex = _head;
            for (var i = 0; i < _size; ++i)
            {
                array.SetValue(_elements[bufferIndex], arrayIndex);
                ++bufferIndex;
                bufferIndex %= _capacity;
                ++arrayIndex;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                    throw new ArgumentOutOfRangeException(
                        nameof(index), "The index is not valid.");

                var bufferIndex = _head + index;
                bufferIndex %= _capacity;
                return _elements[bufferIndex];
            }
        }

        public int Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public bool AllowOverflow
        {
            set
            {
                _allowOverflow = value;
            }
            get
            {
                return _allowOverflow;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    Interlocked.CompareExchange<object>(ref _syncRoot!, new object(), null!);
                }
                return _syncRoot;
            }
        }
    }
}
