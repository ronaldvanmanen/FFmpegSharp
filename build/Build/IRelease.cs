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

using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.NuGet;
using static Nuke.Common.Tools.NuGet.NuGetTasks;

interface IRelease : IBuild
{
    public Target Release => _ => _
        .DependsOn<IPack>(target => target.Pack)
        .Produces(ArtifactsDirectory / "log" / "*.*")
        .Executes(() =>
        {
            var packagesDirectory = ArtifactsDirectory / "pkg" / "Release";
            var packages = packagesDirectory.GlobFiles("*.nupkg");
            foreach (var package in packages)
            {
                PublishOnAzure(package);
                PublishOnGitHub(package);
            }
        });

    void PublishOnAzure(AbsolutePath packagePath)
    {
        NuGetPush(settings => settings
            .SetTargetPath(packagePath)
            .SetSource("https://pkgs.dev.azure.com/ronaldvanmanen/_packaging/ronaldvanmanen/nuget/v3/index.json")
            .SetApiKey("AzureDevOps")
            .SetNonInteractive(IsServerBuild)
            .SetProcessArgumentConfigurator(arguments => arguments.Add("-SkipDuplicate"))
        );
    }

    void PublishOnGitHub(AbsolutePath packagePath)
    {
        NuGetPush(settings => settings
            .SetTargetPath(packagePath)
            .SetSource("https://nuget.pkg.github.com/ronaldvanmanen/index.json")
            .SetApiKey(GitHubActions.Token)
            .SetNonInteractive(IsServerBuild)
            .SetProcessArgumentConfigurator(arguments => arguments.Add("-SkipDuplicate"))
        );
    }
}
