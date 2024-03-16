namespace PolyhydraGames.Core.Console.Interfaces;

public interface IViewNavigator
{
    Task ShellNavigate(string url);
    Task ShellNavigate(string url, Dictionary<string, object> parameters);
}