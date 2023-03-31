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
using FFmpegSharp.Extensions.Framework;
using MediaCommands = FFmpegSharp.Extensions.Windows.Input.MediaCommands;

namespace FFmpegSharp.Extensions.Windows.Controls
{
    public sealed class MediaControl : Control
    {
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

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached(
                nameof(Source),
                typeof(Uri),
                typeof(MediaControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, SourceChanged));

        private MediaStream<AVPacket> _demultiplexedAudioStream = null!;

        private MediaDemultiplexer _mediaDemultiplexer = null!;

        private MediaStream<AVFrame> _decodedAudioStream = null!;

        private AudioDecoder _audioDecoder = null!;

        private AudioRenderer _audioRenderer = null!;

        private DispatcherTimer _dispatcherTimer = null!;

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


        public Uri Source
        {
            get => (Uri)GetValue(SourceProperty);

            set => SetValue(SourceProperty, value);
        }

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
        }

        public void Load(Uri source)
        {
            var uri = source.IsFile ? source.LocalPath : source.ToString();
            var options = new MediaDemultiplexer.Options
            {
                FindStreamInfo = true,
                GeneratePts = false,
                InjectGlobalSideData = true,
            };

            _mediaDemultiplexer = new MediaDemultiplexer(uri, options);

            if (_mediaDemultiplexer.BestAudioOutput is null)
            {
                return;
            }

            _demultiplexedAudioStream = new MediaStream<AVPacket>(256);
            _mediaDemultiplexer.BestAudioOutput.Discard = AVDiscard.Default;
            _mediaDemultiplexer.BestAudioOutput.Connect(_demultiplexedAudioStream);
            _mediaDemultiplexer.Start();

            _decodedAudioStream = new MediaStream<AVFrame>(16);

            _audioDecoder = new AudioDecoder();
            _audioDecoder.AudioInput.Connect(_demultiplexedAudioStream,
                _mediaDemultiplexer.BestAudioOutput.StreamInfo);
            _audioDecoder.AudioOutput.Connect(_decodedAudioStream);
            _audioDecoder.Start();

            _audioRenderer = new AudioRenderer();
            _audioRenderer.Volume = AudioRenderer.MaxVolume;
            _audioRenderer.AudioInput.Connect(_decodedAudioStream,
                _audioDecoder.AudioOutput.StreamInfo);

            _audioRenderer.Start();

            _dispatcherTimer = new DispatcherTimer(DispatcherPriority.Render);
            _dispatcherTimer.Tick += OnTick;
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20);
            _dispatcherTimer.Start();

        }

        public void Play()
        {
            _audioRenderer.Start();
        }

        public void Stop()
        {
            _audioRenderer.Stop();
        }

        public void Pause()
        {
            _audioRenderer.Stop();
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
            _mediaDemultiplexer?.Stop();
            _audioDecoder?.Stop();
            _audioRenderer?.Stop();
        }

        private void OnTick(object? sender, EventArgs e)
        {
            StartTime = _mediaDemultiplexer.StartTime;
            EndTime = _mediaDemultiplexer.EndTime;
            CurrentTime = _audioRenderer.Clock.Time;
        }

        private static void ExecutePlay(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.Play();
            }
        }

        private static void CanExecutePlay(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            eventArgs.CanExecute = true;
        }

        private static void ExecuteStop(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.Stop();
            }
        }

        private static void CanExecuteStop(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            eventArgs.CanExecute = true;
        }

        private static void ExecutePause(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.Pause();
            }
        }

        private static void CanExecutePause(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            eventArgs.CanExecute = true;
        }

        private static void ExecuteStepForward(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.StepForward();
            }
        }

        private static void CanExecuteStepForward(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            eventArgs.CanExecute = false;
        }

        private static void ExecuteStepBackward(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.StepBackward();
            }
        }

        private static void CanExecuteStepBackward(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            eventArgs.CanExecute = false;
        }

        private static void ExecuteFastForward(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.FastForward();
            }
        }

        private static void CanExecuteFastForward(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            eventArgs.CanExecute = false;
        }

        private static void ExecuteFastBackward(object source, ExecutedRoutedEventArgs eventArgs)
        {
            if (source is MediaControl mediaControl)
            {
                mediaControl.FastBackward();
            }
        }

        private static void CanExecuteFastBackward(object sender, CanExecuteRoutedEventArgs eventArgs)
        {
            eventArgs.CanExecute = false;
        }

        private static void SourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is MediaControl mediaControl)
            {
                if (eventArgs.NewValue is Uri source)
                {
                    mediaControl.Load(source);
                }
            }
        }
    }
}
