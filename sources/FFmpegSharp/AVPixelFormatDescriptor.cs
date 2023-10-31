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
using System.Collections.Generic;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe partial class AVPixelFormatDescriptor : IDisposable
    {

        public static IEnumerable<AVPixelFormatDescriptor> All
        {
            get
            {
                var iterator = new AVPixelFormatDescriptorIterator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        private readonly Interop.AVPixFmtDescriptor* _handle;

        public string Name => new(_handle->name);

        public int BitsPerPixel => av_get_bits_per_pixel(_handle);

        public int ComponentsPerPixel => _handle->nb_components;

        public AVPixelFormatFlags Flags => (AVPixelFormatFlags)_handle->flags;

        public AVPixelFormat PixelFormat => (AVPixelFormat)av_pix_fmt_desc_get_id(_handle);

        public AVPixelFormatDescriptor(Interop.AVPixFmtDescriptor* handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            _handle = handle;
        }

        ~AVPixelFormatDescriptor()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_handle != null)
            {
                fixed (Interop.AVPixFmtDescriptor** descriptor = &_handle)
                {
                    av_free(descriptor);
                }
            }
        }
    }
}
