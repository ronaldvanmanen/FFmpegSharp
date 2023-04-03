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
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using MediaCommands = FFmpegSharp.Extensions.Windows.Input.MediaCommands;

namespace FFmpegSharp.Extensions.Windows.Controls
{
    public sealed class MediaControl : Control
    {
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached(
                nameof(Source),
                typeof(Uri),
                typeof(MediaControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, SourceChanged));

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

        public static readonly DependencyProperty CurrentTimeProperty =
            DependencyProperty.RegisterAttached(
                nameof(CurrentTime),
                typeof(AVRelativeTime),
                typeof(MediaControl),
                new FrameworkPropertyMetadata(AVRelativeTime.Undefined, FrameworkPropertyMetadataOptions.None));

        private readonly DispatcherTimer _dispatcherTimer;

        private MediaSession _mediaSession;

        public Uri Source
        {
            get => (Uri)GetValue(SourceProperty);

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

        public AVRelativeTime CurrentTime
        {
            get => (AVRelativeTime)GetValue(CurrentTimeProperty);

            private set => SetValue(CurrentTimeProperty, value);
        }

        public bool CanPlay => Source is not null;

        public bool CanStop => _mediaSession is not null;

        public bool CanPause => _mediaSession is not null;

        public bool CanStepForward => false;

        public bool CanStepBackward => false;

        public bool CanFastForward => false;

        public bool CanFastBackward => false;

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
        }

        public MediaControl()
        {
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;

            _dispatcherTimer = new DispatcherTimer(DispatcherPriority.Render);
            _dispatcherTimer.Tick += OnTick;
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20);
            _mediaSession = null!;
        }

        public void Play()
        {
            if (_mediaSession is not null)
            {
                _mediaSession.Play();
            }
            else
            {
                if (Source is not null)
                {
                    _dispatcherTimer.Start();
                    _mediaSession = new MediaSession(Source);
                    _mediaSession.Play();
                }
            }
        }

        public void Stop()
        {
            if (_mediaSession is null)
            {
                return;
            }

            _dispatcherTimer.Stop();
            _mediaSession.Stop();
            _mediaSession.Dispose();
            _mediaSession = null!;
        }


        public void Pause()
        {
            _mediaSession?.Pause();
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

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window is not null)
            {
                window.Closing += OnClosing;
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window is not null)
            {
                window.Closing -= OnClosing;
            }
        }

        private void OnClosing(object? sender, CancelEventArgs e)
        {
            Stop();
        }

        private void OnTick(object? sender, EventArgs e)
        {
            if (_mediaSession is not null)
            {
                StartTime = _mediaSession.StartTime;
                EndTime = _mediaSession.EndTime;
                CurrentTime = _mediaSession.CurrentTime;
            }
            else
            {
                StartTime = AVRelativeTime.Undefined;
                EndTime = AVRelativeTime.Undefined;
                CurrentTime = AVRelativeTime.Undefined;
            }
        }

        private static void ExecutePlay(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.Play();
            }
        }

        private static void CanExecutePlay(object source, CanExecuteRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanPlay;
            }
        }

        private static void ExecuteStop(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.Stop();
            }
        }

        private static void CanExecuteStop(object source, CanExecuteRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanStop;
            }
        }

        private static void ExecutePause(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.Pause();
            }
        }

        private static void CanExecutePause(object source, CanExecuteRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanPause;
            }
        }

        private static void ExecuteStepForward(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.StepForward();
            }
        }

        private static void CanExecuteStepForward(object source, CanExecuteRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanStepForward;
            }
        }

        private static void ExecuteStepBackward(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.StepBackward();
            }
        }

        private static void CanExecuteStepBackward(object source, CanExecuteRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanStepBackward;
            }
        }

        private static void ExecuteFastForward(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.FastForward();
            }
        }

        private static void CanExecuteFastForward(object source, CanExecuteRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanFastForward;
            }
        }

        private static void ExecuteFastBackward(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.FastBackward();
            }
        }

        private static void CanExecuteFastBackward(object source, CanExecuteRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                eventArgs.CanExecute = mediaControl.CanFastBackward;
            }
        }

        private static void SourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
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
    }
}
