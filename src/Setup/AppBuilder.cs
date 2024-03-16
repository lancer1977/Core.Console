using PolyhydraGames.Core.Console.Interfaces;
using PolyhydraGames.Core.Console.Navigation;
using PolyhydraGames.Core.Console.Services;
using PolyhydraGames.Core.Console.Services.Dialogs;
using PolyhydraGames.Core.Console.Services.FileService;
using PolyhydraGames.Core.Console.Services.ItemPickers;
using System.Diagnostics;

namespace PolyhydraGames.Core.Console.Setup;

public static class AppBuilder
{
    public static IServiceCollection RegisterCore(this IServiceCollection appBuilder)
    {
#pragma warning disable CS8603
        appBuilder.AddSingleton<IApp, ConsoleApplication>();
        appBuilder.AddSingleton<IMenuControl, ConsoleApplication>();
#pragma warning restore CS8603
        appBuilder.AddSingleton<IViewFactoryAsync, ViewFactoryAsync>();
        appBuilder.AddSingleton<ISettings, SettingService>();
        appBuilder.AddSingleton<INavigatorAsync, NavigatorAsync>();
        appBuilder.AddSingleton<IItemPicker, ItemPicker>();

        appBuilder.AddSingleton<IHttpService, HttpService>();
        appBuilder.AddSingleton<IPolyhydraToken, TokenService>();
        appBuilder.AddSingleton<IDialogService, PopupDialogService>();
        appBuilder.AddSingleton<IFilePickerService, FilePickerService>();
        appBuilder.AddSingleton<IMainThreadDispatcher, MainThreadDispatcher>();
        appBuilder.RegisterPlatformServices();
        return appBuilder;
    }

    public static IServiceCollection RegisterTypesAsInterfaces(this IServiceCollection builder, IList<Type> types)
    {
        foreach (var t in types.OrderBy(x => x.Name))
        {
            var interfaces = t.GetInterfaces();
            foreach (var i in interfaces)
                try
                {
                    builder.AddSingleton(i, t);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(
                        $"IOC Error! {t.Name} was not able to be registered as {i.Name} - Error {e.Message}");
                }
        }

        return builder;
    }


    [Obsolete("Use the opposite pattern to remain consistent")]
    public static void AddSingletonDepricated<TImplementation, TInterface>(this IServiceCollection builder)
        where TImplementation : class, TInterface
        where TInterface : class
    {
        builder.AddSingleton<TInterface, TImplementation>();
    }

    //public static void AddSingleton<TInterface, TImplementation>(this IServiceCollection builder)
    //    where TImplementation : class, TInterface
    //    where TInterface : class
    //{
    //    builder.AddSingleton<TInterface, TImplementation>();
    //}
}