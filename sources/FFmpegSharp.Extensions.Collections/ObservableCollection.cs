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

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FFmpegSharp.Extensions.Collections
{
    public sealed class ObservableCollection<T> : IObservableCollection<T>
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged
        {
            add
            {
                _implementation.CollectionChanged += value;
            }

            remove
            {
                _implementation.CollectionChanged -= value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)_implementation).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)_implementation).PropertyChanged += value;
            }
        }


        private readonly System.Collections.ObjectModel.ObservableCollection<T> _implementation = new();

        public int Count => _implementation.Count;

        bool ICollection<T>.IsReadOnly => ((ICollection<T>)_implementation).IsReadOnly;

        public void Add(T item)
        {
            _implementation.Add(item);
        }

        public bool Remove(T item)
        {
            return _implementation.Remove(item);
        }

        public void Clear()
        {
            _implementation.Clear();
        }

        public bool Contains(T item)
        {
            return _implementation.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _implementation.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _implementation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
