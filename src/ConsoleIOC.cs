namespace PolyhydraGames.Core.Console;

public class ConsoleIOC : IIOCContainer
{
    public void UpdateContext(IServiceProvider provider)
    {
        Context = provider;
    }
    public ConsoleIOC(IServiceProvider context)
    {
        UpdateContext(context);
    }

    private IServiceProvider Context { get; set; }


    public T Get<T>()
    {
        return (T)Context.GetService(typeof(T));
    }

    public T Resolve<T>()
    {
        return Get<T>();
    }

    public T Resolve<T>(Type type)
    {
#pragma warning disable CS8603
#pragma warning disable CS8600
        return (T)Context.GetService(type);
#pragma warning restore CS8600
#pragma warning restore CS8603
    }

    public object Resolve(Type type)
    {
        return Context.GetService(type) ?? throw new InvalidOperationException();
    }

    public void Setup(List<IIOCRegistration> registrations)
    {
        throw new NotImplementedException(
            "I feel this is too brittle and not well maintained. The basic IOC container will be respected.");
    }
}