using PolyhydraGames.Core.Console.Services;
using PolyhydraGames.Core.Console.Services.AppLauncher;
using PolyhydraGames.Core.Console.Services.AvailiableAppsServices;
using PolyhydraGames.Core.Console.Services.Email;
using PolyhydraGames.Core.Console.Services.Folders;
using PolyhydraGames.Core.Console.Services.StatusBar;
using PolyhydraGames.Core.Console.Services.WebsiteRequestors;

namespace PolyhydraGames.Core.Console.Setup;

public static class DeviceModule
{


    public static IServiceCollection RegisterPlatformServices(this IServiceCollection builder)
    {
        builder.AddSingleton<IEmailService, EmailService>();
        builder.AddSingleton<IWebsiteRequestor, WebsiteRequestor>();
        builder.AddSingleton<IStatusBarManager, StatusBarManager>();
        builder.AddSingleton<IStorageFolder, FolderService>();
        builder.AddSingleton<IAppLauncher, AppLauncherService>();
        builder.AddSingleton<IAvailiableAppsService, AvailiableAppsService>();
        builder.AddSingleton<IVerbosePickerAsync, VerbosePickerFake>();

        //builder.Register((ctx) => Plugin.Settings.CrossSettings.Current).As<ISettings>();
        return builder;
    }
}