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
using FFmpegSharp;

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
    Console.WriteLine("{0}{1}{2}{3}{4} {5,-16}       {6:D}            {7:D2}",
        descriptor.PixelFormat.IsSupportedInputFormat() ? 'I' : '.',
        descriptor.PixelFormat.IsSupportedOutputFormat() ? 'O' : '.',
        descriptor.Flags.HasFlag(AVPixelFormatFlags.HardwareAcceleration) ? 'H' : '.',
        descriptor.Flags.HasFlag(AVPixelFormatFlags.Pal) ? 'P' : '.',
        descriptor.Flags.HasFlag(AVPixelFormatFlags.Bitstream) ? 'B' : '.',
        descriptor.Name,
        descriptor.ComponentsPerPixel,
        descriptor.BitsPerPixel);
}
