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
using System.Collections.Generic;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVCodecDescriptor : IDisposable
    {
        public static IEnumerable<AVCodecDescriptor> All
        {
            get
            {
                var iterator = new AVCodecDescriptorIterator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        private readonly Interop.AVCodecDescriptor* _handle;

        private readonly bool _ownsHandle;

        public AVCodecID Id
        {
            get
            {
                ThrowIfDisposed();

                return (AVCodecID)_handle->id;
            }
        }

        public AVMediaType Type
        {
            get
            {
                ThrowIfDisposed();


                return (AVMediaType)_handle->type;
            }
        }

        public string Name
        {
            get
            {
                ThrowIfDisposed();

                return new string(_handle->name);
            }
        }

        public string LongName
        {
            get
            {
                ThrowIfDisposed();

                return new string(_handle->long_name);
            }
        }

        public AVCodecProperties Properties
        {
            get
            {
                ThrowIfDisposed();

                return (AVCodecProperties)_handle->props;
            }
        }

        public AVCodecDescriptor(Interop.AVCodecDescriptor* handle, bool ownsHandle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            _handle = handle;
            _ownsHandle = ownsHandle;
        }

        ~AVCodecDescriptor()
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
            if (_ownsHandle && _handle != null)
            {
                fixed (Interop.AVCodecDescriptor** descriptor = &_handle)
                {
                    av_free(descriptor);
                }
            }
        }

        private void ThrowIfDisposed()
        {
            if (_handle == null)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }
}
