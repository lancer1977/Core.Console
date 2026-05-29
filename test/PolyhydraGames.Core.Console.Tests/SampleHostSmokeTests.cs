using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PolyhydraGames.Core.Console.Interfaces;
using PolyhydraGames.Core.Console.Setup;
using SampleHost;

namespace PolyhydraGames.Core.Console.Tests;

[TestFixture]
public class SampleHostSmokeTests
{
    [Test]
    public void Services_RegisterCore_ResolvesAppAndSampleDependencies()
    {
        var services = new ServiceCollection();

        services.RegisterCore();
        services.AddSingleton<IGreetingService, GreetingService>();
        services.AddSingleton<MainPage>();

        using var provider = services.BuildServiceProvider();

        var app = provider.GetRequiredService<IApp>();
        var page = provider.GetRequiredService<MainPage>();

        Assert.That(app, Is.Not.Null);
        Assert.That(page, Is.Not.Null);
        Assert.That(page.Title, Is.EqualTo("Sample Host App"));
        Assert.That(page.Menu, Has.Count.EqualTo(3));
        Assert.That(provider.GetRequiredService<IGreetingService>().GetGreeting("Ada"),
            Is.EqualTo("Hello, Ada! Welcome to Core.Console."));
    }

    [Test]
    public async Task MainPage_ProcessShowFeatures_SetsExpectedMessage()
    {
        var page = new MainPage(new GreetingService());

        await page.Process("2");

        Assert.That(page.LastMesage, Is.EqualTo(
            "Core.Console Features:\n" +
            "• Dependency Injection container\n" +
            "• Page/ViewModel navigation pattern\n" +
            "• Interactive console UI with Spectre.Console\n" +
            "• Graceful shutdown support (Ctrl+C)"));
    }

    [Test]
    public async Task MainPage_ProcessExit_SetsGoodbyeMessage()
    {
        var page = new MainPage(new GreetingService());

        await page.Process("3");

        Assert.That(page.LastMesage, Is.EqualTo("Goodbye! Press Ctrl+C to exit."));
    }
}
