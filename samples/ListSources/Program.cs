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
using System.CommandLine.Builder;
using System.CommandLine;
using System.Linq;
using FFmpegSharp;
using System.CommandLine.Parsing;

AVDevice.RegisterAll();


var rootCommand = new RootCommand("List all available sources of an input device.");

var commandLineBuilder = new CommandLineBuilder(rootCommand)
    .UseHelp()
    .UseEnvironmentVariableDirective()
    .UseParseDirective()
    .UseSuggestDirective()
    .RegisterWithDotnetSuggest()
    .UseTypoCorrections()
    .UseParseErrorReporting()
    .UseExceptionHandler();

var deviceNameArgument = new Argument<string>("device-name", "The name of the input device to list the sources of.");
deviceNameArgument.AddCompletions(_ => AVDevice.InputDevices.Where(e => !e.Name.Equals("lavfi")).SelectMany(e => e.Name.Split(',')));
commandLineBuilder.Command.AddArgument(deviceNameArgument);

rootCommand.SetHandler(deviceName =>
{
    var inputDevices = AVDevice.InputDevices.Where(e => e.Name.Contains(args[0]));
    foreach (var inputDevice in inputDevices)
    {
        Console.WriteLine("Auto-detected sources for {0}:", inputDevice.Name);

        var inputSources = inputDevice.InputSources;
        if (inputSources == null)
        {
            Console.WriteLine("Cannot list sources. Not implemented.");
        }
        else
        {
            for (var inputSourceIndex = 0; inputSourceIndex < inputSources.Count; ++inputSourceIndex)
            {
                Console.WriteLine("{0} {1} [{2}]",
                    inputSources.DefaultDeviceIndex == inputSourceIndex ? "*" : " ",
                    inputSources[inputSourceIndex].Name,
                    inputSources[inputSourceIndex].Description);
            }
        }
    }
}, deviceNameArgument);

return commandLineBuilder.Build().Invoke(args);
