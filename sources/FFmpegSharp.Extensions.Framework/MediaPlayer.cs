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

using FFmpegSharp.Extensions.ComponentModel;
using System;
using System.ComponentModel;
using static System.Math;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class MediaPlayer : ObservableObject, IDisposable
    {
        private readonly MediaStream<AVPacket> _demultiplexedAudioStream;

        private readonly MediaDemultiplexer _mediaDemultiplexer;

        private readonly MediaStream<AVFrame> _decodedAudioStream;

        private readonly AudioDecoder _audioDecoder;

        private readonly AudioRenderer _audioRenderer;

        private bool _disposed;

        public AVRelativeTime StartTime => _mediaDemultiplexer.StartTime;

        public AVRelativeTime EndTime => _mediaDemultiplexer.EndTime;

        public AVRelativeTime Position => _audioRenderer.Clock.Time;

        public double Volume
        {
            get => _audioRenderer.Volume;

            set => _audioRenderer.Volume = Max(0d, Min(value, 1d));
        }

        public bool IsMuted
        {
            get => _audioRenderer.IsMuted;

            set => _audioRenderer.IsMuted = value;
        }

        public MediaPlayer(Uri source)
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
                throw new NotSupportedException();
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
            _audioRenderer.AudioInput.Connect(_decodedAudioStream, _audioDecoder.AudioOutput.StreamInfo);
            _audioRenderer.Clock.PropertyChanged += OnClockPropertyChanged;
            _disposed = false;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                _mediaDemultiplexer.Dispose();
                _audioDecoder.Dispose();
                _audioRenderer.Clock.PropertyChanged -= OnClockPropertyChanged;
                _audioRenderer.Dispose();
            }
            finally
            {
                _disposed = true;
            }
        }

        public void Play()
        {
            ThrowIfDisposed();

            _audioRenderer.Start();
        }

        public void Pause()
        {
            ThrowIfDisposed();

            _audioRenderer.Stop();
        }

        public void Stop()
        {
            ThrowIfDisposed();

            _mediaDemultiplexer?.Stop();
            _audioDecoder?.Stop();
            _audioRenderer?.Stop();
        }

        public void MuteVolume()
        {
            _audioRenderer.IsMuted = !_audioRenderer.IsMuted;
        }

        private void OnClockPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IClock.Time))
            {
                OnPropertyChanged(nameof(Position));
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }
}
