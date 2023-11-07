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
using FFmpegSharp.Extensions.Framework;
using FFmpegSharp.Extensions.Linq;
using SDL2Sharp;

namespace FFmpegSharp.Tools.Transcoder
{
    internal sealed class TranscodeApp : Application
    {
        private readonly TranscodeOptions _options;

        private MediaDemultiplexer _mediaDemultiplexer = null!;

        private AudioDecoder _audioDecoder = null!;

        public TranscodeApp(TranscodeOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        protected override void OnInitializing()
        {
            Subsystems = Subsystems.Audio | Subsystems.Events | Subsystems.Timer;
        }

        protected override void OnInitialized()
        {
            _mediaDemultiplexer = new MediaDemultiplexer(_options.InputFile);
            _mediaDemultiplexer.OutputStreams.ForAll(e => e.Discard = AVDiscard.All);
            _mediaDemultiplexer.BestAudioOutput!.Discard = AVDiscard.Default;
            _mediaDemultiplexer.Start();

            _audioDecoder = new AudioDecoder(_mediaDemultiplexer.BestAudioOutput);
            _audioDecoder.Start();
        }

        protected override void OnQuiting()
        {
            _mediaDemultiplexer?.Stop();
            _audioDecoder?.Stop();
        }
    }
}
