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

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class VideoFrame : IDisposable
    {
        private readonly AVFrame _handle;

        public AVFrame Handle => _handle;

        public Span2D<byte> Data
        {
            get
            {
                unsafe
                {
                    return new Span2D<byte>(
                        _handle.Handle->data[0],
                        _handle.Width,
                        _handle.Height,
                        _handle.Handle->linesize[0]);
                }
            }
        }

        public AVPixelFormat Format => _handle.PixelFormat;

        public int Width => _handle.Width;

        public int Height => _handle.Height;

        public VideoFrame()
        : this(new AVFrame())
        { }

        public VideoFrame(AVFrame handle)
        {
            _handle = handle ?? throw new ArgumentNullException(nameof(handle));
        }

        public void Dispose()
        {
            _handle.Dispose();
        }
    }
}
