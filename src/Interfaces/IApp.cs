
using PolyhydraGames.Core.Console.Display;

namespace PolyhydraGames.Core.Console.Interfaces;

public interface IApp
{
    Page? MainPage { get; }
    Page? DetailPage { get; }
    Page? NavigationPage { get; }

    INavigation Navigation { get; }
    void SetDetailPage(Page navigationPage);
    Page GetNavigationPage(Page page);
    Task SetMainPage(Page view);
}