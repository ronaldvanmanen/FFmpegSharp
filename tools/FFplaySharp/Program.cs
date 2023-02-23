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
using System.CommandLine.Parsing;
using System.IO;
using FFmpegSharp;

namespace FFplaySharp
{
    internal static class Program
    {
        static int Main(string[] args)
        {
            var rootCommand = new RootCommand("Simple media player based on FFplay");

            rootCommand.SetHandler(() => { });

            var commandLineBuilder = new CommandLineBuilder(rootCommand)
                .UseHelp()
                .UseEnvironmentVariableDirective()
                .UseParseDirective()
                .UseSuggestDirective()
                .RegisterWithDotnetSuggest()
                .UseTypoCorrections()
                .UseParseErrorReporting()
                .UseExceptionHandler()
                .CancelOnProcessTermination()
                .UseShowVersionOption()
                .UseShowLicenseOption();

            var commandLineParser = commandLineBuilder.Build();

            return commandLineParser.Invoke(args);
        }

        private static CommandLineBuilder UseShowVersionOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--version", "Show version", ShowVersion);
        }

        private static CommandLineBuilder UseShowLicenseOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--license", "Show license", ShowLicense);
        }

        private static void ShowVersion()
        {
            PrintBuildConfiguration();
            PrintLibraryVersion("avutil");
            PrintLibraryVersion("avcodec");
            PrintLibraryVersion("avformat");
            PrintLibraryVersion("avdevice");
            PrintLibraryVersion("avfilter");
            PrintLibraryVersion("swresample");
            PrintLibraryVersion("swscale");
        }

        private static void ShowLicense()
        {
            var programName = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
#if CONFIG_NONFREE
            var license = Licenses.NonFree;
#elif CONFIG_GPLV3
            var license = Licenses.GPLv3;
#elif CONFIG_GPL
            var license = Licenses.GPLv2;
#elif CONFIG_LGPLV3
            var license = Licenses.LGPLv3;
#else
            var license = Licenses.LGPLv2;
#endif
            Console.WriteLine(license, programName);
        }

        private static void PrintBuildConfiguration()
        {
            Console.WriteLine($"configuration: {AVUtil.BuildConfiguration}");
        }

        private static void PrintLibraryVersion(string libraryName)
        {
            var intVersion = GetIntVersion(libraryName);
            Console.WriteLine("lib{0,-14} {1,2}.{2,3}.{3,3} / {4,2}.{5,3}.{6,3}",
                libraryName,
                GetMajorVersion(libraryName),
                GetMinorVersion(libraryName),
                GetMicroVersion(libraryName),
                GetMajorVersion(intVersion),
                GetMinorVersion(intVersion),
                GetMicroVersion(intVersion));
        }

        private static uint GetIntVersion(string libraryName)
        {
            var type = typeof(FFmpegSharp.Interop.FFmpeg);
            var method = type.GetMethod($"{libraryName.ToLower()}_version");
            if (method == null)
            {
                return 0;
            }
            var result = method.Invoke(null, null);
            if (result == null)
            {
                return 0;
            }
            return (uint)result;
        }

        private static int GetMajorVersion(string libraryName)
        {
            var type = typeof(FFmpegSharp.Interop.FFmpeg);
            var field = type.GetField($"LIB{libraryName.ToUpper()}_VERSION_MAJOR");
            if (field == null)
            {
                return 0;
            }
            var value = field.GetValue(null);
            if (value == null)
            {
                return 0;
            }
            return (int)value;
        }

        private static int GetMinorVersion(string libraryName)
        {
            var type = typeof(FFmpegSharp.Interop.FFmpeg);
            var field = type.GetField($"LIB{libraryName.ToUpper()}_VERSION_MINOR");
            if (field == null)
            {
                return 0;
            }
            var value = field.GetValue(null);
            if (value == null)
            {
                return 0;
            }
            return (int)value;
        }

        private static int GetMicroVersion(string libraryName)
        {
            var type = typeof(FFmpegSharp.Interop.FFmpeg);
            var field = type.GetField($"LIB{libraryName.ToUpper()}_VERSION_MICRO");
            if (field == null)
            {
                return 0;
            }
            var value = field.GetValue(null);
            if (value == null)
            {
                return 0;
            }
            return (int)value;
        }

        private static uint GetMajorVersion(uint a) => (a) >> 16;

        private static uint GetMinorVersion(uint a) => (((a) & 0x00FF00) >> 8);

        private static uint GetMicroVersion(uint a) => ((a) & 0xFF);

        private static CommandLineBuilder AddGlobalOption(this CommandLineBuilder builder, string alias, string description, Action callback)
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
