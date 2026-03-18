using Microsoft.Extensions.DependencyInjection;
using PolyhydraGames.Core.Console;
using PolyhydraGames.Core.Console.Display;
using PolyhydraGames.Core.Console.Interfaces;
using PolyhydraGames.Core.Console.Setup;
using Spectre.Console;

namespace SampleHost;

/// <summary>
/// A minimal sample host application demonstrating Core.Console usage patterns.
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        
        // Step 1: Register Core.Console services
        services.RegisterCore();
        
        // Step 2: Add your own services (example: a simple greeting service)
        services.AddSingleton<IGreetingService, GreetingService>();
        
        // Step 3: Register pages
        services.AddSingleton<MainPage>();
        
        // Step 4: Build the service provider
        var provider = services.BuildServiceProvider();
        
        // Step 5: Create the console application
        var app = provider.GetRequiredService<IApp>();
        
        // Step 6: Get the main page and run
        var mainPage = provider.GetRequiredService<MainPage>();
        
        // Step 7: Run with your main page
        await app.SetMainPage(mainPage);
    }
}

/// <summary>
/// Example service for demonstrating DI.
/// </summary>
public interface IGreetingService
{
    string GetGreeting(string name);
}

public class GreetingService : IGreetingService
{
    public string GetGreeting(string name) => $"Hello, {name}! Welcome to Core.Console.";
}

/// <summary>
/// Example Page demonstrating the Page pattern with menu items.
/// The Page class automatically handles rendering the menu via RefreshMore().
/// </summary>
public class MainPage : Page
{
    private readonly IGreetingService _greetingService;
    private bool _shouldExit = false;
    
    public MainPage(IGreetingService greetingService)
    {
        _greetingService = greetingService;
        Title = "Sample Host App";
        Details = "A minimal Core.Console application - Use menu options below";
        
        // Setup menu items - the Page base class handles rendering
        Menu = new List<ConsoleMenuItem>
        {
            new("1", "Get Greeting", GreetAsync),
            new("2", "Show Features", ShowFeaturesAsync),
            new("3", "Exit (Ctrl+C)", ExitAsync),
        };
    }
    
    private async Task GreetAsync()
    {
        // Using Spectre.Console for input (available in Core.Console)
        var name = AnsiConsole.Ask<string>("Enter your name: ");
        LastMesage = _greetingService.GetGreeting(name);
        await Task.CompletedTask;
    }
    
    private async Task ShowFeaturesAsync()
    {
        LastMesage = "Core.Console Features:\n" +
                       "• Dependency Injection container\n" +
                       "• Page/ViewModel navigation pattern\n" +
                       "• Interactive console UI with Spectre.Console\n" +
                       "• Graceful shutdown support (Ctrl+C)";
        await Task.CompletedTask;
    }
    
    private async Task ExitAsync()
    {
        LastMesage = "Goodbye! Press Ctrl+C to exit.";
        _shouldExit = true;
        await Task.CompletedTask;
    }
}
