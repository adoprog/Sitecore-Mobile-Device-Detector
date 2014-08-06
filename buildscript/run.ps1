Clear-Host

remove-module [p]sake
$ScriptDir = Split-Path -parent $MyInvocation.MyCommand.Path
import-module $ScriptDir\Tools\Psake\psake.psm1

$psake.use_exit_on_error = $true 
Invoke-psake $ScriptDir\build.ps1 Package -properties @{ buildNumber = '123'; }