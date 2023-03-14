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
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVCodecParameters : IDisposable
    {
        private readonly Interop.AVCodecParameters* _handle;

        private readonly bool _ownsHandle;

        public AVCodecParameters()
        : this(avcodec_parameters_alloc(), true)
        { }

        public AVCodecParameters(AVCodecParameters other)
        : this(avcodec_parameters_alloc(), true)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            AVError.ThrowOnError(
                avcodec_parameters_copy(_handle, other._handle)
            );
        }

        public AVCodecParameters(Interop.AVCodecParameters* handle, bool ownsHandle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
            _ownsHandle = ownsHandle;
        }

        ~AVCodecParameters()
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
                fixed (Interop.AVCodecParameters** handle = &_handle)
                {
                    avcodec_parameters_free(handle);
                }
            }
        }

        public AVCodecID CodecID => (AVCodecID)_handle->codec_id;

        public AVMediaType CodecType => (AVMediaType)_handle->codec_type;

        public static implicit operator Interop.AVCodecParameters*(AVCodecParameters value)
        {
            return value._handle;
        }
    }
}
