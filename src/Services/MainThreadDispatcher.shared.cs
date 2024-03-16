using PolyhydraGames.Core.Console.Interfaces;
using Xamarin.Essentials;

namespace PolyhydraGames.Core.Console.Services;



public class MainThreadDispatcher : IMainThreadDispatcher
{
    private readonly IApp _app;

    public MainThreadDispatcher(IApp app)
    {
        _app = app;
    }

    public void InvokeOnMainThread(Action action)
    {
        MainThread.BeginInvokeOnMainThread(action);
    }
}