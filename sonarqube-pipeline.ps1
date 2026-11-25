
$ErrorActionPreference = "Stop"

# ==================================================
# LOGGING
# ==================================================

function Write-Log {
    param(
        [string]$Message,
        [ValidateSet("INFO", "SUCCESS", "WARNING", "ERROR")]
        [string]$Level = "INFO"
    )

    $timestamp = Get-Date -Format "HH:mm:ss"

    $color = switch ($Level) {
        "INFO"    { "Cyan" }
        "SUCCESS" { "Green" }
        "WARNING" { "Yellow" }
        "ERROR"   { "Red" }
    }

    Write-Host "[$timestamp] [$Level] $Message" -ForegroundColor $color
}

# ==================================================
# EXECUTION
# ==================================================

function Invoke-Step {
    param(
        [string]$Name,
        [scriptblock]$Action
    )

    Write-Host ""
    Write-Host "==================================================" -ForegroundColor DarkGray
    Write-Host " $Name" -ForegroundColor Cyan
    Write-Host "==================================================" -ForegroundColor DarkGray

    $stopwatch = [System.Diagnostics.Stopwatch]::StartNew()

    try {
        & $Action

        $exitCode = $LASTEXITCODE

        if ($null -ne $exitCode -and $exitCode -ne 0) {
            throw "Processo finalizado com código de saída: $exitCode"
        }

        $stopwatch.Stop()

        Write-Log "$Name concluído em $($stopwatch.Elapsed.ToString('mm\:ss\.fff'))." "SUCCESS"
    }
    catch {
        $stopwatch.Stop()

        Write-Log "Falha em: $Name" "ERROR"
        Write-Log $_.Exception.Message "ERROR"

        throw
    }
}

# ==================================================
# MAIN
# ==================================================

$totalTime = [System.Diagnostics.Stopwatch]::StartNew()

try {

    Write-Log "Iniciando pipeline de análise SonarQube..."

    # 1. Obtém as configurações

    $sonarqube_token = $env:SONAR_TOKEN

    # 2. Valida as pré-condições

    if ([string]::IsNullOrWhiteSpace($sonarqube_token)) {
        throw "A variável de ambiente SONAR_TOKEN não foi definida."
    }

    Write-Log "Token SONAR_TOKEN encontrado." "SUCCESS"

    # 3. Inicializa a análise

    Invoke-Step "1/4 - Inicializando análise SonarQube" {

        dotnet sonarscanner begin `
            /o:"device-check" `
            /k:"device-check_computer-service" `
            /d:sonar.token="$sonarqube_token" `
            /d:sonar.cs.opencover.reportsPaths="./tests/TestResults/**/coverage.opencover.xml" `
            /d:sonar.cs.vstest.reportsPaths="./tests/TestResults/**/*.trx"
    }

    # 4. Compila a solução

    Invoke-Step "2/4 - Compilando solução" {

        dotnet build --no-incremental
    }

    # 5. Executa os testes e coleta cobertura

    Invoke-Step "3/4 - Executando testes e coletando cobertura" {

        dotnet test `
            --no-build `
            --collect:"XPlat Code Coverage" `
            --settings "tests/coverage.runsettings" `
            --logger "trx;LogFileName=tests.trx"
    }

    # 6. Finaliza a análise

    Invoke-Step "4/4 - Finalizando análise SonarQube" {

        dotnet sonarscanner end `
            /d:sonar.token="$sonarqube_token"
    }

    $totalTime.Stop()

    Write-Host ""
    Write-Host "==================================================" -ForegroundColor Green
    Write-Log "PIPELINE CONCLUÍDA COM SUCESSO!" "SUCCESS"
    Write-Log "Tempo total: $($totalTime.Elapsed.ToString('mm\:ss\.fff'))" "SUCCESS"
    Write-Host "==================================================" -ForegroundColor Green

}
catch {

    $totalTime.Stop()

    Write-Host ""
    Write-Host "==================================================" -ForegroundColor Red
    Write-Log "PIPELINE INTERROMPIDA." "ERROR"
    Write-Log "Tempo até a falha: $($totalTime.Elapsed.ToString('mm\:ss\.fff'))" "WARNING"
    Write-Host "==================================================" -ForegroundColor Red

    exit 1
}
