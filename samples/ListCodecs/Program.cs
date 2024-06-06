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
using System.Linq;
using FFmpegSharp;

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
    Console.Write(descriptor.Type switch
    {
        AVMediaType.Video => 'V',
        AVMediaType.Audio => 'A',
        AVMediaType.Data => 'D',
        AVMediaType.Subtitle => 'S',
        AVMediaType.Attachment => 'T',
        _ => '?',
    });
    Console.Write(descriptor.Properties.HasFlag(AVCodecProperties.IntraCompressionOnly) ? "I" : ".");
    Console.Write(descriptor.Properties.HasFlag(AVCodecProperties.LossyCompression) ? "L" : ".");
    Console.Write(descriptor.Properties.HasFlag(AVCodecProperties.LosslessCompression) ? "S" : ".");
    Console.Write(" {0,-20} {1} ", descriptor.Name, descriptor.LongName ?? string.Empty);

    var decoders = AVCodec.All
        .Where(e => e.IsDecoder && e.Name == descriptor.Name)
        .Select(c => c.Name)
        .ToList();
    if (decoders.Any())
    {
        Console.Write($"(decoders: {string.Join(" ", decoders)})");
    }

    var encoders = AVCodec.All
        .Where(e => e.IsEncoder && e.Name == descriptor.Name)
        .Select(c => c.Name)
        .ToList();
    if (encoders.Any())
    {
        Console.Write($"(encoders: {string.Join(" ", encoders)})");
    }

    Console.WriteLine();
}
