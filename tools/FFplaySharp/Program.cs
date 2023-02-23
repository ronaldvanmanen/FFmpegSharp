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
            AVDevice.RegisterAll();

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
                .UseShowLicenseOption()
                .UseShowBuildConfigurationOption()
                .UseShowFormatsOption()
                .UseShowMuxersOption()
                .UseShowDemuxersOption()
                .UseShowDevicesOption();

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

        private static CommandLineBuilder UseShowBuildConfigurationOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--build-configuration", "Show build configuration", ShowBuildConfiguration);
        }

        private static CommandLineBuilder UseShowFormatsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--formats", "Show available formats", ShowFormats);
        }

        private static CommandLineBuilder UseShowMuxersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--muxers", "Show available muxers", ShowMuxers);
        }

        private static CommandLineBuilder UseShowDemuxersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--demuxers", "Show available demuxers", ShowDemuxers);
        }

        private static CommandLineBuilder UseShowDevicesOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--devices", "Show available devices", ShowDevices);
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

        private static void ShowBuildConfiguration()
        {
            Console.WriteLine($"configuration:");

            foreach (var option in AVUtil.BuildConfiguration.Split(' '))
            {
                Console.WriteLine($"  {option}");
            }
        }

        private static void ShowFormats()
        {
            PrintFormats(showMuxers: true, showDemuxers: true, showDevicesOnly: false);
        }

        private static void ShowMuxers()
        {
            PrintFormats(showMuxers: true, showDemuxers: false, showDevicesOnly: false);
        }

        private static void ShowDemuxers()
        {
            PrintFormats(showMuxers: false, showDemuxers: true, showDevicesOnly: false);
        }

        private static void ShowDevices()
        {
            PrintFormats(showMuxers: true, showDemuxers: true, showDevicesOnly: true);
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


        private static int PrintFormats(bool showMuxers, bool showDemuxers, bool showDevicesOnly)
        {
            Console.WriteLine(showDevicesOnly ? "Devices:" : "File formats:");
            Console.WriteLine(" D. = Demuxing supported");
            Console.WriteLine(" .E = Muxing supported");
            Console.WriteLine(" --");

            var lastName = "000";

            while (true)
            {
                var decode = false;
                var encode = false;
                string? formatName = null;
                string? formatLongName = null;

                if (showMuxers)
                {
                    foreach (var outputFormat in AVOutputFormat.All)
                    {
                        if (showDevicesOnly && !outputFormat.IsDevice)
                        {
                            continue;
                        }

                        if ((formatName == null || outputFormat.Name.CompareTo(formatName) < 0) && outputFormat.Name.CompareTo(lastName) > 0)
                        {
                            formatName = outputFormat.Name;
                            formatLongName = outputFormat.LongName;
                            encode = true;
                        }
                    }
                }

                if (showDemuxers)
                {
                    foreach (var inputFormat in AVInputFormat.All)
                    {
                        if (showDevicesOnly && !inputFormat.IsDevice)
                        {
                            continue;
                        }

                        if ((formatName == null || inputFormat.Name.CompareTo(formatName) < 0) && inputFormat.Name.CompareTo(lastName) > 0)
                        {
                            formatName = inputFormat.Name;
                            formatLongName = inputFormat.LongName;
                            encode = false;
                        }

                        if (formatName != null && inputFormat.Name.Equals(formatName))
                        {
                            decode = true;
                        }
                    }
                }

                if (formatName == null)
                {
                    break;
                }

                lastName = formatName;

                Console.WriteLine(" {0}{1} {2,-15} {3}",
                    decode ? "D" : " ",
                    encode ? "E" : " ",
                    formatName,
                    formatLongName ?? " ");
            }
            return 0;
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
    }
}
