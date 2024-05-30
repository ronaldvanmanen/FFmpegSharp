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
using System.Text;
using FFmpegSharp;

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
    var descriptor = new StringBuilder();

    if (filter.Inputs.Any())
    {
        foreach (var input in filter.Inputs)
        {
            descriptor.Append(AsChar(input.Type));
        }
    }
    else
    {
        if (filter.Flags.HasFlag(AVFilterFlags.DynamicInputs))
        {
            descriptor.Append('N');
        }
        else
        {
            descriptor.Append('|');
        }
    }

    descriptor.Append("->");

    if (filter.Outputs.Any())
    {
        foreach (var output in filter.Outputs)
        {
            descriptor.Append(AsChar(output.Type));
        }
    }
    else
    {
        if (filter.Flags.HasFlag(AVFilterFlags.DynamicOutputs))
        {
            descriptor.Append('N');
        }
        else
        {
            descriptor.Append('|');
        }
    }

    Console.WriteLine(" {0}{1}{2} {3,-17} {4,-10} {5}",
           filter.Flags.HasFlag(AVFilterFlags.SupportTimeline) ? 'T' : '.',
           filter.Flags.HasFlag(AVFilterFlags.SliceThreads) ? 'S' : '.',
           filter.CanProcessCommand ? 'C' : '.',
           filter.Name,
           descriptor,
           filter.Description);
}

static char AsChar(AVMediaType mediaType)
{
    return mediaType switch
    {
        AVMediaType.Video => 'V',
        AVMediaType.Audio => 'A',
        AVMediaType.Data => 'D',
        AVMediaType.Subtitle => 'S',
        AVMediaType.Attachment => 'T',
        _ => '?',
    };
}
