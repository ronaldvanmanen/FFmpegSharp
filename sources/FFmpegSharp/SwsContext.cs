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
using Microsoft.Toolkit.HighPerformance;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class SwsContext : IDisposable
    {
        private Interop.SwsContext* _handle;

        private readonly bool _ownsHandle;

        public static SwsContext GetCachedContext(
            SwsContext context,
            int sourceWidth, int sourceHeight, AVPixelFormat sourceFormat,
            int targetWidth, int targetHeight, AVPixelFormat targetFormat,
            SwsFlags flags)
        {
            if (context == null)
            {
                var handle = sws_getCachedContext(null,
                    sourceWidth, sourceHeight, (Interop.AVPixelFormat)sourceFormat,
                    targetWidth, targetHeight, (Interop.AVPixelFormat)targetFormat,
                    (int)flags, null, null, null);
                return new SwsContext(handle, true);
            }
            else
            {
                context._handle = sws_getCachedContext(context._handle,
                    sourceWidth, sourceHeight, (Interop.AVPixelFormat)sourceFormat,
                    targetWidth, targetHeight, (Interop.AVPixelFormat)targetFormat,
                    (int)flags, null, null, null);
                return context;
            }
        }

        public SwsContext(Interop.SwsContext* handle, bool ownsHandle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            _handle = handle;
            _ownsHandle = ownsHandle;
        }

        ~SwsContext()
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
                sws_freeContext(_handle);
                _handle = null;
            }
        }

        //public void Scale(Span2D<byte> source, Span2D<byte> target)
        //{
        //    fixed (byte* srcSlice = source)
        //    {
        //        fixed (byte* dst = target)
        //        {
        //            sws_scale(_handle, &srcSlice, , 0, source.Height, &dst, target.  );
        //        }
        //    }
        //}

        public static implicit operator Interop.SwsContext*(SwsContext value)
        {
            return value._handle;
        }
    }
}
