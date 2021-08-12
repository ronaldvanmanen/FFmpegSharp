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
using System.Linq;

namespace FFplaySharp
{
    internal static class CommandLineBuilderExtensions
    {
        public static CommandLineBuilder AddArgument<T>(this CommandLineBuilder builder, string name, string description)
        {
            return builder.AddArgument(new Argument<string>(name, description));
        }

        public static CommandLineBuilder AddOption<T>(this CommandLineBuilder builder, string alias, string description)
        {
            return builder.AddOption<T>(alias, description, null!);
        }

        public static CommandLineBuilder AddOption<T>(this CommandLineBuilder builder, string alias, string description, string suggestion)
        {
            var option = new Option<T>(alias, description);
            if (suggestion != null)
            {
                option.AddSuggestions(suggestion);
            }
            return builder.AddOption(option);
        }

        public static CommandLineBuilder AddOption<T>(this CommandLineBuilder builder, string alias, Func<T> defaultValue, string description)
        {
            return builder.AddOption(new Option<T>(alias, defaultValue, description));
        }

        public static CommandLineBuilder AddGlobalOption(this CommandLineBuilder builder, string alias, string description, Action callback)
        {
            var option = new Option<bool>(alias, description);
            builder.Command.AddGlobalOption(option);
            builder.UseMiddleware(async (context, next) =>
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

        public static CommandLineBuilder AddGlobalOption(this CommandLineBuilder builder, string alias, string suggestion, string description, Action<string> callback)
        {
            var option = new Option<string>(alias, description);
            option.Arity = ArgumentArity.ExactlyOne;
            option.AddSuggestions(suggestion);
            builder.Command.AddGlobalOption(option);
            builder.UseMiddleware(async (context, next) =>
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
