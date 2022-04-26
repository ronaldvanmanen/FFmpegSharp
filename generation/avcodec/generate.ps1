$temporaryFile = "settings.rsp.tmp"

$settings = Get-Content -Path .\settings.rsp -Raw
$settings = $settings -replace '\$HOME', $HOME
Set-Content -Path $temporaryFile -Value $settings

& dotnet tool run ClangSharpPInvokeGenerator "@$temporaryFile"