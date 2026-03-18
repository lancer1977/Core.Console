using PolyhydraGames.Core.Console.Display;
using PolyhydraGames.Core.Console.Interfaces;
using Spectre.Console;
using System.Threading.Tasks;
using SysConsole = System.Console;

namespace PolyhydraGames.Core.Console;

public class ConsoleApplication : IApp, IMenuControl, INavigationBarController, IDisposable
{
    public IConsolePage CurrentPage { get; set; }
    private CancellationTokenSource? _cts;
    private bool _disposed;

    public CancellationToken Token => _cts?.Token ?? CancellationToken.None;

    public void SetNavigationBarColor(string hex = "#00263A")
    {
    }
    public async Task ShowMenu()
    {
    }

    public async Task HideMenu()
    {
    }

    public Page MainPage { get; set; }
    public Page DetailPage { get; set; }
    public Page NavigationPage { get; set; }
    public INavigation Navigation { get; set; }
    public void SetDetailPage(Page navigationPage)
    {
    }

    public Page GetNavigationPage(Page page)
    {
        return page;
    }

    public async Task SetMainPage(Page view)
    {
        _cts = new CancellationTokenSource();
        
        // Register Ctrl+C handler for graceful shutdown
        SysConsole.CancelKeyPress += OnCancelKeyPress;
        
        try
        {
            CurrentPage = view;
            while (!_cts.Token.IsCancellationRequested)
            {
                await view.RefreshMore();
                var result = AnsiConsole.Ask<string>("Make a selection: ");
                await CurrentPage.Process(result);
            }
        }
        finally
        {
            SysConsole.CancelKeyPress -= OnCancelKeyPress;
            await DisposeAsync();
        }
    }

    private void OnCancelKeyPress(object? sender, ConsoleCancelEventArgs e)
    {
        // Allow graceful shutdown instead of terminating immediately
        e.Cancel = true;
        AnsiConsole.MarkupLine("[yellow]Received Ctrl+C, shutting down gracefully...[/]");
        _cts?.Cancel();
    }

    public void RequestShutdown()
    {
        AnsiConsole.MarkupLine("[yellow]Shutdown requested, exiting gracefully...[/]");
        _cts?.Cancel();
    }

    public async Task DisposeAsync()
    {
        if (_disposed) return;
        _disposed = true;
        
        _cts?.Cancel();
        _cts?.Dispose();
        _cts = null;
        
        await Task.CompletedTask;
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        _cts?.Cancel();
        _cts?.Dispose();
    }
}
