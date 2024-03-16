namespace PolyhydraGames.Core.Console.Display;

public interface IConsolePage
{
    public string Title { get; set; }
    public string Details { get; set; }
    public string LastMesage { get; set; }
    public List<ConsoleMenuItem> Menu { get; set; }

    Task Process(string? result);
}