Push-Location $PSScriptRoot
& dotnet tool run ClangSharpPInvokeGenerator "@settings.rsp"
Pop-Location
