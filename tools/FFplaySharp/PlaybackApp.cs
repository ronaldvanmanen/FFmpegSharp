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
using FFmpegSharp;
using FFmpegSharp.Extensions.Framework;
using FFmpegSharp.Extensions.Linq;
using SDL2Sharp;

namespace FFplaySharp
{
    internal sealed class PlaybackApp : Application
    {
        private readonly PlaybackOptions _options;

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
            _mediaDemultiplexer = new MediaDemultiplexer(new Uri(_options.InputFile));
            _mediaDemultiplexer.OutputStreams.ForAll(e => e.Discard = AVDiscard.All);
            _mediaDemultiplexer.BestAudioOutput!.Discard = AVDiscard.Default;
            _mediaDemultiplexer.Start();

            var audioDecoderOptions = new AudioDecoder.Options { Fast = _options.Fast };
            _audioDecoder = new AudioDecoder(_mediaDemultiplexer.BestAudioOutput, audioDecoderOptions);
            _audioDecoder.Start();

            _audioRenderer = new AudioRenderer(_audioDecoder.OutputStream);
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
