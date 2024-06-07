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

using System;
using System.Collections;
using System.Collections.Generic;
using FFmpegSharp.Internals;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVDictionary : IDictionary<string, string>, IDisposable
    {
        private sealed class KeyCollection : ICollection<string>
        {
            private readonly AVDictionary _dictionary;

            public int Count => _dictionary.Count;

            public bool IsReadOnly => true;

            public KeyCollection(AVDictionary dictionary)
            {
                _dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
            }

            public bool Contains(string item)
            {
                return _dictionary.ContainsKey(item);
            }

            public void Add(string item)
            {
                throw new NotSupportedException();
            }

            public bool Remove(string item)
            {
                throw new NotSupportedException();
            }

            public void Clear()
            {
                throw new NotSupportedException();
            }

            public void CopyTo(string[] array, int arrayIndex)
            {
                if (array is null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                if (array.Rank != 1)
                {
                    throw new ArgumentException("Multi-dimensional arrays are not supported", nameof(array));
                }

                if (array.GetLowerBound(0) != 0)
                {
                    throw new ArgumentException("Arrays with a non-zero lower bound are not supported", nameof(array));
                }

                if (arrayIndex < 0 || arrayIndex > array.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, "The array index must be non-negative and less than the size of the array");
                }

                if (array.Length - arrayIndex < Count)
                {
                    throw new ArgumentException("Array is too small");
                }

                var enumerator = GetEnumerator();
                while (arrayIndex < array.Length && enumerator.MoveNext())
                {
                    array[arrayIndex++] = enumerator.Current;
                }
            }

            public IEnumerator<string> GetEnumerator()
            {
                var enumerator = _dictionary.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current.Key;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private sealed class ValueCollection : ICollection<string>
        {
            private readonly AVDictionary _dictionary;

            public int Count => _dictionary.Count;

            public bool IsReadOnly => true;

            public ValueCollection(AVDictionary dictionary)
            {
                _dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
            }

            public bool Contains(string item)
            {
                return _dictionary.ContainsValue(item);
            }

            public void Add(string item)
            {
                throw new NotSupportedException();
            }

            public bool Remove(string item)
            {
                throw new NotSupportedException();
            }

            public void Clear()
            {
                throw new NotSupportedException();
            }

            public void CopyTo(string[] array, int arrayIndex)
            {
                if (array is null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                if (array.Rank != 1)
                {
                    throw new ArgumentException("Multi-dimensional arrays are not supported", nameof(array));
                }

                if (array.GetLowerBound(0) != 0)
                {
                    throw new ArgumentException("Arrays with a non-zero lower bound are not supported", nameof(array));
                }

                if (arrayIndex < 0 || arrayIndex > array.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, "The array index must be non-negative and less than the size of the array");
                }

                if (array.Length - arrayIndex < Count)
                {
                    throw new ArgumentException("Array is too small");
                }

                var enumerator = GetEnumerator();
                while (arrayIndex < array.Length && enumerator.MoveNext())
                {
                    array[arrayIndex++] = enumerator.Current;
                }
            }

            public IEnumerator<string> GetEnumerator()
            {
                var enumerator = _dictionary.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current.Value;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private readonly Interop.AVDictionary* _handle;

        private KeyCollection _keys = null!;

        private ValueCollection _values = null!;

        private bool _disposed;

        public Interop.AVDictionary* Handle => _handle;

        public string this[string key]
        {
            get
            {
                ThrowIfDisposed();

                using var marshaledKey = new MarshaledString(key);
                var entry = av_dict_get(_handle, marshaledKey, null, 0);
                var value = new string(entry->value);
                return value;
            }
            set
            {
                ThrowIfDisposed();

                fixed (Interop.AVDictionary** handle = &_handle)
                {
                    using var marshaledKey = new MarshaledString(key);
                    using var marshaledValue = new MarshaledString(value);
                    AVError.ThrowOnError(
                        av_dict_set(handle, marshaledKey, marshaledValue, 0)
                    );
                }
            }
        }

        public ICollection<string> Keys
        {
            get
            {
                ThrowIfDisposed();

                return _keys ??= new KeyCollection(this);
            }
        }

        public ICollection<string> Values
        {
            get
            {
                ThrowIfDisposed();

                return _values ??= new ValueCollection(this);
            }
        }

        public int Count => _handle != null ? av_dict_count(_handle) : 0;

        public bool IsReadOnly => false;

        public AVDictionary()
        {
            _handle = null;
            _disposed = false;
        }

        public AVDictionary(AVDictionary other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            fixed (Interop.AVDictionary** handle = &_handle)
            {
                AVError.ThrowOnError(
                  av_dict_copy(handle, other.Handle, 0)
                );
            }

            _disposed = false;
        }

        public AVDictionary(Interop.AVDictionary* handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
            _disposed = false;
        }

        ~AVDictionary()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool _)
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                Clear();
            }
            finally
            {
                _disposed = true;
            }
        }

        public bool TryGetValue(string key, out string value)
        {
            ThrowIfDisposed();

            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var marshaledKey = new MarshaledString(key);
            var entry = av_dict_get(_handle, marshaledKey, null, AV_DICT_MATCH_CASE);
            if (entry == null)
            {
                value = null!;
                return false;
            }
            value = new string(entry->value);
            return true;
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            ThrowIfDisposed();

            using var marshaledKey = new MarshaledString(item.Key);
            var entry = av_dict_get(_handle, marshaledKey, null, AV_DICT_MATCH_CASE);
            if (entry == null)
            {
                return false;
            }
            var value = new string(entry->value);
            var result = value.Equals(item.Value);
            return result;
        }

        public bool ContainsKey(string key)
        {
            ThrowIfDisposed();

            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var marshaledKey = new MarshaledString(key);
            var entry = av_dict_get(_handle, marshaledKey, null, AV_DICT_MATCH_CASE);
            return null != entry;
        }

        public bool ContainsValue(string value)
        {
            ThrowIfDisposed();

            var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Value == value)
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(string key, string value)
        {
            ThrowIfDisposed();

            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var marshaledKey = new MarshaledString(key);
            var entry = av_dict_get(_handle, marshaledKey, null, AV_DICT_MATCH_CASE | AV_DICT_DONT_OVERWRITE);
            if (entry != null)
            {
                throw new ArgumentException($"An item with the specified key '{key}' already exists", nameof(key));
            }

            fixed (Interop.AVDictionary** dictionary = &_handle)
            {
                using var marshaledValue = new MarshaledString(value);
                AVError.ThrowOnError(
                    av_dict_set(dictionary, marshaledKey, marshaledValue, AV_DICT_MATCH_CASE | AV_DICT_DONT_OVERWRITE)
                );
            }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            Add(item.Key, item.Value);
        }

        public bool Remove(string key)
        {
            ThrowIfDisposed();

            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            fixed (Interop.AVDictionary** dictionary = &_handle)
            {
                using var marshaledKey = new MarshaledString(key);
                var result = av_dict_set(dictionary, marshaledKey, null, AV_DICT_MATCH_CASE);
                return result >= 0;
            }
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            if (Contains(item))
            {
                return Remove(item.Key);
            }

            return false;
        }

        public void Clear()
        {
            ThrowIfDisposed();

            if (_handle != null)
            {
                fixed (Interop.AVDictionary** dictionary = &_handle)
                {
                    av_dict_free(dictionary);
                }
            }
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ThrowIfDisposed();

            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("Multi-dimensional arrays are not supported", nameof(array));
            }

            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("Arrays with a non-zero lower bound are not supported", nameof(array));
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, "The array index must be non-negative and less than the size of the array");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Array is too small");
            }

            var enumerator = GetEnumerator();
            while (arrayIndex < array.Length && enumerator.MoveNext())
            {
                array[arrayIndex++] = enumerator.Current;
            }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            ThrowIfDisposed();

            var iterator = new AVDictionaryIterator(_handle);
            var enumerator = new AVDictionaryEnumerator(iterator);
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        public static implicit operator Interop.AVDictionary*(AVDictionary value)
        {
            return value._handle;
        }
    }
}
