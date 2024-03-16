using PolyhydraGames.Core.Console.Display;
using PolyhydraGames.Core.Console.Interfaces;
using Spectre.Console;

namespace PolyhydraGames.Core.Console;

public class ConsoleApplication : IApp, IMenuControl, INavigationBarController
{

    public IConsolePage CurrentPage { get; set; }
    private CancellationTokenSource _cts;
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
        CurrentPage = view;
        while (true)
        {
            await view.RefreshMore();
            var result = AnsiConsole.Ask<string>("Make a selection: ");
            await CurrentPage.Process(result);
        }

    }


}