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
    public sealed unsafe class AVSubtitle : IDisposable
    {
        private Interop.AVSubtitle _handle;

        public ref Interop.AVSubtitle Handle => ref _handle;

        public AVSubtitleRectCollection Rectangles => new AVSubtitleRectCollection(_handle.rects, _handle.num_rects);

        public AVTimeStamp Pts => new AVTimeStamp(_handle.pts);

        public AVRelativeTime StartDisplayTime => AVRelativeTime.FromMilliSeconds(_handle.start_display_time);

        public AVRelativeTime EndDisplayTime => AVRelativeTime.FromMilliSeconds(_handle.end_display_time);

        public AVSubtitle()
        {
            _handle = new Interop.AVSubtitle();
        }

        ~AVSubtitle()
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
            fixed (Interop.AVSubtitle* handle = &_handle)
            {
                avsubtitle_free(handle);
            }
        }
    }
}
