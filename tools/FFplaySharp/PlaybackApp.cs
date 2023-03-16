﻿// This file is part of FFmpegSharp.
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
using FFmpegSharp;
using FFmpegSharp.Extensions.Framework;
using SDL2Sharp;

namespace FFplaySharp
{
    internal sealed class PlaybackApp : Application
    {
        private readonly PlaybackOptions _options;

        private PacketizedElementaryStream _packetizedElementaryAudioStream = null!;

        private AudioElementaryStream _audioElementaryStream = null!;

        private MediaDemultiplexer _mediaDemultiplexer = null!;

        private AudioDecoder _audioDecoder = null!;

        private AudioRenderer _audioRenderer = null!;

        public PlaybackApp(PlaybackOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        protected override void OnInitializing()
        {
            Subsystems = Subsystems.Audio | Subsystems.Events | Subsystems.Timer;
        }

        protected override void OnInitialized()
        {
            _packetizedElementaryAudioStream = new PacketizedElementaryStream(256);

            _mediaDemultiplexer = new MediaDemultiplexer(_options.InputFile);
            _mediaDemultiplexer.BestAudioOutput!.Discard = AVDiscard.Default;
            _mediaDemultiplexer.BestAudioOutput!.Stream = _packetizedElementaryAudioStream;
            _mediaDemultiplexer.Start();

            _audioElementaryStream = new AudioElementaryStream(16);

            var audioDecoderOptions = new AudioDecoder.Options { Fast = _options.Fast };
            _audioDecoder = new AudioDecoder(audioDecoderOptions);
            _audioDecoder.AudioInput.CodecParameters = _mediaDemultiplexer.BestAudioOutput!.CodecParameters;
            _audioDecoder.AudioInput.PacketTimeBase = _mediaDemultiplexer.BestAudioOutput!.PacketTimeBase;
            _audioDecoder.AudioInput.Stream = _packetizedElementaryAudioStream;
            _audioDecoder.AudioOutput.Stream = _audioElementaryStream;
            _audioDecoder.Start();

            _audioRenderer = new AudioRenderer();
            _audioRenderer.Volume = AudioRenderer.MaxVolume;
            _audioRenderer.AudioInput.SampleFormat = _audioDecoder.AudioOutput.SampleFormat;
            _audioRenderer.AudioInput.ChannelLayout = _audioDecoder.AudioOutput.ChannelLayout;
            _audioRenderer.AudioInput.SampleRate = _audioDecoder.AudioOutput.SampleRate;
            _audioRenderer.AudioInput.TimeBase = _audioDecoder.AudioOutput.TimeBase;
            _audioRenderer.AudioInput.Stream = _audioElementaryStream;
            _audioRenderer.Start();
        }

        protected override void OnQuiting()
        {
            _mediaDemultiplexer?.Stop();
            _audioDecoder?.Stop();
            _audioRenderer?.Stop();
        }
    }
}
