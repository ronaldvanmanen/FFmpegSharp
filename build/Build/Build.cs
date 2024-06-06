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
using Nuke.Common.CI.GitHubActions;

[GitHubActions("test-ubuntu",
    GitHubActionsImage.UbuntuLatest,
    FetchDepth = 0,
    ImportSecrets = ["AZURE_DEVOPS_PAT", "GITHUB_TOKEN"],
    InvokedTargets = [nameof(ITest.Test)],
    OnPushBranches = ["main", "releases/**", "develop"],
    OnPushTags = ["v*"],
    OnPullRequestBranches = ["main"]
)]
[GitHubActions("test-windows",
    GitHubActionsImage.WindowsLatest,
    FetchDepth = 0,
    ImportSecrets = ["AZURE_DEVOPS_PAT", "GITHUB_TOKEN"],
    InvokedTargets = [nameof(ITest.Test)],
    OnPushBranches = ["main", "releases/**", "develop"],
    OnPushTags = ["v*"],
    OnPullRequestBranches = ["main"]
)]
[GitHubActions("release",
    GitHubActionsImage.WindowsLatest,
    FetchDepth = 0,
    ImportSecrets = ["AZURE_DEVOPS_PAT", "GITHUB_TOKEN"],
    InvokedTargets = [nameof(IRelease.Release)],
    OnPushBranches = ["main", "releases/**", "develop"],
    OnPushTags = ["v*"],
    OnPullRequestBranches = ["main"]
)]
partial class Build
: NukeBuild
, IClean
, ISetup
, IRestore
, IGenerate
, ICompile
, ITest
, IPack
, IRelease
{
    public static int Main() => Execute<Build>(target => ((IPack)target).Pack);
}
