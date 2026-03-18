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

```csharp
var app = ConsoleApplication.CreateBuilder()
    .ConfigureServices(services =>
    {
        // Add your services
    })
    .Build();

await app.RunAsync<Startup>();
```
