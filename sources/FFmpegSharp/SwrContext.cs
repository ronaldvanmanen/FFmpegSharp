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
using static FFmpegSharp.AVError;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class SwrContext : IDisposable
    {
        private readonly Interop.SwrContext* _handle;

        private readonly bool _ownsHandle;

        public SwrContext()
        : this(swr_alloc(), true)
        { }

        public SwrContext(long outputChannelLayout, AVSampleFormat outputSampleFormat, int outputSampleRate, long inputChannelLayout, AVSampleFormat inputSampleFormat, int inputSampleRate)
        : this(swr_alloc_set_opts(null, outputChannelLayout, (Interop.AVSampleFormat)outputSampleFormat, outputSampleRate, inputChannelLayout, (Interop.AVSampleFormat)inputSampleFormat, inputSampleRate, 0, null), true)
        {
            ThrowOnError(swr_init(_handle));
        }

        private SwrContext(Interop.SwrContext* handle, bool ownsHandle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
            _ownsHandle = ownsHandle;
        }

        public void Dispose()
        {
            if (_ownsHandle && _handle != null)
            {
                fixed (Interop.SwrContext** handle = &_handle)
                {
                    swr_free(handle);
                }
            }
        }

        public void Configure(AVFrame output, AVFrame input)
        {
            ThrowIfDisposed();

            ThrowOnError(
                swr_config_frame(_handle, output, input)
            );
        }

        public int Convert(AVFrame output, AVFrame input)
        {
            ThrowIfDisposed();

            var retval = swr_convert_frame(_handle, output, input);
            ThrowOnError(retval);
            return retval;
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
