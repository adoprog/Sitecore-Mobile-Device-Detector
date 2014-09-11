Clear-Host

remove-module [p]sake
import-module .\Tools\psake\psake.psm1

$psake.use_exit_on_error = $true 
Invoke-psake .\build.ps1 Package -properties @{ buildNumber = '123'; }