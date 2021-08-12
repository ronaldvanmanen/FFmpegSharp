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
    public sealed class ExternalClock : IExternalClock
    {
        private static readonly AVRelativeTime NoSyncThreshold = new AVRelativeTime(10d);

        private AVRelativeTime _pts;

        private AVRelativeTime _ptsDrift;

        private AVRelativeTime _lastUpdated;

        private double _speed;

        private bool _paused;

        public ExternalClock()
        {
            _pts = AVRelativeTime.Undefined;
            _ptsDrift = AVRelativeTime.Undefined;
            _lastUpdated = AVRelativeTime.Undefined;
            _speed = 1d;
            _paused = false;
        }

        public bool Paused
        {
            get => _paused;

            set => _paused = value;
        }

        public double Speed
        {
            get => _speed;
            set
            {
                var time = Time;
                SetTime(time);
                _speed = value;
            }
        }

        public AVRelativeTime Time
        {
            get
            {
                if (_paused)
                {
                    return _pts;
                }
                else
                {
                    var time = AVRelativeTime.Current;
                    var pts = _ptsDrift + time - (time - _lastUpdated) * (1.0 - _speed);
                    return pts;
                }
            }
        }

        public void SetTimeAt(AVRelativeTime pts, AVRelativeTime time)
        {
            _pts = pts;
            _lastUpdated = time;
            _ptsDrift = pts - time;
        }

        public void SetTime(AVRelativeTime pts)
        {
            SetTimeAt(pts, AVRelativeTime.Current);
        }

        public void SyncTo(IClock slave)
        {
            if (slave is null)
            {
                throw new ArgumentNullException(nameof(slave));
            }

            if (!AVRelativeTime.IsUndefined(slave.Time))
            {
                if (AVRelativeTime.IsUndefined(Time) || AVRelativeTime.Abs(Time - slave.Time) > NoSyncThreshold)
                {
                    SetTime(slave.Time);
                }
            }
        }
    }
}
