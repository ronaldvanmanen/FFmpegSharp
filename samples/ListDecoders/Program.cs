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

Console.WriteLine("Decoders:");
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
    foreach (var codec in AVCodec.All.Where(c => c.Id == descriptor.Id && c.IsDecoder))
    {
        Console.Write(" ");
        Console.Write(descriptor.Type switch
        {
            AVMediaType.Video => 'V',
            AVMediaType.Audio => 'A',
            AVMediaType.Data => 'D',
            AVMediaType.Subtitle => 'S',
            AVMediaType.Attachment => 'T',
            _ => '?',
        });
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
