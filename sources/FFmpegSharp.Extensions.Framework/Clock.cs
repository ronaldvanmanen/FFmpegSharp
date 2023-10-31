// Copyright (c) 2021-2023 Ronald van Manen
//
// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with FFmpegSharp; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA

using FFmpegSharp.Extensions.ComponentModel;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class Clock : ObservableObject, IClock
    {
        private AVRelativeTime _pts;

        private AVRelativeTime _ptsDrift;

        private bool _paused;

        public bool Paused
        {
            get => _paused;

            set
            {
                OnPropertyChanging();
                _paused = value;
                OnPropertyChanged();
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
                    var pts = _ptsDrift + time;
                    return pts;
                }
            }
        }

        public Clock()
        {
            _pts = AVRelativeTime.Undefined;
            _ptsDrift = AVRelativeTime.Undefined;
            _paused = false;
        }

        public void SetTimeAt(AVRelativeTime pts, AVRelativeTime time)
        {
            OnPropertyChanging(nameof(Time));
            _pts = pts;
            _ptsDrift = pts - time;
            OnPropertyChanged(nameof(Time));
        }

        public void SetTime(AVRelativeTime pts)
        {
            SetTimeAt(pts, AVRelativeTime.Current);
        }
    }
}
