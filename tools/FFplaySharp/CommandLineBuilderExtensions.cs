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
using System.CommandLine;
using System.CommandLine.Builder;

namespace FFplaySharp
{
    internal static class CommandLineBuilderExtensions
    {
        public static CommandLineBuilder AddGlobalOption(this CommandLineBuilder builder, string alias, string description, Action callback)
        {
            var option = new Option<bool>(alias, description);
            builder.Command.AddGlobalOption(option);
            builder.AddMiddleware(async (context, next) =>
            {
                if (null != context.ParseResult.FindResultFor(option))
                {
                    callback();
                }
                else
                {
                    await next(context);
                }
            });
            return builder;
        }
    }
}
