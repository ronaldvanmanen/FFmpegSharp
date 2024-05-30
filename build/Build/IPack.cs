﻿// Copyright (c) 2021-2023 Ronald van Manen
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

using Nuke.Common;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.PowerShell;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

interface IPack : IBuild
{
    public Target Pack => _ => _
        .DependsOn<ITest>(target => target.Test)
        .Produces(ArtifactsDirectory / "pkg" / "*.*", ArtifactsDirectory / "log" / "*.*")
        .Executes(() =>
        {
            DotNetPack(settings => settings
                .SetProject(Solution)
                .SetConfiguration(Configuration)
                .SetVersion(GitVersion.NuGetVersionV2)
                .SetNoBuild(true)
                .SetNoRestore(true)
                .SetVerbosity(Verbosity.ToDotNetVerbosity())
            );
        });
}
