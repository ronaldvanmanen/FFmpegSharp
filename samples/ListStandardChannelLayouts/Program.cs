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
using System.Linq;
using FFmpegSharp;

Console.WriteLine("Individual channels:");
Console.WriteLine("NAME           DESCRIPTION");

foreach (AVChannels channel in Enum.GetValues(typeof(AVChannels)))
{
    var name = channel.GetName();
    var description = channel.GetDescription();
    Console.WriteLine("{0,-14} {1}", name, description);
}

Console.WriteLine();
Console.WriteLine("Standard channel layouts:");
Console.WriteLine("NAME           DECOMPOSITION");

foreach (AVStandardChannelLayout channelLayout in AVStandardChannelLayout.All)
{
    var name = channelLayout.Name;
    var decomposition = string.Join("+", channelLayout.Layout.GetChannels().Select(e => e.GetName()));
    Console.WriteLine("{0,-14} {1}", name, decomposition);
}
