$projectPath = "..\DotnetArcana.EntityFramework.Sqlite" # Path to project directory
$appSettingsPath = $projectPath + "\appsettings.json"
$providerName = "Microsoft.EntityFrameworkCore.Sqlite"
$outputDir = "Data"
$contextName = "ChinookDbContext"
$contextFile = "..\$contextName.cs"

# Remove the old context file if it exists
Write-Host $contextFile
if (Test-Path $contextFile) {
    Remove-Item $contextFile
}

#List of tables to scaffold
$tables = @(
    "employees",
    "customers",
    "invoices",
    "invoice_items",
    "artists",
    "albums",
    "media_types",
    "genres",
    "tracks",
    "playlists",
    "playlist_track"
)

if (-Not (Test-Path $appSettingsPath)) {
    Write-Error "appsettings.json file not found."
    exit 1
}

$appSettingsJson = Get-Content -Raw -Path $appSettingsPath | ConvertFrom-Json

$connectionString = $appSettingsJson.ConnectionStrings.ChinookConnection
if (-Not $connectionString) {
    Write-Error "Connection string 'ChinookConnection' not found in appsettings.json."
    exit 1
}

$tablesArgument = ($tables | ForEach-Object { "--table $_" }) -join " "
$command = "dotnet ef dbcontext scaffold `"$connectionString`" $providerName --output-dir $outputDir $tablesArgument --force --project `"$projectPath`" --namespace FunctionBasedPlanning.DataAccess.Data --no-onconfiguring --context $contextName --no-build"

Write-Host "Executing: $command"
Invoke-Expression $command

if ($LASTEXITCODE -eq 0) {
    Write-Host "Scaffolding completed successfully."
} else {
    Write-Error "Scaffolding failed with exit code $LASTEXITCODE."
}

