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
using System.Collections.Concurrent;

namespace FFmpegSharp.Extensions.ObjectPool
{
    public sealed class ObjectPool<T> where T : class
    {
        private readonly ConcurrentBag<T> _instances;

        private readonly Func<T> _factory;

        public ObjectPool(Func<T> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _instances = new ConcurrentBag<T>();
        }

        public T Allocate()
        {
            if (!_instances.TryTake(out var instance))
            {
                instance = _factory();
            }
            return instance;
        }

        public void Free(T instance)
        {
            _instances.Add(instance);
        }
    }
}
