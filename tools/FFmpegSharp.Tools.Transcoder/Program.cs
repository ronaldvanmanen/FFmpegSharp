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
using System.CommandLine.Parsing;
using FFmpegSharp.Tools.Shared;
using Microsoft.Extensions.Logging;

namespace FFmpegSharp.Tools.Transcoder
{
    internal static class Program
    {
        private static readonly ILogger _logger;

        static Program()
        {
            var loggerFactory = LoggerFactory.Create(
                builder => builder.AddConsole());
            _logger = loggerFactory.CreateLogger("FFmpegSharp.Tools.Transcoder");
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
                _logger.LogError(e, "An error occured while running FFmpegSharp.");

                return -1;
            }
            finally
            {
                Deinitialize();
            }
        }

        private static int Run(string[] args)
        {
            var rootCommand = new RootCommand("Simple media transcoder based on FFmpeg");

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

            var optionsBinder = new TranscodeOptionsBinder();
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
                    var exitCode = Transcode(options);
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

        private static int Transcode(TranscodeOptions options)
        {
            try
            {
                var app = new TranscodeApp(options);
                options.CancellationToken.Register(app.Quit);
                return app.Run();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured while running FFmpegSharp.Tools.Transcoder.");

                return -1;
            }
        }
    }
}
