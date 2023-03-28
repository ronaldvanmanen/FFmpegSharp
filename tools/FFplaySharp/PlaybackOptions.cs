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
using System.Threading;
using Microsoft.Extensions.Logging;

namespace FFplaySharp
{
    internal sealed class PlaybackOptions
    {
        public string InputFile { get; set; }

        public bool Fast { get; set; }

        public bool GeneratePts { get; set; }

        public bool FindStreamInfo { get; set; }

        public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

        public ILogger Logger { get; set; } = null!;

        public PlaybackOptions(string inputFile)
        {
            InputFile = inputFile ?? throw new ArgumentNullException(nameof(inputFile));
        }
    }
}
