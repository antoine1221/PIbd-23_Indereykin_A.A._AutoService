param([switch]$SetupOnly, [switch]$Stop)
$ErrorActionPreference = 'Stop'
$bin = Join-Path $env:ProgramFiles 'PostgreSQL\18\bin'
$root = Join-Path $env:LOCALAPPDATA 'AutoService-Lab2'
$data = Join-Path $root 'pg18-data'
$ctl = Join-Path $bin 'pg_ctl.exe'
$port = 55433
$role = 'lab2_owner'
$project = 'ProjectAutoService/ProjectAutoService/ProjectAutoService.csproj'
if (!(Test-Path -LiteralPath $ctl)) { throw "PostgreSQL 18 not found: $bin" }
if ($Stop -and $SetupOnly) { throw 'Choose either -Stop or -SetupOnly.' }
Push-Location $PSScriptRoot
$previousPassword = $env:PGPASSWORD
$previousConnection = $env:AUTOSERVICE_CONNECTION_STRING
try {
    $env:PGPASSWORD = $null
    $initialized = Test-Path -LiteralPath (Join-Path $data 'PG_VERSION')
    if ($Stop) {
        if (!$initialized) { Write-Host 'No lab cluster to stop.'; return }
        & $ctl -D $data status | Out-Null
        if ($LASTEXITCODE -eq 3) { Write-Host 'Lab server already stopped.'; return }
        if ($LASTEXITCODE -ne 0) { throw 'Could not determine lab server status.' }
        & $ctl -D $data -m fast -w stop
        if ($LASTEXITCODE -ne 0) { throw 'Could not stop lab server.' }
        return
    }
    if (!$initialized) {
        if (Test-Path -LiteralPath $data) { throw "Unrecognized data directory; nothing was overwritten: $data" }
        [void][IO.Directory]::CreateDirectory($root)
        Write-Host "FIRST RUN: choose a NEW password for $role, then confirm it. This is NOT the password on port 5432."
        & "$bin\initdb.exe" -D $data -U $role -A scram-sha-256 -W --encoding=UTF8 --locale=C -c "port=$port" -c 'listen_addresses=127.0.0.1'
        if ($LASTEXITCODE -ne 0) { throw 'Cluster initialization failed.' }
    }
    & $ctl -D $data status | Out-Null
    if ($LASTEXITCODE -eq 3) {
        & $ctl -D $data -l (Join-Path $root 'postgres.log') -w start
        if ($LASTEXITCODE -ne 0) { throw "Lab server failed to start; see $root\postgres.log. Other servers were not stopped." }
    } elseif ($LASTEXITCODE -ne 0) { throw 'Could not determine lab server status.' }
    $password = Read-Host "Enter the lab password for $role on port $port (hidden)" -AsSecureString
    $env:PGPASSWORD = [Net.NetworkCredential]::new('', $password).Password
    $env:AUTOSERVICE_CONNECTION_STRING = "Host=127.0.0.1;Port=$port;Database=autoservice_lab2;Username=$role"
    dotnet tool restore
    if ($LASTEXITCODE -ne 0) { throw 'dotnet tool restore failed' }
    dotnet ef database update --project $project
    if ($LASTEXITCODE -ne 0) { throw 'Migration failed; application not started' }
    if (!$SetupOnly) {
        dotnet run --no-build --project $project --no-launch-profile
        if ($LASTEXITCODE -ne 0) { throw 'Application exited with an error' }
    }
} finally {
    $env:PGPASSWORD = $previousPassword
    $env:AUTOSERVICE_CONNECTION_STRING = $previousConnection
    if ($password) { $password.Dispose() }
    Pop-Location
}
