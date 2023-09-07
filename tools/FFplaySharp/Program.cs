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
using System.Reflection;
using FFmpegSharp;
using Microsoft.Extensions.Logging;
using static System.Linq.Enumerable;

namespace FFplaySharp
{
    internal static class Program
    {
        private static readonly ILogger _logger;

        static Program()
        {
            var loggerFactory = LoggerFactory.Create(
                builder => builder.AddConsole());
            _logger = loggerFactory.CreateLogger("FFplaySharp");
        }

        static int Main(string[] args)
        {
            try
            {
                Initialize();
                var exitCode = Run(args);
                return exitCode;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured while running FFplaySharp.");

                return -1;
            }
            finally
            {
                Deinitialize();
            }
        }

        private static int Run(string[] args)
        {
            var rootCommand = new RootCommand("Simple media player based on FFplay");

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
                .UseShowFiltersOption()
                .UseShowPixelFormatsOption()
                .UseShowStandardChannelLayoutsOption()
                .UseShowSampleFormatsOption()
                .UseShowColorsOption()
                .UseShowSourcesOption()
                .UseShowSinksOption();

            var optionsBinder = new PlaybackOptionsBinder();
            commandLineBuilder.Command.AddComposite(optionsBinder);
            rootCommand.SetHandler(context =>
            {
                var options = context.GetValueFor(optionsBinder);
                if (options is null)
                {
                    _logger.LogError("Required argument(s) and/or option(s) missing.");
                    context.ExitCode = -1;
                    return;
                }
                else
                {
                    var exitCode = PlaybackInput(options);
                    context.ExitCode = exitCode;
                    return;
                }
            });

            return commandLineBuilder.Build().Invoke(args);
        }

        private static void Initialize()
        {
            AVDevice.RegisterAll();
            AVFormat.NetworkInit();
        }

        private static void Deinitialize()
        {
            AVFormat.NetworkDeinit();
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

        private static CommandLineBuilder UseShowPixelFormatsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--pixel-formats", "Show available pixel formats", ShowPixelFormats);
        }

        private static CommandLineBuilder UseShowStandardChannelLayoutsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--channel-layouts", "Show standard channel layouts", () => ShowStandardChannelLayouts());
        }

        private static CommandLineBuilder UseShowSampleFormatsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--sample-formats", "Show available audio sample formats", ShowSampleFormats);
        }

        private static CommandLineBuilder UseShowColorsOption(this CommandLineBuilder builder)
        {
            return builder.AddGlobalOption("--colors", "Show available color names", ShowColors);
        }

        private static CommandLineBuilder UseShowSourcesOption(this CommandLineBuilder builder)
        {
            var completions = AVInputFormat.All.Where(e => e.IsDevice)
                .SelectMany(e => e.Name.Split(','))
                .ToArray();
            return builder.AddGlobalOption("--sources", "device name", "List sources of the input device", completions, ShowSources);
        }

        private static CommandLineBuilder UseShowSinksOption(this CommandLineBuilder builder)
        {
            var completions = AVOutputFormat.All.Where(e => e.IsDevice)
                .SelectMany(e => e.Name.Split(','))
                .ToArray();
            return builder.AddGlobalOption("--sinks", "device name", "List sinks of the output device", completions, ShowSinks);
        }

        private static void ShowVersion()
        {
            PrintProgramInfo();
            PrintBuildConfiguration();
            PrintAllLibraryInfo();
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

        private static void ShowPixelFormats()
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

        private static void ShowStandardChannelLayouts()
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

        private static void ShowSampleFormats()
        {
            var sampleFormats = Enum.GetValues<AVSampleFormat>();
            foreach (var sampleFormat in sampleFormats.OrderBy(e => e))
            {
                Console.WriteLine("{0}", sampleFormat.AsString());
            }
        }

        private static void ShowColors()
        {
            Console.WriteLine("{0,-32} #RRGGBB", "name");

            foreach (var color in AVKnownColor.All)
            {
                Console.WriteLine("{0,-32} #{1:X2}{2:X2}{3:X2}", color.Name, color.R, color.G, color.B);
            }
        }

        private static void ShowSources(string deviceName)
        {
            // Note: it's pointless to probe lavfi (see 'show_sources' in ffplay.c)
            var devices = AVDevice.InputDevices.Where(e => !e.Name.Equals("lavfi") && e.Name.Contains(deviceName));
            foreach (var device in devices)
            {
                PrintSources(device);
            }
        }

        private static void ShowSinks(string deviceName)
        {
            var devices = AVDevice.OutputDevices.Where(e => e.Name.Contains(deviceName));
            foreach (var device in devices)
            {
                PrintDeviceSinks(device);
            }
        }

        private static int PlaybackInput(PlaybackOptions options)
        {
            try
            {
                var app = new PlaybackApp(options);
                options.CancellationToken.Register(app.Quit);
                return app.Run();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured while running FFplaySharp.");

                return -1;
            }
        }

        private static void PrintProgramInfo()
        {
            var title = GetApplicationName();
            var version = GetApplicationVersion();
            var copyright = GetApplicationCopyright();

            Console.WriteLine($"{title} {version} {copyright}");
        }

        private static void PrintBuildConfiguration()
        {
            Console.WriteLine($"configuration: {AVUtil.BuildConfiguration}");
        }

        private static void PrintAllLibraryInfo()
        {
            PrintLibraryInfo("avutil");
            PrintLibraryInfo("avcodec");
            PrintLibraryInfo("avformat");
            PrintLibraryInfo("avdevice");
            PrintLibraryInfo("avfilter");
            PrintLibraryInfo("swresample");
            PrintLibraryInfo("swscale");
        }

        private static void PrintLibraryInfo(string libraryName)
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

        private static void PrintFormats(bool showMuxers, bool showDemuxers, bool showDevicesOnly)
        {
            Console.WriteLine(showDevicesOnly ? "Devices:" : "File formats:");
            Console.WriteLine(" D. = Demuxing supported");
            Console.WriteLine(" .E = Muxing supported");
            Console.WriteLine(" --");

            var inputFormats = showDemuxers ? AVOutputFormat.All : Empty<AVOutputFormat>();
            var inputFormatLookup = inputFormats.ToLookup(inputFormat => inputFormat.Name);
            var inputFormatNames = inputFormats.Select(inputFormat => inputFormat.Name);

            var outputFormats = showMuxers ? AVInputFormat.All : Empty<AVInputFormat>();
            var outputFormatLookup = outputFormats.ToLookup(outputFormat => outputFormat.Name);
            var outputFormatNames = outputFormats.Select(outputFormat => outputFormat.Name);

            var formatNames = Enumerable.Union(inputFormatNames, outputFormatNames);
            var formats = from formatName in formatNames
                          from inputFormat in inputFormatLookup[formatName].DefaultIfEmpty()
                          from outputFormat in outputFormatLookup[formatName].DefaultIfEmpty()
                          select new
                          {
                              Name = inputFormat?.Name ?? outputFormat?.Name,
                              LongName = inputFormat?.LongName ?? outputFormat?.LongName,
                              IsDevice = inputFormat?.IsDevice ?? outputFormat?.IsDevice ?? false,
                              IsDecoder = inputFormat is not null,
                              IsEncoder = outputFormat is not null,
                          };

            foreach (var format in formats.OrderBy(e => e.Name))
            {
                if (!showDevicesOnly || format.IsDevice)
                {
                    Console.WriteLine(" {0}{1} {2,-15} {3}",
                        format.IsDecoder ? "D" : " ",
                        format.IsEncoder ? "E" : " ",
                        format.Name,
                        format.LongName ?? " ");
                }
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

        private static void PrintSources(AVInputFormat format)
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

        private static void PrintDeviceSinks(AVOutputFormat format)
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

        private static string? GetApplicationName()
        {
            var titleAttribute = GetAttribute<AssemblyTitleAttribute>();
            var title = titleAttribute?.Title ?? GetAssemblyName();
            return title;
        }

        private static string? GetApplicationVersion()
        {
            var versionAttribute = GetAttribute<AssemblyInformationalVersionAttribute>();
            var version = versionAttribute?.InformationalVersion ?? GetAssemblyVersion();
            return version;
        }

        private static string? GetApplicationCopyright()
        {
            var copyrightAttribute = GetAttribute<AssemblyCopyrightAttribute>();
            var copyright = copyrightAttribute?.Copyright;
            return copyright;
        }

        private static string? GetAssemblyName()
        {
            var assembly = GetExecutingOrEntryAssembly();
            var assemblyName = assembly.GetName();
            return assemblyName.Name;
        }

        private static string? GetAssemblyVersion()
        {
            var assembly = GetExecutingOrEntryAssembly();
            var assemblyName = assembly.GetName();
            return assemblyName.Version?.ToString();
        }

        private static Assembly GetExecutingOrEntryAssembly()
        {
            return Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
        }

        private static TAttribute? GetAttribute<TAttribute>() where TAttribute : Attribute
        {
            var assembly = GetExecutingOrEntryAssembly();
            var attribute = assembly.GetCustomAttribute<TAttribute>();
            return attribute;
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
