using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PolyhydraGames.Core.Console.System;

namespace LurkHelper;
public class AppSwitcher : IHostedService
{
    private readonly IApplicationConfig _config;
    private readonly ILogger<AppSwitcher> _logger;

    public AppSwitcher(IApplicationConfig config, ILogger<AppSwitcher> logger)
    {
        _config = config;
        _logger = logger;

        _logger.LogInformation($"AppSwitcher Version: ");
        _logger.LogInformation($"Process Name Target: {config.AppName}");
        _logger.LogInformation($"Seconds Between Window Switches: {config.WindowSwapDelay}");
        _logger.LogInformation($"Seconds Between Itterations: {config.ItterationDelay}");
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            WindowFinder.Instance.SwitchWindows(_config.AppName, _config.WindowSwapDelay);
            _logger.LogInformation($"Sleeping for {_config.ItterationDelay} seconds.");
            await Task.Delay(TimeSpan.FromSeconds(_config.ItterationDelay), cancellationToken);

        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public void OpenLurks()
    {

    }

}