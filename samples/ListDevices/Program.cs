using System;
using System.Collections.Generic;
using System.Linq;
using FFmpegSharp;

AVDevice.RegisterAll();

Console.WriteLine("Devices:");
Console.WriteLine(" D. = Demuxing supported");
Console.WriteLine(" .E = Muxing supported");
Console.WriteLine(" --");

var inputFormats = AVInputFormat.All.Where(inputFormat => inputFormat.IsDevice);
var inputFormatNames = inputFormats.Select(inputFormat => inputFormat.Name);
var inputFormatLookup = new Dictionary<string, AVInputFormat>();
foreach (var inputFormat in inputFormats)
{
    inputFormatLookup.Add(inputFormat.Name, inputFormat);
}

var outputFormats = AVOutputFormat.All.Where(inputFormat => inputFormat.IsDevice);
var outputFormatNames = outputFormats.Select(outputFormat => outputFormat.Name);
var outputFormatLookup = new Dictionary<string, AVOutputFormat>();
foreach (var outputFormat in outputFormats)
{
    outputFormatLookup.Add(outputFormat.Name, outputFormat);
}

var formatNames = Enumerable.Union(inputFormatNames, outputFormatNames);
foreach (var formatName in formatNames.OrderBy(e => e))
{
    var hasInputFormat = inputFormatLookup.TryGetValue(formatName, out var inputFormat);
    var hasOutputFormat = inputFormatLookup.TryGetValue(formatName, out var outputFormat);
    var formatLongName = inputFormat?.LongName ?? outputFormat?.LongName;

    Console.WriteLine(" {0}{1} {2,-15} {3}",
        hasInputFormat ? "D" : " ",
        hasOutputFormat ? "E" : " ",
        formatName,
        formatLongName ?? " ");
}
