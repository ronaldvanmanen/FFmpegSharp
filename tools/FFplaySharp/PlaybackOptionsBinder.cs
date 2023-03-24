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

using System.CommandLine;
using System.CommandLine.Binding;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace FFplaySharp
{
    internal sealed class PlaybackOptionsBinder : CompositeBinderBase<PlaybackOptions>
    {
        private readonly Argument<string> _inputArgument =
            new("input", "input file");

        private readonly Option<bool> _fastOption =
            new("--fast", "Non-spec compliant optimizations");

        private readonly Option<bool> _findStreamInfoOption =
            new("--find-stream-info", "Read and decode the streams to fill missing information with heuristics");

        private readonly Option<bool> _generatePtsOption =
            new("--generate-pts", "Generate presentation timestamps (pts)");

        protected override PlaybackOptions GetBoundValue(BindingContext bindingContext)
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var inputFile = bindingContext.ParseResult.GetValueForArgument(_inputArgument);
            var boundValue = new PlaybackOptions(inputFile)
            {
                Fast = bindingContext.ParseResult.GetValueForOption(_fastOption),
                FindStreamInfo = bindingContext.ParseResult.GetValueForOption(_findStreamInfoOption),
                GeneratePts = bindingContext.ParseResult.GetValueForOption(_generatePtsOption),
                CancellationToken = bindingContext.GetService<CancellationToken>(),
                Logger = loggerFactory.CreateLogger("FFplaySharp")
            };
            return boundValue;
        }

        protected internal override void AddOptionsAndArguments(Command command)
        {
            command.AddArgument(_inputArgument);
            command.AddOption(_fastOption);
            command.AddOption(_generatePtsOption);
            command.AddOption(_findStreamInfoOption);
        }
    }
}
