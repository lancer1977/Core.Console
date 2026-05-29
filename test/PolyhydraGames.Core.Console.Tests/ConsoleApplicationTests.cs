using NUnit.Framework;
using PolyhydraGames.Core.Console;

namespace PolyhydraGames.Core.Console.Tests;

[TestFixture]
public class ConsoleApplicationTests
{
    private ConsoleApplication _app;

    [SetUp]
    public void SetUp()
    {
        _app = new ConsoleApplication();
    }

    [TearDown]
    public void TearDown()
    {
        _app.Dispose();
    }

    [Test]
    public void RequestShutdown_SetsCancellationToken()
    {
        // Act
        _app.RequestShutdown();

        // Assert
        Assert.That(_app.Token.IsCancellationRequested, Is.True);
    }
}
