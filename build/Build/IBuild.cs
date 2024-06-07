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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using NuGet.Configuration;
using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.GitVersion;
using static System.Runtime.InteropServices.RuntimeInformation;
using static System.Runtime.InteropServices.Architecture;

partial interface IBuild : INukeBuild
{
    [Solution]
    public Solution Solution => TryGetValue(() => Solution);

    [GitVersion]
    public GitVersion GitVersion => TryGetValue(() => GitVersion);
 
    [Parameter("Configuration to build. Default is 'Debug' (local) or 'Release' (server).")]
    public Configuration Configuration => TryGetValue(() => Configuration) ?? GetDefaultConfiguration();

    [Parameter("Platform architecture to use for testing. Default is the processor architecture of the underlying operating system.")]
    public string Architecture => TryGetValue(() => Architecture) ?? GetDefaultArchitecture();

    protected string OverrideRuntimeIdentifier
    {
        get
        {
            var architecture = TryGetValue(() => Architecture);
            if (string.IsNullOrWhiteSpace(architecture))
            {
                return null;
            }
            if (IsOSPlatform(OSPlatform.Linux))
            {
                return $"linux-{architecture}";
            }
            if (IsOSPlatform(OSPlatform.OSX))
            {
                return $"osx-{architecture}";
            }
            if (IsOSPlatform(OSPlatform.Windows))
            {
                return $"win-{architecture}";
            }
            throw new PlatformNotSupportedException();
        }
    }

    protected AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    protected AbsolutePath GlobalPackagesFolder => AbsolutePath.Create(SettingsUtility.GetGlobalPackagesFolder(Settings.LoadDefaultSettings(null)));

    protected GitHubActions GitHubActions => GitHubActions.Instance;

    private Configuration GetDefaultConfiguration() => IsLocalBuild ? Configuration.Debug : Configuration.Release;

    private static string GetDefaultArchitecture()
    {
        return OSArchitecture switch
        {
            X86 => "x86",
            X64 => "x64",
            Arm => "arm",
            Arm64 => "arm64",
            S390x => "s390x",
            Ppc64le => "ppc64le",
            _ => throw new PlatformNotSupportedException(),
        };
    }

    protected IReadOnlyCollection<string> GetTargetFrameworks()
    {
        return GetTargetFrameworks(_ => true);
    }

    protected IReadOnlyCollection<string> GetTargetFrameworks(Func<Project, bool> predicate)
    {
        var targetFrameworkRegex = GetTargetFrameworkRegex();
        return Solution.AllProjects
            .Where(predicate)
            .SelectMany((project) => project.GetTargetFrameworks())
            .Distinct()
            .Order()
            .ToList()
            .AsReadOnly();
    }

    protected IReadOnlyCollection<Version> GetTargetFrameworkVersions()
    {
        var targetFrameworkRegex = GetTargetFrameworkRegex();
        return GetTargetFrameworks()
            .Select((framework) => targetFrameworkRegex.Match(framework))
            .Where((match) => match.Success)
            .Select((match) =>
            {
                if (match.Groups["MajorMinorVersion"].Success)
                {
                    return new Version(match.Groups["MajorMinorVersion"].Value);
                }
                else
                {
                    var versionString = match.Groups["MajorVersion"].Value + '.' + match.Groups["MinorVersion"].Value;
                    if (match.Groups["PatchVersion"].Success)
                    {
                        versionString += '.' + match.Groups["PatchVersion"].Value;
                    }
                    return new Version(versionString);
                }
            })
            .Distinct()
            .Order()
            .ToList()
            .AsReadOnly();
    }

    [GeneratedRegex("^net(?<MajorMinorVersion>\\d+\\.\\d+)|((?<MajorVersion>\\d)(?<MinorVersion>\\d)(?<PatchVersion>\\d)?)$")]
    private static partial Regex GetTargetFrameworkRegex();
}
