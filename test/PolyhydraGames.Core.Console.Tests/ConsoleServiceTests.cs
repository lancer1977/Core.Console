using PolyhydraGames.Core.Console.Display;
using PolyhydraGames.Core.Console.Navigation;
using PolyhydraGames.Core.Console.Services;

namespace PolyhydraGames.Core.Console.Tests;

[TestFixture]
public sealed class ConsoleServiceTests
{
    [Test]
    public void DescriptorAndHistoryService_StoreHistoryEntries()
    {
        var descriptor = new Descriptor { Title = "Title", Description = "Description" };
        var history = new HistoryService();

        history.Add("First", "Payload");

        Assert.Multiple(() =>
        {
            Assert.That(descriptor.Title, Is.EqualTo("Title"));
            Assert.That(descriptor.Description, Is.EqualTo("Description"));
            Assert.That(history.Items, Has.Count.EqualTo(1));
            Assert.That(history.Items[0].Title, Is.EqualTo("First"));
            Assert.That(history.Items[0].Description, Is.EqualTo("Payload"));
        });
    }

    [Test]
    public void ExternalUserRecordAndTokenService_ExposeMutableProperties()
    {
        var id = Guid.NewGuid();
        var record = new ExternalUserRecord
        {
            UserId = id,
            Provider = "twitch",
            Email = "user@example.test",
            AuthToken = "token"
        };
        var token = new TokenService { Token = "new-token" };

        Assert.Multiple(() =>
        {
            Assert.That(record.UserId, Is.EqualTo(id));
            Assert.That(record.Provider, Is.EqualTo("twitch"));
            Assert.That(record.Email, Is.EqualTo("user@example.test"));
            Assert.That(record.AuthToken, Is.EqualTo("token"));
            Assert.That(token.Token, Is.EqualTo("new-token"));
        });
    }

    [Test]
    public async Task NavigationExtensions_NoOpPopupMethodsCompleteSuccessfully()
    {
        var navigation = new StubNavigation();
        var page = new StubPopupPage();

        await navigation.PushPopupAsync(page, animated: true);
        await navigation.PopPopupAsync(animated: false);
        await navigation.PopAllPopupAsync(animated: true);

        Assert.Pass();
    }

    [Test]
    public async Task ConsoleApplication_NoOpNavigationMembersCompleteAndReturnPages()
    {
        using var app = new ConsoleApplication();
        var page = new Page();

        await app.ShowMenu();
        await app.HideMenu();
        app.SetNavigationBarColor("#ffffff");
        app.SetDetailPage(page);
        var navigationPage = app.GetNavigationPage(page);

        Assert.That(navigationPage, Is.SameAs(page));
    }

    private sealed class StubNavigation : Interfaces.INavigation
    {
        public IReadOnlyList<Page> ModalStack { get; } = Array.Empty<Page>();
        public IReadOnlyList<Page> NavigationStack { get; } = Array.Empty<Page>();
        public void InsertPageBefore(Page page, Page before) { }
        public Task<Page> PopAsync() => Task.FromResult(new Page());
        public Task<Page> PopAsync(bool animated) => Task.FromResult(new Page());
        public Task<Page> PopModalAsync() => Task.FromResult(new Page());
        public Task<Page> PopModalAsync(bool animated) => Task.FromResult(new Page());
        public Task PopToRootAsync() => Task.CompletedTask;
        public Task PopToRootAsync(bool animated) => Task.CompletedTask;
        public Task PushAsync(Page page) => Task.CompletedTask;
        public Task PushAsync(Page page, bool animated) => Task.CompletedTask;
        public Task PushModalAsync(Page page) => Task.CompletedTask;
        public Task PushModalAsync(Page page, bool animated) => Task.CompletedTask;
        public void RemovePage(Page page) { }
    }

    private sealed class StubPopupPage : Interfaces.IPopupPage
    {
        public object BindingContext { get; set; } = new();
    }
}
