@ECHO OFF
powershell.exe -NoLogo -NoProfile -ExecutionPolicy ByPass -Command "& """%~dp0build-ffmpeg.ps1""" %*"
EXIT /B %ERRORLEVEL%
