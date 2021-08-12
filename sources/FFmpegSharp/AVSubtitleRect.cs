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
    public sealed unsafe class AVSubtitleRect
    {
        private readonly Interop.AVSubtitleRect* _handle;

        public Interop.AVSubtitleRect* Handle => _handle;

        public int X
        {
            get => _handle->x;

            set => _handle->x = value;
        }

        public int Y
        {
            get => _handle->y;

            set => _handle->y = value;
        }

        public int Width
        {
            get => _handle->w;

            set => _handle->w = value;
        }

        public int Height
        {
            get => _handle->h;

            set => _handle->h = value;
        }

        public int ColorCount => _handle->nb_colors;

        //public AVPicture pict;

        public AVSubtitleType Type => (AVSubtitleType)_handle->type;

        public string Text => new string(_handle->text);

        public string Ass => new string(_handle->ass);

        public int flags;

        public AVSubtitleRect(Interop.AVSubtitleRect* handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            _handle = handle;
        }
    }
}
