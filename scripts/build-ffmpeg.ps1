function Create-Directory([string[]] $Path) {
  if (!(Test-Path -Path $Path)) {
    New-Item -Path $Path -Force -ItemType "Directory" | Out-Null
  }
}

try {
  $LatestVersion = "4.4"

  $RepoRoot = Join-Path -Path $PSScriptRoot -ChildPath ".."

  $PackagesDir = Join-Path -Path $RepoRoot -ChildPath "packages"

  $ArtifactsDir = Join-Path -Path $RepoRoot -ChildPath "artifacts"
  Create-Directory -Path $ArtifactsDir

  $ArtifactsPkgDir = Join-Path $ArtifactsDir -ChildPath "pkg"
  Create-Directory -Path $ArtifactsPkgDir

  $StagingDir = Join-Path -Path $RepoRoot -ChildPath "staging"
  Create-Directory $StagingDir

  $DownloadsDir = Join-Path -Path $RepoRoot -ChildPath "downloads"
  Create-Directory -Path $DownloadsDir

  $DownloadUri = "https://github.com/GyanD/codexffmpeg/releases/download/$LatestVersion/ffmpeg-$LatestVersion-full_build-shared.zip"
  $DownloadPath = Join-Path $DownloadsDir "ffmpeg-$LatestVersion-full_build-shared.zip"
  $ExpandPath = Join-Path -Path $DownloadsDir -ChildPath "ffmpeg-$LatestVersion-full_build-shared"
  $PackageVersion = $LatestVersion

  if ($env:GITHUB_RUN_ID) {
    if (-not $env:EXCLUDE_RUN_ID_FROM_PACKAGE) {
      $PackageVersion = "$LatestVersion-$($env:GITHUB_RUN_ID)"
    }
  }

  if (!(Test-Path $ExpandPath))
  {
    if (!(Test-Path $DownloadPath)) {
      Write-Host "Downloading FFmpeg development libraries version $LatestVersion to '$DownloadPath' ..." -ForegroundColor Yellow
      (New-Object System.Net.WebClient).DownloadFile($DownloadUri, $DownloadPath)
    }

    Write-Host "Extracting FFmpeg development libraries version $LatestVersion ... to '$DownloadsDir'" -ForegroundColor Yellow
    Expand-Archive -Path $DownloadPath -DestinationPath $DownloadsDir -Force
  }

  Copy-Item -Path $PackagesDir\ffmpeg -Destination $StagingDir -Force -Recurse
  Copy-Item -Path "$ExpandPath\LICENSE" -Destination "$StagingDir\ffmpeg" -Force -Recurse
  Copy-Item -Path "$ExpandPath\README.txt" -Destination "$StagingDir\ffmpeg" -Force -Recurse

  Copy-Item -Path $PackagesDir\ffmpeg.runtime.win-x64 -Destination $StagingDir -Force -Recurse
  Copy-Item -Path "$ExpandPath\LICENSE" -Destination "$StagingDir\ffmpeg.runtime.win-x64" -Force -Recurse
  Copy-Item -Path "$ExpandPath\README.txt" -Destination "$StagingDir\ffmpeg.runtime.win-x64" -Force -Recurse
  Copy-Item -Path "$ExpandPath\bin\avcodec-58.dll" -Destination "$StagingDir\ffmpeg.runtime.win-x64" -Force
  Copy-Item -Path "$ExpandPath\bin\avdevice-58.dll" -Destination "$StagingDir\ffmpeg.runtime.win-x64" -Force
  Copy-Item -Path "$ExpandPath\bin\avfilter-7.dll" -Destination "$StagingDir\ffmpeg.runtime.win-x64" -Force
  Copy-Item -Path "$ExpandPath\bin\avformat-58.dll" -Destination "$StagingDir\ffmpeg.runtime.win-x64" -Force
  Copy-Item -Path "$ExpandPath\bin\avutil-56.dll" -Destination "$StagingDir\ffmpeg.runtime.win-x64" -Force
  Copy-Item -Path "$ExpandPath\bin\postproc-55.dll" -Destination "$StagingDir\ffmpeg.runtime.win-x64" -Force
  Copy-Item -Path "$ExpandPath\bin\swresample-3.dll" -Destination "$StagingDir\ffmpeg.runtime.win-x64" -Force
  Copy-Item -Path "$ExpandPath\bin\swscale-5.dll" -Destination "$StagingDir\ffmpeg.runtime.win-x64" -Force

  $RuntimeContent = Get-Content "$StagingDir\ffmpeg\runtime.json" -Raw
  $RuntimeContent = $RuntimeContent.replace('$version$', $PackageVersion)
  Set-Content "$StagingDir\ffmpeg\runtime.json" $RuntimeContent

  & nuget pack "$StagingDir\ffmpeg\ffmpeg.nuspec" -Properties version=$PackageVersion -OutputDirectory "$ArtifactsPkgDir"
  if ($LastExitCode -ne 0) {
    throw "'nuget pack' failed for 'ffmpeg.nuspec'"
  }
  
  & nuget pack "$StagingDir\ffmpeg.runtime.win-x64\ffmpeg.runtime.win-x64.nuspec" -Properties version=$PackageVersion -OutputDirectory "$ArtifactsPkgDir"
  if ($LastExitCode -ne 0) {
    throw "'nuget pack' failed for 'ffmpeg.runtime.win-x64.nuspec'"
  }
}
catch {
  Write-Host -Object $_
  Write-Host -Object $_.Exception
  Write-Host -Object $_.ScriptStackTrace
  exit 1
}
