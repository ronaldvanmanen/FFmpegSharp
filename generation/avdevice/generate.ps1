try {
  $RepoRoot = Join-Path -Path $PSScriptRoot -ChildPath "..\.."
  
  Push-Location $PSScriptRoot

  $PackageList = (dotnet list "$RepoRoot\sources\FFmpegSharp.Interop\FFmpegSharp.Interop.csproj" package)
  $PackageName = "FFmpeg"
  $PackageFound = "$PackageList" -match " +> $PackageName +(?<requestedVersion>[^ ]+) +(?<resolvedVersion>[^ ]+)"
  if (-not $PackageFound)
  {
    throw "Package $PackageName not found in top-level packages of project."
  }
  
  $PackageVersion = $Matches.resolvedVersion
  $PackageDirectory = "$HOME\.nuget\packages\FFmpeg\$PackageVersion"

  $Settings = Get-Content -Path ".\settings.rsp" -Raw
  $Settings = $Settings -replace '\$PackageDirectory', $PackageDirectory
  Set-Content -Path ".\settings.rsp.tmp" -Value $Settings

  & dotnet tool run ClangSharpPInvokeGenerator "@settings.rsp.tmp"

  Pop-Location
}
catch {
  Write-Host -Object $_
  Write-Host -Object $_.Exception
  Write-Host -Object $_.ScriptStackTrace
  exit 1
}
