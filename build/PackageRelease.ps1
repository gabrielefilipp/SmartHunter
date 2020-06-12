param([string]$Configuration="release")

#Requires -Version 5.1
$scriptPath = Split-Path $MyInvocation.MyCommand.Path
$release = Join-Path $scriptPath "..\SmartHunter\bin\$Configuration\"
$zip = Join-Path $release "SmartHunter.zip"

$fileList =
    "SmartHunter.exe",
    "Newtonsoft.Json.dll",
    "Default.xaml"

$Error.Clear()

Push-Location $release
Compress-Archive -LiteralPath $fileList -DestinationPath $zip -Force
Pop-Location

if($Error)
{
    exit 1
}

exit 0
