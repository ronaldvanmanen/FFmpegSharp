// Copyright (C) 2021-2024 Ronald van Manen
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

var rootCommand = new RootCommand("List all available sinks of an output device.");

var commandLineBuilder = new CommandLineBuilder(rootCommand)
    .UseHelp()
    .UseEnvironmentVariableDirective()
    .UseParseDirective()
    .UseSuggestDirective()
    .RegisterWithDotnetSuggest()
    .UseTypoCorrections()
    .UseParseErrorReporting()
    .UseExceptionHandler();

var deviceNameArgument = new Argument<string>("device-name", "The name of the output device to list the sinks of.");
deviceNameArgument.AddCompletions(_ => AVDevice.OutputDevices.SelectMany(e => e.Name.Split(',')));
commandLineBuilder.Command.AddArgument(deviceNameArgument);

rootCommand.SetHandler(deviceName =>
{
    var outputDevices = AVDevice.OutputDevices.Where(e => e.Name.Contains(deviceName));
    foreach (var outputDevice in outputDevices)
    {
        Console.WriteLine("Auto-detected sources for {0}:", outputDevice.Name);

        var outputSinks = outputDevice.OutputSinks;
        if (outputSinks == null)
        {
            Console.WriteLine("Cannot list sinks. Not implemented.");
        }
        else
        {
            for (var outputSinkIndex = 0; outputSinkIndex < outputSinks.Count; ++outputSinkIndex)
            {
                Console.WriteLine("{0} {1} [{2}]",
                    outputSinks.DefaultDeviceIndex == outputSinkIndex ? "*" : " ",
                    outputSinks[outputSinkIndex].Name,
                    outputSinks[outputSinkIndex].Description);
            }
        }
    }
}, deviceNameArgument);

return commandLineBuilder.Build().Invoke(args);
