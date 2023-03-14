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

namespace FFmpegSharp
{
    public sealed unsafe class AVStream
    {
        private readonly Interop.AVStream* _handle;

        private AVCodecParameters _codecParameters;

        public AVCodecParameters CodecParameters =>
            _codecParameters ??= new AVCodecParameters(_handle->codecpar, false);

        public AVDiscard Discard
        {
            get => (AVDiscard)_handle->discard;

            set => _handle->discard = (Interop.AVDiscard)value;
        }

        public AVTimeBase TimeBase => new(_handle->time_base);

        public AVStream(Interop.AVStream* handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
            _codecParameters = null!;
        }

        public static implicit operator Interop.AVStream*(AVStream value)
        {
            return value._handle;
        }
    }
}
