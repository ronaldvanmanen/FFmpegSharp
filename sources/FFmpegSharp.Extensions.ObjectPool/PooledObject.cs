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

namespace FFmpegSharp.Extensions.ObjectPool
{
    public sealed class PooledObject<T> : IDisposable where T : class
    {
        private readonly ObjectPool<T> _pool;

        private T _instance;

        private bool _disposed;

        public ref T Instance
        {
            get
            {
                ThrowIfDisposed();

                return ref _instance;
            }
        }

        internal PooledObject(ObjectPool<T> pool)
        {
            _pool = pool ?? throw new ArgumentNullException(nameof(pool));
            _instance = pool.Allocate();
            _disposed = false;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _pool.Free(_instance);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }

    public static class PooledObject
    {
        public static PooledObject<T> Allocate<T>(ObjectPool<T> pool) where T : class
        {
            return new PooledObject<T>(pool);
        }
    }
}
