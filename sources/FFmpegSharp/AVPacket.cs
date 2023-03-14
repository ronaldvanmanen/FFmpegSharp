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
    public readonly unsafe struct AVPacket : IDisposable
    {
        public static readonly AVPacket Null = new();

        private readonly Interop.AVPacket* _handle;

        private readonly bool _ownsHandle;

        public int StreamIndex => _handle->stream_index;

        public AVPacket()
        : this(av_packet_alloc(), true)
        { }

        public AVPacket(Interop.AVPacket* handle, bool ownsHandle)
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
                fixed (Interop.AVPacket** handle = &_handle)
                {
                    av_packet_free(handle);
                }
            }
        }

        public void Ref(AVPacket source)
        {
            AVError.ThrowOnError(
                av_packet_ref(_handle, source._handle)
            );
        }

        public void MoveRef(ref AVPacket destination)
        {
            av_packet_move_ref(destination._handle, _handle);
        }

        public void Unref()
        {
            av_packet_unref(_handle);
        }

        public static implicit operator Interop.AVPacket*(AVPacket value)
        {
            return value._handle;
        }
    }
}
