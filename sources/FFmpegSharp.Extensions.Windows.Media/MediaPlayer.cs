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
using FFmpegSharp.Extensions.Framework;
using FFmpegSharp.Extensions.Linq;
using System;
using System.ComponentModel;
using System.Linq;
using static System.Math;

namespace FFmpegSharp.Extensions.Windows.Media
{
    public sealed class MediaPlayer : ObservableObject, IDisposable
    {
        private readonly MediaDemultiplexer _mediaDemultiplexer;

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

        public MediaPlayer(string source)
        {
            var mediaDemultiplexerOptions = new MediaDemultiplexer.Options { FindStreamInfo = true, InjectGlobalSideData = true };
            _mediaDemultiplexer = new MediaDemultiplexer(source, mediaDemultiplexerOptions);
            _mediaDemultiplexer.OutputStreams.ForAll(e => e.Discard = AVDiscard.All);
            _mediaDemultiplexer.BestAudioOutput!.Discard = AVDiscard.Default;
            _mediaDemultiplexer.Start();

            var audioDecoderOptions = new AudioDecoder.Options { Fast = false };
            _audioDecoder = new AudioDecoder(_mediaDemultiplexer.BestAudioOutput, audioDecoderOptions);
            _audioDecoder.Start();

            _audioRenderer = new AudioRenderer(_audioDecoder.OutputStream);
            _audioRenderer.Clock.PropertyChanged += OnClockPropertyChanged;
            _audioRenderer.Start();

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
