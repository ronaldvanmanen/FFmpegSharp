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
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.IO;
using System.Linq;
using System.Threading;
using FFmpegSharp;
using Microsoft.Extensions.Logging;

namespace FFplaySharp
{
    internal static partial class Program
    {
        private static readonly ILogger _logger;

        static Program()
        {
            _logger = new LoggerFactory().CreateLogger("FFplaySharp");
        }

        private static void Main(string[] args)
        {
            Initialize();
            Run(args);
            Deinitialize();
        }

        private static int Run(string[] args)
        {
            var root = new RootCommand
            {
                Handler = CommandHandler.Create<CommandLineOptions, CancellationToken>((options, cancellationToken) =>
                {
                    new App(options, _logger, cancellationToken).Run(args);
                })
            };

            var commandLineBuilder = new CommandLineBuilder(root)
                .UseHelp()
                .UseEnvironmentVariableDirective()
                .UseParseDirective()
                .UseDebugDirective()
                .UseSuggestDirective()
                .RegisterWithDotnetSuggest()
                .UseTypoCorrections()
                .UseParseErrorReporting()
                .UseExceptionHandler()
                .CancelOnProcessTermination()
                .UseShowLicenseOption()
                .UseShowBuildConfigurationOption()
                .UseShowVersionOption()
                .UseShowFormatsOption()
                .UseShowMuxersOption()
                .UseShowDemuxersOption()
                .UseShowDevicesOption()
                .UseShowCodecsOption()
                .UseShowDecodersOption()
                .UseShowEncodersOption()
                .UseShowBitStreamFiltersOption()
                .UseShowProtocolsOption()
                .UseShowFiltersOption()
                .UseShowPixelFormatsOption()
                .UseShowStandardChannelLayoutsOption()
                .UseShowSampleFormatsOption()
                .UseShowColorsOption()
                .UseShowSourcesOption()
                .UseShowSinksOption()
                .UseOptions();

            var commandLineParser = commandLineBuilder.Build();

            return commandLineParser.Invoke(args);
        }

        private static void Initialize()
        {
            AVCodec.RegisterAll();
            AVDevice.RegisterAll();
            AVFilter.RegisterAll();
            AVFormat.RegisterAll();
            AVFormat.NetworkInit();
        }

        private static void Deinitialize()
        {
            AVFormat.NetworkDeinit();
        }

        private static CommandLineBuilder UseOptions(this CommandLineBuilder builder)
        {
            return builder
                .AddArgument<string>("input", "input file")
                .AddOption<LogLevel>("--log-level", "Set logging level")
                .AddOption<bool>("--generate-report", "Generate a report")
                .AddOption<long>("--max-alloc", "Set maximum size of a single allocated block", "bytes")
                .AddOption<int>("--cpu-flags", "Force specific CPU flags")
                .AddOption<bool>("--hide-banner", "Do not show program banner")
                .AddOption<int>("--width", () => 640, "Force displayed width")
                .AddOption<int>("--height", () => 480, "Force displayed height")
                .AddOption<string>("--frame-size", "Set frame size (WxH or abbreviation)")
                .AddOption<bool>("--full-screen", "Force full screen")
                .AddOption<bool>("--disable-audio", "Disable audio")
                .AddOption<bool>("--disable-video", "Disable video")
                .AddOption<bool>("--disable-subtitling", "Disable subtitling")
                .AddOption<string>("--audio-stream", "Select desired audio stream", "stream-specifier")
                .AddOption<string>("--video-stream", "Select desired video stream", "stream-specifier")
                .AddOption<string>("--subtitle-stream", "Select desired subtitle stream", "stream-specifier")
                .AddOption<int>("--seek", "Seek to a given position in seconds", "seconds")
                .AddOption<int>("--duration", "Play \"duration\" seconds of audio/video", "seconds")
                .AddOption<bool?>("--bytes", "Seek by bytes")
                .AddOption<float>("--seek-interval", "Set seek interval for left/right keys, in seconds", "seconds")
                .AddOption<bool>("--no-display", "Disable graphical display")
                .AddOption<bool>("--no-border", "Borderless window")
                .AddOption<bool>("--always-on-top", "Window always on top")
                .AddOption<int>("--volume", "Set startup volume (0=min 100=max)")
                .AddOption<string>("--format", "Force format")
                .AddOption<string>("--pixel-format", "Set pixel format")
                .AddOption<bool>("--status", "Show status")
                .AddOption<bool>("--fast", "Non-spec compliant optimizations")
                .AddOption<bool>("--generate-pts", "Generate presentation timestamps (pts)")
                .AddOption<bool?>("--reorder-pts", "Let decoder reorder presentation timestamps")
                .AddOption<int>("--low-res", "")
                .AddOption<SyncType>("--sync", "Set audio-video synchronization type")
                .AddOption<bool>("--auto-exit", "Exit at the end")
                .AddOption<bool>("--exit-on-keydown", "Exit on key down")
                .AddOption<bool>("--exit-on-mousedown", "Exit on mouse down")
                .AddOption<int>("--loop", "Set number of times the playback shall be looped", "loop-count")
                .AddOption<bool>("--drop-frames", "Drop frames when cpu is too slow")
                .AddOption<bool>("--infinite-buffer", "Don't limit the input buffer size (useful with realtime streams)")
                .AddOption<string>("--window-title", "Set window title")
                .AddOption<int>("--left", "Set the x position for the left of the window")
                .AddOption<int>("--top", "Set the y position for the top of the window")
                .AddOption<string>("--video-filters", "Set video filters", "filter-graph")
                .AddOption<string>("--audio-filters", "Set audio filters", "filter-graph")
                .AddOption<int>("--rdft-speed", "Restricted domain Fourier transform speed", "milliseconds")
                .AddOption<ShowMode>("--show-mode", "Select show mode")
                .AddOption<string>("--codec", "Force decoder", "decoder-name")
                .AddOption<string>("--audio-codec", "Force audio decoder", "decoder-name")
                .AddOption<string>("--subtitle-codec", "Force subtitle decoder", "decoder-name")
                .AddOption<string>("--video-codec", "Force video decoder", "decoder-name")
                .AddOption<bool>("--auto-rotate", "Automatically rotate video")
                .AddOption<bool>("--find-stream-info", () => true, "Read and decode the streams to fill missing information with heuristics")
                .AddOption<int>("--filter-threads", "Number of filter threads per graph", "thread-count");
        }

        private static CommandLineBuilder UseShowLicenseOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--license",
                "Show license",
                () => PrintLicense());
        }

        private static CommandLineBuilder UseShowBuildConfigurationOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--build-configuration",
                "Show build configuration",
                () => PrintBuildConfiguration());
        }

        private static CommandLineBuilder UseShowVersionOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--version",
                "Show version",
                () => PrintVersion());
        }

        private static CommandLineBuilder UseShowFormatsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--formats",
                "Show available formats",
                () => PrintFormats(true, true, false));
        }

        private static CommandLineBuilder UseShowMuxersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--muxers",
                "Show available muxers",
                () => PrintFormats(true, false, false));
        }

        private static CommandLineBuilder UseShowDemuxersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--demuxers",
                "Show available demuxers",
                () => PrintFormats(false, true, false));
        }

        private static CommandLineBuilder UseShowDevicesOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--devices",
                "Show available devices",
                () => PrintFormats(true, true, true));
        }

        private static CommandLineBuilder UseShowCodecsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--codecs",
                "Show available codecs",
                () => PrintCodecs());
        }

        private static CommandLineBuilder UseShowDecodersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--decoders",
                "Show available decoders",
                () => PrintCodecs(false));
        }

        private static CommandLineBuilder UseShowEncodersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--encoders",
                "Show available encoders",
                () => PrintCodecs(true));
        }

        private static CommandLineBuilder UseShowBitStreamFiltersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--bit-stream-filters",
                "Show available bit stream filters",
                () => PrintBitStreamFilters());
        }

        private static CommandLineBuilder UseShowProtocolsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--protocols",
                "Show available protocols",
                () => PrintProtocols());
        }

        private static CommandLineBuilder UseShowFiltersOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--filters",
                "Show available filters",
                () => PrintFilters());
        }

        private static CommandLineBuilder UseShowPixelFormatsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--pixel-formats",
                "Show available pixel formats",
                () => PrintPixelFormats());
        }

        private static CommandLineBuilder UseShowStandardChannelLayoutsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--channel-layouts",
                "Show standard channel layouts",
                () => PrintStandardChannelLayouts());
        }

        private static CommandLineBuilder UseShowSampleFormatsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--sample-formats",
                "Show available audio sample formats",
                () => PrintSampleFormats());
        }

        private static CommandLineBuilder UseShowColorsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--colors",
                "Show available color names",
                () => PrintColors());
        }

        private static CommandLineBuilder UseShowSourcesOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--sources",
                "device",
                "List sources of the input device",
                (deviceName) => PrintSources(deviceName));
        }

        private static CommandLineBuilder UseShowSinksOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption(
                "--sinks",
                "device",
                "List sinks of the output device",
                (deviceName) => PrintSinks(deviceName));
        }

        private static void PrintLicense()
        {
            var programName = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
#if CONFIG_NONFREE
            Console.WriteLine(StringResources.LicenseNonFree, programName);
#elif CONFIG_GPLV3
            Console.WriteLine(StringResources.LicenseGPLv3, programName);
#elif CONFIG_GPL
            Console.WriteLine(StringResources.LicenseGPL, programName);
#elif CONFIG_LGPLV3
            Console.WriteLine(LicenseLGPLv3, programName);
#else
            Console.WriteLine(StringResources.LicenseDefault, programName);
#endif
        }

        private static void PrintBuildConfiguration()
        {
            Console.WriteLine($"configuration: {AVUtil.BuildConfiguration}");
        }

        private static void PrintVersion()
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

            string lastName = "000";

            while (true)
            {
                bool decode = false;
                bool encode = false;
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

        private static void PrintCodecs()
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

        private static void PrintBitStreamFilters()
        {
            Console.WriteLine("Bit stream filters:");

            foreach (var filter in AVBitStreamFilter.All)
            {
                Console.WriteLine(filter.Name);
            }

            Console.WriteLine();
        }

        private static void PrintProtocols()
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

        private static void PrintFilters()
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

        private static void PrintColors()
        {
            Console.WriteLine("{0,-32} #RRGGBB", "name");

            foreach (var color in AVKnownColor.All)
            {
                Console.WriteLine("{0,-32} #{1:X2}{2:X2}{3:X2}", color.Name, color.R, color.G, color.B);
            }
        }

        private static void PrintPixelFormats()
        {
            Console.WriteLine("Pixel formats:");
            Console.WriteLine("I.... = Supported Input format for conversion");
            Console.WriteLine(".O... = Supported Output format for conversion");
            Console.WriteLine("..H.. = Hardware accelerated format");
            Console.WriteLine("...P. = Paletted format");
            Console.WriteLine("....B = Bitstream format");
            Console.WriteLine("FLAGS NAME            NB_COMPONENTS BITS_PER_PIXEL");
            Console.WriteLine("-----");

            foreach (var descriptor in AVPixelFormatDescriptor.All)
            {
                AVPixelFormat format = descriptor.PixelFormat;
                Console.WriteLine("{0}{1}{2}{3}{4} {5,-16}       {6:D}            {7:D2}",
                    format.IsSupportedInputFormat() ? 'I' : '.',
                    format.IsSupportedOutputFormat() ? 'O' : '.',
                    descriptor.Flags.HasFlag(AVPixelFormatFlags.HardwareAcceleration) ? 'H' : '.',
                    descriptor.Flags.HasFlag(AVPixelFormatFlags.Pal) ? 'P' : '.',
                    descriptor.Flags.HasFlag(AVPixelFormatFlags.Bitstream) ? 'B' : '.',
                    descriptor.Name,
                    descriptor.ComponentsPerPixel,
                    descriptor.BitsPerPixel);
            }
        }

        private static void PrintStandardChannelLayouts()
        {
            Console.WriteLine("Individual channels:");
            Console.WriteLine("NAME           DESCRIPTION");

            foreach (var channel in Enum.GetValues<AVChannels>())
            {
                var name = channel.GetName();
                var description = channel.GetDescription();
                Console.WriteLine("{0,-14} {1}", name, description);
            }

            Console.WriteLine();
            Console.WriteLine("Standard channel layouts:");
            Console.WriteLine("NAME           DECOMPOSITION");

            foreach (var channelLayout in AVStandardChannelLayout.All)
            {
                var name = channelLayout.Name;
                var decomposition = string.Join("+", channelLayout.Layout.GetChannels().Select(e => e.GetName()));
                Console.WriteLine("{0,-14} {1}", name, decomposition);
            }
        }

        private static void PrintSampleFormats()
        {
            var sampleFormats = Enum.GetValues<AVSampleFormat>();
            foreach (var sampleFormat in sampleFormats)
            {
                Console.WriteLine("{0}", sampleFormat.AsString());
            }
        }

        private static void PrintSources(string deviceName)
        {
            foreach (var device in AVDevice.AudioInputDevices)
            {
                if (device.Name.Equals("lavfi"))
                {
                    continue;
                }

                if (deviceName != null && deviceName.Equals(device.Name))
                {
                    continue;
                }

                PrintDeviceSources(device, null!);
            }

            foreach (var device in AVDevice.VideoInputDevices)
            {
                if (device.Name.Equals("lavfi"))
                {
                    continue;
                }

                if (deviceName != null && deviceName.Equals(device.Name))
                {
                    continue;
                }

                PrintDeviceSources(device, null!);
            }
        }

        private static void PrintSinks(string deviceName)
        {
            foreach (var device in AVDevice.AudioOutputDevices.Where(e => !e.Name.Equals("lavfi")))
            {
                if (deviceName != null && deviceName.Equals(device.Name))
                {
                    continue;
                }

                PrintDeviceSinks(device, null!);
            }

            foreach (var device in AVDevice.VideoOutputDevices.Where(e => !e.Name.Equals("lavfi")))
            {
                if (deviceName != null && deviceName.Equals(device.Name))
                {
                    continue;
                }

                PrintDeviceSinks(device, null!);
            }
        }

        private static void PrintEncoders(AVCodecID id)
        {
            Console.Write($"(encoders: {string.Join(' ', AVCodec.All.Where(c => c.Id == id && c.IsEncoder).Select(c => c.Name))})");
        }

        private static void PrintDecoders(AVCodecID id)
        {
            Console.Write($"(decoders: {string.Join(' ', AVCodec.All.Where(c => c.Id == id && c.IsDecoder).Select(c => c.Name))})");
        }

        private static void PrintDeviceSources(AVInputFormat format, AVDictionary options)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (!format.IsInputDevice)
            {
                throw new ArgumentException("The specified input format is not an input device", nameof(format));
            }

            Console.WriteLine("Auto-detected sources for {0}:", format.Name);

            var devices = format.InputSources;
            if (devices == null)
            {
                Console.WriteLine("Cannot list sources. Not implemented.");
            }
            else
            {
                for (var deviceIndex = 0; deviceIndex < devices.Count; ++deviceIndex)
                {
                    Console.WriteLine("{0} {1} [{2}]",
                        devices.DefaultDeviceIndex == deviceIndex ? "*" : " ",
                        devices[deviceIndex].Name,
                        devices[deviceIndex].Description);
                }
            }
        }

        private static void PrintDeviceSinks(AVOutputFormat format, AVDictionary options)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (!format.IsOutputDevice)
            {
                throw new ArgumentException("The specified output format is not an output device", nameof(format));
            }

            Console.WriteLine("Auto-detected sinks for {0}:", format.Name);

            var devices = format.OutputSinks;
            if (devices == null)
            {
                Console.WriteLine("Cannot list sinks. Not implemented.");
            }
            else
            {
                for (var deviceIndex = 0; deviceIndex < devices.Count; ++deviceIndex)
                {
                    Console.WriteLine("{0} {1} [{2}]",
                        devices.DefaultDeviceIndex == deviceIndex ? "*" : " ",
                        devices[deviceIndex].Name,
                        devices[deviceIndex].Description);
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
