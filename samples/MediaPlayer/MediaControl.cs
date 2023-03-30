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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FFmpegSharp;
using FFmpegSharp.Extensions.Framework;

namespace MediaPlayer
{
    public class MediaControl : Control
    {
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
        }

        public void Load(Uri source)
        {
            _mediaDemultiplexer = new MediaDemultiplexer(source.IsFile ? source.LocalPath : source.ToString());

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
            _audioDecoder.AudioInput.Connect(_demultiplexedAudioStream, _mediaDemultiplexer.BestAudioOutput.StreamInfo);
            _audioDecoder.AudioOutput.Connect(_decodedAudioStream);
            _audioDecoder.Start();

            _audioRenderer = new AudioRenderer();
            _audioRenderer.Volume = AudioRenderer.MaxVolume;
            _audioRenderer.AudioInput.Connect(_decodedAudioStream, _audioDecoder.AudioOutput.StreamInfo);
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
