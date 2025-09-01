# Monitor de batería <!-- omit in toc -->

- [Preview image](#preview-image)
- [Descargar instalador](#descargar-instalador)
- [Configuration](#configuration)
- [Uso](#uso)
- [Acerca de](#acerca-de)
  - [Actualizaciones automáticas](#actualizaciones-automáticas)

**BatteryMonitor** revisa periódicamente el nivel de carga de la batería de su computador portatil y le alertará cuando conectar o desconectar su cargador para mantener en los límites recomentados (20 %- 80%).

Nuestra novedad, la aplicación detecta el tiempo de inactividad del equipo, si surge una alerta, se producirá una notificación usando el sintetizador de voz de Windows.

## Preview image

![MainForm](http://gg.gg/BattMonFormMain)

## [Descargar instalador](http://gg.gg/BatteryMonitorInst)

![SetUp](http://gg.gg/BattMonSetUp)

![NotifyIconRecom](http://gg.gg/BattMonNotifyIconRecom)

## Configuration

- En la pantalla principal, seleccione **Opciones** -> **Configuración**.
- En la pestaña **Notificaciones** puede configurar:
  - Los niveles de advertencia para la batería.
  - El periodo en que se mide el nivel de batería.
  - El periodo en que se repite la advertencia de no haber sido atendida o desactivada.
  - El tiempo de inactividad del sistema en que se emitirá la notificación por voz.
  - Cambiar el nombre que usará el sintetizador identificar el equipo que emite la advertencia.
  - Habilitar / deshabilitar los tipos de notificaciones.

![FormSettings](http://gg.gg/BattMonFormSettings)

- En la pestaña **Sintetizador de voz** puede configurar:
- La voz que usará el sintetizador.
- El volumen al que cambiará a la hora de emitirse una notificación.

![FormSettings2](https://danielrinconr.github.io/BatteryMonitor/BatteryMonitor/Imgs/ScreenShots/FormSettings2.jpg)

## Uso

## Acerca de

- En esta ventana se encuentra el correo de contacto y la página web de la aplicación.
- Además de la versión actual de la versión.

![FormAbout](http://gg.gg/BattMonFormAbout)

### Actualizaciones automáticas

This is one of the interesting feature, the auto-updater. Every 24h SoundSwitch will check for a new release. If a new one is available the user will get a notification When the user clicks on it, a new window opens with a progress bar (see screenshots). The new version gets automatically downloaded and install the Update by just clicking the install button. A changelog is also provided by getting the information set in the release on GitHub.

![UpdateWindow](http://gg.gg/BattMonUpdateWindow)

![UpdateWindow2](http://gg.gg/BattMonUpdateWindow2)

![RunAfterUpdate](http://gg.gg/BattMonRunAfeterUpdate)

## CI / Secrets

This project can read an `ENCRYPTION_CODE` at runtime when the environment variable is present. GitHub Actions and other CI systems expose repository secrets to workflows but they are write-only — the running process can read the value while the job runs, but the secret will never be returned by the GitHub API.

To set the secret in GitHub repository settings:

- Go to the repo -> Settings -> Secrets and variables -> Actions -> New repository secret.
- Name: ENCRYPTION_CODE
- Value: (your secret)

Example workflow is provided in `.github/workflows/ci-windows.yml` showing how to map the secret into the job environment.

Local testing (PowerShell):

```powershell
# Temporarily set the environment variable for the current process (PowerShell)
$env:ENCRYPTION_CODE = 'your-test-value'

# Run the app or dotnet build/run in this session
dotnet run --project BatteryMonitor/BatteryMonitor.csproj

# Remove when done
Remove-Item Env:\ENCRYPTION_CODE
```

