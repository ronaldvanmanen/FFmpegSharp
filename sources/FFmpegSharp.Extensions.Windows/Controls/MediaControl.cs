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

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FFmpegSharp.Extensions.Windows.Media;
using MediaCommands = FFmpegSharp.Extensions.Windows.Input.MediaCommands;

namespace FFmpegSharp.Extensions.Windows.Controls
{
    public sealed class MediaControl : Control
    {
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached(
                nameof(Source),
                typeof(string),
                typeof(MediaControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, SourcePropertyChanged));

        public static readonly DependencyProperty StartTimeProperty =
            DependencyProperty.RegisterAttached(
                nameof(StartTime),
                typeof(AVRelativeTime),
                typeof(MediaControl),
                new FrameworkPropertyMetadata(AVRelativeTime.Undefined, FrameworkPropertyMetadataOptions.None));

        public static readonly DependencyProperty EndTimeProperty =
            DependencyProperty.RegisterAttached(
                nameof(EndTime),
                typeof(AVRelativeTime),
                typeof(MediaControl),
                new FrameworkPropertyMetadata(AVRelativeTime.Undefined, FrameworkPropertyMetadataOptions.None));

        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.RegisterAttached(
                nameof(Position),
                typeof(AVRelativeTime),
                typeof(MediaControl),
                new FrameworkPropertyMetadata(AVRelativeTime.Undefined, FrameworkPropertyMetadataOptions.None));

        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.RegisterAttached(
                nameof(Volume),
                typeof(double),
                typeof(MediaControl),
                new FrameworkPropertyMetadata(0.5d, FrameworkPropertyMetadataOptions.None, VolumePropertyChanged));

        public static readonly DependencyProperty IsMutedProperty =
            DependencyProperty.RegisterAttached(
                nameof(IsMuted),
                typeof(bool),
                typeof(MediaControl),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None, IsMutedChanged));

        private MediaPlayer? _mediaPlayer;

        public string Source
        {
            get => (string)GetValue(SourceProperty);

            set => SetValue(SourceProperty, value);
        }

        public AVRelativeTime StartTime
        {
            get => (AVRelativeTime)GetValue(StartTimeProperty);

            private set => SetValue(StartTimeProperty, value);
        }

        public AVRelativeTime EndTime
        {
            get => (AVRelativeTime)GetValue(EndTimeProperty);

            private set => SetValue(EndTimeProperty, value);
        }

        public AVRelativeTime Position
        {
            get => (AVRelativeTime)GetValue(PositionProperty);

            private set => SetValue(PositionProperty, value);
        }

        public double Volume
        {
            get => (double)GetValue(VolumeProperty);

            set => SetValue(VolumeProperty, value);
        }

        public bool IsMuted
        {
            get => (bool)GetValue(IsMutedProperty);

            set => SetValue(IsMutedProperty, value);
        }

        public bool CanPlay => Source is not null;

        public bool CanStop => _mediaPlayer is not null;

        public bool CanPause => _mediaPlayer is not null;

        public bool CanStepForward => _mediaPlayer is not null;

        public bool CanStepBackward => _mediaPlayer is not null;

        public bool CanFastForward => _mediaPlayer is not null;

        public bool CanFastBackward => _mediaPlayer is not null;

        public bool CanMuteVolume => _mediaPlayer is not null;

        public bool CanIncreaseVolume => _mediaPlayer is not null;

        public bool CanDecreaseVolume => _mediaPlayer is not null;

        static MediaControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MediaControl), new FrameworkPropertyMetadata(typeof(MediaControl)));

            CommandManager.RegisterClassCommandBinding(typeof(MediaControl), new CommandBinding(MediaCommands.Play, ExecutePlay, CanExecutePlay));
            CommandManager.RegisterClassCommandBinding(typeof(MediaControl), new CommandBinding(MediaCommands.Stop, ExecuteStop, CanExecuteStop));
            CommandManager.RegisterClassCommandBinding(typeof(MediaControl), new CommandBinding(MediaCommands.Pause, ExecutePause, CanExecutePause));
            CommandManager.RegisterClassCommandBinding(typeof(MediaControl), new CommandBinding(MediaCommands.StepForward, ExecuteStepForward, CanExecuteStepForward));
            CommandManager.RegisterClassCommandBinding(typeof(MediaControl), new CommandBinding(MediaCommands.StepBackward, ExecuteStepBackward, CanExecuteStepBackward));
            CommandManager.RegisterClassCommandBinding(typeof(MediaControl), new CommandBinding(MediaCommands.FastForward, ExecuteFastForward, CanExecuteFastForward));
            CommandManager.RegisterClassCommandBinding(typeof(MediaControl), new CommandBinding(MediaCommands.FastBackward, ExecuteFastBackward, CanExecuteFastBackward));
            CommandManager.RegisterClassCommandBinding(typeof(MediaControl), new CommandBinding(MediaCommands.MuteVolume, ExecuteMuteVolume, CanExecuteMuteVolume));
            CommandManager.RegisterClassCommandBinding(typeof(MediaControl), new CommandBinding(MediaCommands.IncreaseVolume, ExecuteIncreaseVolume, CanExecuteIncreaseVolume));
            CommandManager.RegisterClassCommandBinding(typeof(MediaControl), new CommandBinding(MediaCommands.DecreaseVolume, ExecuteDecreaseVolume, CanExecuteDecreaseVolume));
        }

        public MediaControl()
        {
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        public void Play()
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Play();
            }
            else
            {
                if (Source is not null)
                {
                    _mediaPlayer = new MediaPlayer(Source);
                    _mediaPlayer.PropertyChanged += OnMediaPlayerPropertyChanged;
                    _mediaPlayer.Play();
                }
            }
        }

        public void Stop()
        {
            if (_mediaPlayer is null)
            {
                return;
            }

            _mediaPlayer.Stop();
            _mediaPlayer.PropertyChanged -= OnMediaPlayerPropertyChanged;
            _mediaPlayer.Dispose();
            _mediaPlayer = null!;
        }

        public void Pause()
        {
            _mediaPlayer?.Pause();
        }

        public void StepForward()
        {
        }

        public void StepBackward()
        {
        }

        public void FastForward()
        {
        }

        public void FastBackward()
        {
        }

        public void MuteVolume()
        {
            IsMuted = !IsMuted;
        }

        public void IncreaseVolume()
        {
            Volume += 0.05d;
        }

        public void DecreaseVolume()
        {
            Volume -= 0.05d;
        }

        private void SetVolume(double volume)
        {
            var mediaPlayer = _mediaPlayer;
            if (mediaPlayer is not null)
            {
                mediaPlayer.Volume = volume;
            }
        }

        private void SetIsMuted(bool muted)
        {
            var mediaPlayer = _mediaPlayer;
            if (mediaPlayer is not null)
            {
                mediaPlayer.IsMuted = muted;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs eventArgs)
        {
            var window = Window.GetWindow(this);
            if (window is not null)
            {
                window.Closing += OnClosing;
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs eventArgs)
        {
            var window = Window.GetWindow(this);
            if (window is not null)
            {
                window.Closing -= OnClosing;
            }
        }

        private void OnClosing(object? sender, CancelEventArgs eventArgs)
        {
            Stop();
        }

        private void OnMediaPlayerPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is not MediaPlayer mediaPlayer)
            {
                return;
            }

            var startTime = mediaPlayer.StartTime;
            var endTime = mediaPlayer.EndTime;
            var position = mediaPlayer.Position;

            Dispatcher.BeginInvoke(() =>
            {
                StartTime = startTime;
                EndTime = endTime;
                Position = position;
            });
        }

        private static void ExecutePlay(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                mediaControl.Play();
            }
        }

        private static void CanExecutePlay(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanPlay;
            }
        }

        private static void ExecuteStop(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                mediaControl.Stop();
            }
        }

        private static void CanExecuteStop(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanStop;
            }
        }

        private static void ExecutePause(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                mediaControl.Pause();
            }
        }

        private static void CanExecutePause(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanPause;
            }
        }

        private static void ExecuteStepForward(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                mediaControl.StepForward();
            }
        }

        private static void CanExecuteStepForward(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanStepForward;
            }
        }

        private static void ExecuteStepBackward(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                mediaControl.StepBackward();
            }
        }

        private static void CanExecuteStepBackward(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanStepBackward;
            }
        }

        private static void ExecuteFastForward(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                mediaControl.FastForward();
            }
        }

        private static void CanExecuteFastForward(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanFastForward;
            }
        }

        private static void ExecuteFastBackward(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                mediaControl.FastBackward();
            }
        }

        private static void CanExecuteFastBackward(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanFastBackward;
            }
        }

        private static void ExecuteMuteVolume(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                mediaControl.MuteVolume();
            }
        }

        private static void CanExecuteMuteVolume(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanMuteVolume;
            }
        }

        private static void ExecuteIncreaseVolume(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                mediaControl.IncreaseVolume();
            }
        }

        private static void CanExecuteIncreaseVolume(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanIncreaseVolume;
            }
        }

        private static void ExecuteDecreaseVolume(object sender, ExecutedRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                mediaControl.DecreaseVolume();
            }
        }

        private static void CanExecuteDecreaseVolume(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            if (sender is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanDecreaseVolume;
            }
        }

        private static void SourcePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is MediaControl mediaControl)
            {
                if (eventArgs.OldValue is not null)
                {
                    mediaControl.Stop();
                }

                if (eventArgs.NewValue is not null)
                {
                    mediaControl.Play();
                }
            }
        }

        private static void VolumePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is MediaControl mediaControl)
            {
                mediaControl.SetVolume((double)eventArgs.NewValue);
            }
        }

        private static void IsMutedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is MediaControl mediaControl)
            {
                mediaControl.SetIsMuted((bool)eventArgs.NewValue);
            }
        }
    }
}
