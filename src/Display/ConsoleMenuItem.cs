using PolyhydraGames.Core.ReactiveUI;
using ReactiveUI;
using System.Reactive;

namespace PolyhydraGames.Core.Console.Display;
public class ConsoleMenuItem
{

    public ConsoleMenuItem(string shortcut, string title, Func<Task> task)
    {
        ShortcutKey = shortcut;
        Title = title;
        Run = ReactiveCommand.CreateFromTask(task).OnException(Title);
    }
    public string ShortcutKey { get; set; }
    public string Title { get; set; }
    public ReactiveCommand<Unit, Unit> Run { get; }
    public override string ToString()
    {
        return $"{ShortcutKey} - {Title}";
    }
}