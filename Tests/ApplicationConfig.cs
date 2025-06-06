using Microsoft.Extensions.Configuration;
using PolyhydraGames.Extensions;

public class ApplicationConfig : IApplicationConfig
{
    public ApplicationConfig(IConfiguration config)
    {
        ItterationDelay = config[nameof(ItterationDelay)].ToInt();
        WindowSwapDelay = config[nameof(WindowSwapDelay)].ToInt();
        AppName = config[nameof(AppName)];
    }

    public int ItterationDelay { get; set; }
    public int WindowSwapDelay { get; set; }
    public string AppName { get; set; }
}