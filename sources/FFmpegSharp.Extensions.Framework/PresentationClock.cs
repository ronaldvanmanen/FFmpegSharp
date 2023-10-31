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

using System;
using System.ComponentModel;
using FFmpegSharp.Extensions.ComponentModel;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class PresentationClock : ObservableObject, IPresentationClock
    {
        private IPresentationClockSource? _timeSource;

        public IPresentationClockSource? TimeSource
        {
            get => _timeSource;
            set
            {
                if (_timeSource == value)
                {
                    return;
                }

                OnPropertyChanging();
                UnregisterEventHandlers();
                _timeSource = value;
                RegisterEventHandlers();
                OnPropertyChanged();
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

        private void RegisterEventHandlers()
        {
            if (_timeSource is not null)
            {
                if (_timeSource.Clock is not null)
                {
                    _timeSource.Clock.PropertyChanging += TimeSourceClockPropertyChanging;
                    _timeSource.Clock.PropertyChanged += TimeSourceClockPropertyChanged;
                }

                _timeSource.PropertyChanging += TimeSourcePropertyChanging;
                _timeSource.PropertyChanged += TimeSourcePropertyChanged;
            }
        }

        private void UnregisterEventHandlers()
        {
            if (_timeSource is not null)
            {
                if (_timeSource.Clock is not null)
                {
                    _timeSource.Clock.PropertyChanging -= TimeSourceClockPropertyChanging;
                    _timeSource.Clock.PropertyChanged -= TimeSourceClockPropertyChanged;
                }

                _timeSource.PropertyChanging -= TimeSourcePropertyChanging;
                _timeSource.PropertyChanged -= TimeSourcePropertyChanged;
            }
        }

        private void TimeSourcePropertyChanging(object? sender, PropertyChangingEventArgs e)
        {
            if (sender is IPresentationClockSource timeSource)
            {
                if (e.PropertyName == nameof(IPresentationClockSource.Clock))
                {
                    timeSource.Clock.PropertyChanged -= TimeSourceClockPropertyChanged;
                }
            }
        }

        private void TimeSourcePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is IPresentationClockSource timeSource)
            {
                if (e.PropertyName == nameof(IPresentationClockSource.Clock))
                {
                    timeSource.Clock.PropertyChanged += TimeSourceClockPropertyChanged;
                }
            }
        }

        private void TimeSourceClockPropertyChanging(object? sender, PropertyChangingEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IClock.Time):
                    OnPropertyChanging(nameof(Time));
                    return;

                case nameof(IClock.Paused):
                    OnPropertyChanging(nameof(Paused));
                    return;
            }
        }

        private void TimeSourceClockPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IClock.Time):
                    OnPropertyChanged(nameof(Time));
                    return;

                case nameof(IClock.Paused):
                    OnPropertyChanged(nameof(Paused));
                    return;
            }
        }
    }
}
