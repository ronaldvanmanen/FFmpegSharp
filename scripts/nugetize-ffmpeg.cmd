@ECHO OFF
powershell.exe -NoLogo -NoProfile -ExecutionPolicy ByPass -Command "& """%~dp0nugetize-ffmpeg.ps1""" %*"
EXIT /B %ERRORLEVEL%
