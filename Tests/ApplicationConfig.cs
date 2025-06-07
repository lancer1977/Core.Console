using Microsoft.Extensions.Configuration;
using PolyhydraGames.Extensions;

namespace LurkHelper;

public class ApplicationConfig : IApplicationConfig
{
    public ApplicationConfig(IConfiguration config)
    {
        ItterationDelay = config[nameof(ItterationDelay)].ToInt();
        WindowSwapDelay = config[nameof(WindowSwapDelay)].ToInt();
        AppName = config[nameof(AppName)];
        Lurks = config[nameof(Lurks)].Split(",").ToList();
    }

    public int ItterationDelay { get; set; }
    public int WindowSwapDelay { get; set; }
    public string AppName { get; set; }
    public List<string> Lurks { get; set; }
}