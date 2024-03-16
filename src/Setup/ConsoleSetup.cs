namespace PolyhydraGames.Core.Console.Setup;

public static class ConsoleSetup
{
    public static IServiceCollection RegisterTypes(this IServiceCollection builder, List<(Type, Type)> items)
    {
        foreach (var item in items)
        {
            var (instance, inter) = item;
            builder.AddScoped(instance, inter);
        }

        return builder;
    }

    public static IServiceCollection RegisterIOC(this IServiceCollection builder)
    {
        builder.AddSingleton<IIOCContainer, ConsoleIOC>(x =>
            {
                var ioc = new ConsoleIOC(x);
                IOC.IOC.Initialize(ioc);
                return ioc;
            }
        );
        return builder;
    }


}