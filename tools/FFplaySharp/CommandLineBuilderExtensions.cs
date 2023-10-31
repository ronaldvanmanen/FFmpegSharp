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
using System.CommandLine;
using System.CommandLine.Builder;
using System.Linq;

namespace FFplaySharp
{
    internal static class CommandLineBuilderExtensions
    {
        public static CommandLineBuilder AddGlobalOption(
            this CommandLineBuilder builder,
            string name,
            string? description,
            Action callback)
        {
            var option = new Option<bool>(name, description);
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

        public static CommandLineBuilder AddGlobalOption(
            this CommandLineBuilder builder,
            string name,
            string? argumentHelpName,
            string? description,
            string[] completions,
            Action<string> callback)
        {
            // Note: The list of completions will be shown in the help text of
            // this option instead of the ArgumentHelpName when the latter is
            // set to null. For example --sinks <sdl|sdl2|...>.
            var option = new Option<string>(name, description);
            option.Arity = ArgumentArity.ExactlyOne;
            option.ArgumentHelpName = argumentHelpName;
            option.AddCompletions(completions);

            builder.Command.AddGlobalOption(option);
            builder.AddMiddleware(async (context, next) =>
            {
                var parseResult = context.ParseResult.FindResultFor(option);
                if (parseResult != null && parseResult.Tokens.Any())
                {
                    callback(parseResult.Tokens.Select(e => e.Value).First());
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
