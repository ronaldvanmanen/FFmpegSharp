try {
  $PackageList = (dotnet list ..\..\sources\FFmpegSharp.Interop\FFmpegSharp.Interop.csproj package)
  $PackageName = "FFmpeg"
  $Package = $PackageList | Select-String -Pattern "^ +> $PackageName +"
  $PackageVersionFound = $Package -match "^ +> $PackageName +(?<requestedVersion>[^ ]+) +(?<resolvedVersion>[^ ]+)"
  if (-not $PackageVersionFound)
  {
    throw "$PackageName version not found"
  }

  $PackageVersion = $Matches.resolvedVersion
  $PackageDirectory = "$HOME\.nuget\packages\$PackageName\$PackageVersion"

  $Settings = Get-Content -Path .\settings.rsp -Raw
  $Settings = $Settings -replace '\$PackageDirectory', $PackageDirectory
  $TemporarySettingsFile = "settings.rsp.tmp"
  Set-Content -Path $TemporarySettingsFile -Value $Settings

  & dotnet tool run ClangSharpPInvokeGenerator "@$TemporarySettingsFile"
}
catch {
  Write-Host -Object $_
  Write-Host -Object $_.Exception
  Write-Host -Object $_.ScriptStackTrace
  exit 1
}
