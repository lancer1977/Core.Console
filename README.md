# Core.Console

PolyhydraGames.Core.Console provides a structured way to build console applications with dependency injection, configuration, and logging support.

## Build Notifications

Build notifications are sent to Discord via Azure DevOps pipeline. To configure:

1. Go to **Azure DevOps > Pipelines > Library**
2. Add or edit the **Discord** variable group:
   - `Discord.ChannelId` - The Discord channel ID for notifications
   - `Discord.WebhookKey` - The Discord webhook secret key

**Note:** These values are stored as secure variables and are NOT committed to the repository.

## Quick Start

Check out the [Sample Host Application](./samples/SampleHost/) for a complete working example.

### Minimal Example

```csharp
using Microsoft.Extensions.DependencyInjection;
using PolyhydraGames.Core.Console;
using PolyhydraGames.Core.Console.Display;
using PolyhydraGames.Core.Console.Interfaces;
using PolyhydraGames.Core.Console.Setup;

// 1. Create service collection
var services = new ServiceCollection();

// 2. Register Core.Console services
services.RegisterCore();

// 3. Add your own services
services.AddSingleton<IMyService, MyService>();

// 4. Register your pages
services.AddSingleton<MainPage>();

// 5. Build the service provider
var provider = services.BuildServiceProvider();

// 6. Get the app and page
var app = provider.GetRequiredService<IApp>();
var mainPage = provider.GetRequiredService<MainPage>();

// 7. Run
await app.SetMainPage(mainPage);
```

### Creating a Page

```csharp
public class MainPage : Page
{
    public MainPage(IMyService myService)
    {
        Title = "My App";
        Details = "Description shown in header";
        
        // Menu items automatically handle user input
        Menu = new List<ConsoleMenuItem>
        {
            new("1", "Do Something", DoSomethingAsync),
            new("2", "Exit", ExitAsync),
        };
    }
    
    private async Task DoSomethingAsync()
    {
        // Use AnsiConsole from Spectre.Console for input/output
        var input = AnsiConsole.Ask<string>("Enter something: ");
        LastMesage = $"You entered: {input}";
        await Task.CompletedTask;
    }
    
    private async Task ExitAsync()
    {
        LastMesage = "Goodbye!";
        // Press Ctrl+C to exit, or implement custom exit logic
        await Task.CompletedTask;
    }
}
```

## Samples

- **SampleHost** (`samples/SampleHost/`) - A minimal working console app demonstrating DI setup, page patterns, and menu handling.
