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
using System.Linq;
using FFmpegSharp;

namespace FFplaySharp
{
    internal static class Program
    {
        static int Main(string[] args)
        {
            AVCodec.RegisterAll();
            AVDevice.RegisterAll();
            AVFilter.RegisterAll();

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
                .UseShowDevicesOption()
                .UseShowCodecsOption()
                .UseShowDecodersOption()
                .UseShowEncodersOption()
                .UseShowBitStreamFiltersOption()
                .UseShowProtocolsOption()
                .UseShowFiltersOption();

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

        private static CommandLineBuilder UseShowCodecsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--codecs", "Show available codecs", ShowCodecs);
        }

        private static CommandLineBuilder UseShowDecodersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--decoders", "Show available decoders", ShowDecoders);
        }

        private static CommandLineBuilder UseShowEncodersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--encoders", "Show available encoders", ShowEncoders);
        }

        private static CommandLineBuilder UseShowBitStreamFiltersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--bit-stream-filters", "Show available bit stream filters", ShowBitStreamFilters);
        }

        private static CommandLineBuilder UseShowProtocolsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--protocols", "Show available protocols", ShowProtocols);
        }

        private static CommandLineBuilder UseShowFiltersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--filters", "Show available filters", ShowFilters);
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

        private static void ShowCodecs()
        {
            Console.WriteLine("Codecs:");
            Console.WriteLine(" D..... = Decoding supported");
            Console.WriteLine(" .E.... = Encoding supported");
            Console.WriteLine(" ..V... = Video codec");
            Console.WriteLine(" ..A... = Audio codec");
            Console.WriteLine(" ..S... = Subtitle codec");
            Console.WriteLine(" ...I.. = Intra frame-only codec");
            Console.WriteLine(" ....L. = Lossy compression");
            Console.WriteLine(" .....S = Lossless compression");
            Console.WriteLine(" -------");

            foreach (var descriptor in AVCodecDescriptor.All.Where(e => !e.Name.Contains("_deprecated")))
            {
                Console.Write(" ");
                Console.Write(AVCodec.FindDecoder(descriptor.Id) != null ? "D" : ".");
                Console.Write(AVCodec.FindEncoder(descriptor.Id) != null ? "E" : ".");

                Console.Write(GetMediaTypeChar(descriptor.Type));
                Console.Write(descriptor.Properties.HasFlag(AVCodecProperties.IntraCompressionOnly) ? "I" : ".");
                Console.Write(descriptor.Properties.HasFlag(AVCodecProperties.LossyCompression) ? "L" : ".");
                Console.Write(descriptor.Properties.HasFlag(AVCodecProperties.LosslessCompression) ? "S" : ".");

                Console.Write(" {0,-20} {1} ", descriptor.Name, descriptor.LongName ?? string.Empty);

                /* print decoders/encoders when there's more than one or their
                 * names are different from codec name */
                foreach (var codec in AVCodec.All.Where(e => e.IsDecoder))
                {
                    if (codec.Name.Equals(descriptor.Name))
                    {
                        PrintDecoders(descriptor.Id);
                        break;
                    }
                }

                foreach (var codec in AVCodec.All.Where(e => e.IsEncoder))
                {
                    if (codec.Name.Equals(descriptor.Name))
                    {
                        PrintEncoders(descriptor.Id);
                        break;
                    }
                }

                Console.WriteLine();
            }
        }

        private static void ShowDecoders()
        {
            PrintCodecs(false);
        }

        private static void ShowEncoders()
        {
            PrintCodecs(true);
        }

        private static void ShowBitStreamFilters()
        {
            Console.WriteLine("Bit stream filters:");

            foreach (var filter in AVBitStreamFilter.All)
            {
                Console.WriteLine(filter.Name);
            }

            Console.WriteLine();
        }

        private static void ShowProtocols()
        {
            Console.WriteLine("Supported file protocols:");
            Console.WriteLine();
            Console.WriteLine("Input:");

            foreach (var protocolName in AVIO.InputProtocolNames)
            {
                Console.WriteLine($"  {protocolName}");
            }

            Console.WriteLine();
            Console.WriteLine("Output:");

            foreach (var protocolName in AVIO.OutputProtocolNames)
            {
                Console.WriteLine($"  {new string(protocolName)}");
            }
        }

        private static void ShowFilters()
        {
            Console.WriteLine("Filters:");
            Console.WriteLine("  T.. = Timeline support");
            Console.WriteLine("  .S. = Slice threading");
            Console.WriteLine("  ..C = Command support");
            Console.WriteLine("  A   = Audio input/output");
            Console.WriteLine("  V   = Video input/output");
            Console.WriteLine("  N   = Dynamic number and/or type of input/output");
            Console.WriteLine("  |   = Source or sink filter");

            foreach (var filter in AVFilter.All)
            {
                string descr = "";

                if (filter.Inputs.Any())
                {
                    foreach (var input in filter.Inputs)
                    {
                        descr += GetMediaTypeChar(input.Type);
                    }
                }
                else
                {
                    descr += filter.Flags.HasFlag(AVFilterFlags.DynamicInputs) ? 'N' : '|';
                }

                descr += "->";

                if (filter.Outputs.Any())
                {
                    foreach (var output in filter.Outputs)
                    {
                        descr += GetMediaTypeChar(output.Type);
                    }
                }
                else
                {
                    descr += filter.Flags.HasFlag(AVFilterFlags.DynamicOutputs) ? 'N' : '|';
                }

                Console.WriteLine(" {0}{1}{2} {3,-17} {4,-10} {5}",
                       filter.Flags.HasFlag(AVFilterFlags.SupportTimeline) ? 'T' : '.',
                       filter.Flags.HasFlag(AVFilterFlags.SliceThreads) ? 'S' : '.',
                       filter.CanProcessCommand ? 'C' : '.',
                       filter.Name,
                       descr,
                       filter.Description);
            }
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

        private static void PrintEncoders(AVCodecID id)
        {
            Console.Write($"(encoders: {string.Join(' ', AVCodec.All.Where(c => c.Id == id && c.IsEncoder).Select(c => c.Name))})");
        }

        private static void PrintDecoders(AVCodecID id)
        {
            Console.Write($"(decoders: {string.Join(' ', AVCodec.All.Where(c => c.Id == id && c.IsDecoder).Select(c => c.Name))})");
        }

        private static void PrintCodecs(bool encoder)
        {
            Console.WriteLine($"{(encoder ? "Encoders" : "Decoders")}");
            Console.WriteLine(" V..... = Video");
            Console.WriteLine(" A..... = Audio");
            Console.WriteLine(" S..... = Subtitle");
            Console.WriteLine(" .F.... = Frame-level multithreading");
            Console.WriteLine(" ..S... = Slice-level multithreading");
            Console.WriteLine(" ...X.. = Codec is experimental");
            Console.WriteLine(" ....B. = Supports draw_horiz_band");
            Console.WriteLine(" .....D = Supports direct rendering method 1");
            Console.WriteLine(" ------");

            foreach (var descriptor in AVCodecDescriptor.All)
            {
                foreach (var codec in AVCodec.All.Where(c => c.Id == descriptor.Id && (encoder == c.IsEncoder || !encoder == c.IsDecoder)))
                {
                    Console.Write($" {GetMediaTypeChar(descriptor.Type)}");
                    Console.Write(codec.Capabilities.HasFlag(AVCodecCapabilities.FrameThreads) ? "F" : ".");
                    Console.Write(codec.Capabilities.HasFlag(AVCodecCapabilities.SliceThreads) ? "S" : ".");
                    Console.Write(codec.Capabilities.HasFlag(AVCodecCapabilities.Experimental) ? "X" : ".");
                    Console.Write(codec.Capabilities.HasFlag(AVCodecCapabilities.DrawHorizontalBand) ? "B" : ".");
                    Console.Write(codec.Capabilities.HasFlag(AVCodecCapabilities.DR1) ? "D" : ".");
                    Console.Write($" {codec.Name,-20} {codec.LongName ?? string.Empty}");

                    if (codec.Name == descriptor.Name)
                    {
                        Console.Write($" (codec {descriptor.Name})");
                    }

                    Console.WriteLine();
                }
            }
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

        private static char GetMediaTypeChar(AVMediaType type)
        {
            return type switch
            {
                AVMediaType.Video => 'V',
                AVMediaType.Audio => 'A',
                AVMediaType.Data => 'D',
                AVMediaType.Subtitle => 'S',
                AVMediaType.Attachment => 'T',
                _ => '?',
            };
        }
    }
}
