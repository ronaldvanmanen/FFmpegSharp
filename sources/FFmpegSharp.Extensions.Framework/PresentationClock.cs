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

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class PresentationClock : IPresentationClock
    {
        private IPresentationClockSource? _timeSource;

        public IPresentationClockSource? TimeSource
        {
            get => _timeSource;
            set
            {
                if (_timeSource != value)
                {
                    _timeSource = value;
                }
            }
        }

        public bool Paused
        {
            get
            {
                if (_timeSource is null)
                {
                    throw new InvalidOperationException("The clock does not have a presentation time source");
                }
                return _timeSource.Clock.Paused;
            }
        }

        public AVRelativeTime Time
        {
            get
            {
                if (_timeSource is null)
                {
                    throw new InvalidOperationException("The clock does not have a presentation time source");
                }
                return _timeSource.Clock.Time;
            }
        }
    }
}
