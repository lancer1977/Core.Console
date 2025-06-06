using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PolyhydraGames.Core.Console.System;

public class AppSwitcher : IHostedService
{
    private readonly IApplicationConfig _config;
    private readonly ILogger<AppSwitcher> _logger; 

    public AppSwitcher(IApplicationConfig config,   ILogger<AppSwitcher> logger)
    {

        _config = config;
        _logger = logger;
 
        _logger.LogInformation($"AppSwitcher Version: ");
        Console.WriteLine("Hello, World!");

    }


    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            WindowFinder.Instance.SwitchWindows("msedge",_config.WindowSwapDelay);
            await Task.Delay(TimeSpan.FromSeconds(_config.ItterationDelay), cancellationToken);
        } 
    }
 
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
     
}