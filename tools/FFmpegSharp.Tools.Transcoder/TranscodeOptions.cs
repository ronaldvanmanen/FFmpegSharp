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
using System.Threading;
using Microsoft.Extensions.Logging;

namespace FFmpegSharp.Tools.Transcoder
{
    internal sealed class TranscodeOptions
    {
        public string InputFile { get; set; }

        public string OutputFile { get; set; }

        public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

        public ILogger Logger { get; set; } = null!;

        public TranscodeOptions(string inputFile, string outputFile)
        {
            InputFile = inputFile ?? throw new ArgumentNullException(nameof(inputFile));
            OutputFile = outputFile ?? throw new ArgumentNullException(nameof(outputFile));
        }
    }
}
