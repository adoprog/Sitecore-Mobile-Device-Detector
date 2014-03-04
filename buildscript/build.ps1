# Framework Initialization
$scriptRoot = Split-Path (Resolve-Path $myInvocation.MyCommand.Path)
$env:PSModulePath = $env:PSModulePath + ";$scriptRoot\Tools\PowerCore\Framework"

Import-Module WebUtils
Import-Module ConfigUtils
Import-Module DBUtils
Import-Module IISUtils
Import-Module FileUtils

$scriptRoot = Split-Path (Resolve-Path $myInvocation.MyCommand.Path)

if (-not (test-path "$env:ProgramFiles\7-Zip\7z.exe")) {throw "$env:ProgramFiles\7-Zip\7z.exe needed"} 
set-alias sz "$env:ProgramFiles\7-Zip\7z.exe" 

properties {
    $projectName = "MobileDeviceDetector.Build"
    $distributivePath = "C:\LocalStorage\Sitecore 7.1 rev. 130926.zip"
    $distributiveName = [System.IO.Path]::GetFileNameWithoutExtension($distributivePath)
    $localStorage = "C:\LocalStorage"
    $zipFile = "$localStorage\$distributiveName.zip"
    $buildFolder = Resolve-Path .. 
    $buildNumber = "15"
    $licensePath = "$localStorage\license.xml"  
    $outputFolder = "$buildFolder\Output" 
    $dataFolder = "$outputFolder\Data"
    $websiteFolder = "$outputFolder\Website"
	$databasesFolder = "$outputFolder\Databases"
    $sqlServerName = "$env:COMPUTERNAME\SQLEXPRESS"
    $webserver = "C:\Program Files (x86)\Common Files\microsoft shared\DevServer\11.0\webdev.webserver40.exe"
}

task Package -depends Init, Create-Databases, Run-WebServer, Create-Package, Clean {
}

function Remove-Resources {
    gps WebDev.WebServer40 -ErrorAction SilentlyContinue | kill -verbose -Force

    $server = New-Object ("Microsoft.SqlServer.Management.Smo.Server") $sqlServerName
    $databases = "core", "master", "web"
    foreach ($db in $databases)
    {
        Drop-Database $server "$projectName.$db"
    }
}

task Init {
    Remove-Resources

    if (-not (Test-Path $localStorage)) {
        New-Item $localStorage -type directory  -Verbose
    }

    if (-not (Test-Path $zipFile)) {
        Copy-Item $distributivePath $zipFile -Verbose
    }
    
    if (-not (Test-Path $localStorage\$distributiveName)) {
        sz x -y  "-o$localStorage" $zipFile "$distributiveName/Website"
        sz x -y  "-o$localStorage" $zipFile "$distributiveName/Data"
		sz x -y  "-o$localStorage" $zipFile "$distributiveName/Databases"
    }

    if (Test-Path "$buildFolder\Output") {
        Remove-Item -Recurse -Force "$buildFolder\Output"         
    }
    
    New-Item "$buildFolder\Output" -type directory    

    robocopy $localStorage\$distributiveName $outputFolder /E /XC /XN /XO
}

task Create-Databases {
    $server = New-Object ("Microsoft.SqlServer.Management.Smo.Server") $sqlServerName
    $databases = "core", "master", "web"
    foreach ($db in $databases)
    {
        $databaseName = "$projectName.$db"
        $databaseObject = $server.Databases[$databaseName]
        if ($databaseObject) {
            Write-Output "Kill all connections to the database $databaseName and drop it"
            $server.KillDatabase($databaseName)
        }

        Attach-Database $server "$projectName.$db" "$buildFolder\Output\Databases\Sitecore.$db.mdf" "$buildFolder\Output\Databases\Sitecore.$db.ldf"
	    Set-ConnectionString "$websiteFolder\App_Config\ConnectionStrings.config" "$db" "Trusted_Connection=Yes;Data Source=$sqlServerName;Database=$projectName.$db"
    }
}

task Configure {
    Set-ConfigAttribute "$websiteFolder\web.config" "sitecore/sc.variable[@name='dataFolder']" "value" $dataFolder   
}

task Copy-Files {
    Copy-Item $buildFolder\MobileDeviceDetector\bin\Sitecore.SharedSource.MobileDeviceDetector.dll $websiteFolder\bin -Force -Verbose
    Copy-Item $buildFolder\MobileDeviceDetector\bin\Sitecore.SharedSource.MobileDeviceDetector.pdb $websiteFolder\bin -Force -Verbose
    Copy-Item $buildFolder\MobileDeviceDetector\bin\FiftyOne.Foundation.dll $websiteFolder\bin -Force -Verbose
    Copy-Item $buildFolder\MobileDeviceDetector\App_Config\ $websiteFolder -Force -Recurse -Verbose
    Copy-Item $buildFolder\MobileDeviceDetector\App_Data\ $websiteFolder -Force -Recurse -Verbose
    Copy-Item $buildFolder\MobileDeviceDetector\Build\ $websiteFolder -Force -Recurse -Verbose
    Copy-Item $buildFolder\MobileDeviceDetector\Data\ $outputFolder -Force -Recurse -Verbose
    Copy-Item $localStorage\license.xml $dataFolder -Force -Verbose
}

task Run-WebServer -depends Compile, Copy-Files, Configure {
    & $webserver /port:81 /path:$websiteFolder   
}

task Deserialize {
    Get-WebPage "http://localhost:81/Build/Deserialize.aspx"
}

task Create-Package -depends Deserialize {
    Get-WebPage "http://localhost:81/Build/Package.aspx"
}

task Compile { 
  exec { msbuild $buildFolder\Sitecore.SharedSource.MobileDeviceDetector.sln /p:Configuration=Release /t:Build } 
}

task Clean { 
    Remove-Resources
}