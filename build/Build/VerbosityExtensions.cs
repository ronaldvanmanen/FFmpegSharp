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
using Nuke.Common;
using Nuke.Common.Tools.DotNet;

static class VerbosityExtensions
{
    public static DotNetVerbosity ToDotNetVerbosity(this Verbosity verbosity)
    {
        return verbosity switch
        {
            Verbosity.Quiet => DotNetVerbosity.quiet,
            Verbosity.Minimal => DotNetVerbosity.minimal,
            // Note: normal verbosity is way to detailed
            Verbosity.Normal => DotNetVerbosity.minimal,
            Verbosity.Verbose => DotNetVerbosity.diagnostic,
            _ => throw new ArgumentException($"Unknown verbosity {verbosity}"),
        };
    }
}