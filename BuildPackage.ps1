# perparation
$projectFile = $PSScriptRoot + "/src/Jiguang.JPush.Extensions/Jiguang.JPush.Extensions.csproj"

# CI phase
# set location to *.sln
Set-Location $PSScriptRoot

# restore
Write-Output "Restoring package..."
dotnet restore
if ($LASTEXITCODE -ne 0) {
    Write-Error "Restore faled."
    exit
}

# build
Write-Output "Building..."
dotnet build --configuration Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "Build faled."
    exit
}
# test
Write-Output "Running test..."
dotnet test
if ($LASTEXITCODE -ne 0) {
    Write-Error "Test faled."
    exit
}

# release phase
# set location to Jiguang.JPush.Extentions.csproj
Set-Location ($PSScriptRoot + "/src/Jiguang.JPush.Extensions/")

# get version information fro Nuget
$jpushVersions = Invoke-RestMethod -Uri https://api.nuget.org/v3-flatcontainer/Jiguang.JPush/index.json
$jpushExtVersions = Invoke-RestMethod -Uri https://api.nuget.org/v3-flatcontainer/Jiguang.JPush.Extensions/index.json

Foreach($version in $jpushVersions.versions | Where-Object { $jpushExtVersions.versions -notcontains $_ })
{
    Write-Output "Jiguang.JPush version $version"

    # remove old nuget package
    Write-Output "  Removing old package..."
    dotnet remove package Jiguang.JPush

    # add new version of nuget package
    Write-Output "  Adding new package..."
    dotnet add package Jiguang.JPush -v $version
    
    # modifiy package metedata
    Write-Output "  Modifying package metedata..."
    [xml] $projectXmlDoc = Get-Content $projectFile
    $projectXmlDoc.Project.PropertyGroup.Version = $version.ToString()
    $projectXmlDoc.Project.PropertyGroup.PackageVersion = $version.ToString()
    $projectXmlDoc.Project.PropertyGroup.PackageReleaseNotes = $version.ToString() + " release"
    $projectXmlDoc.Save($projectFile)

    # pack package
    Write-Output "  Packing package..."
    dotnet pack --configuration Release
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Pack faled for version: $version."
        exit
    }

    Write-Output ""
}

# finish
Write-Host "Package build finished." -ForegroundColor Green