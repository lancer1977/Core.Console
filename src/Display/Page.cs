using ReactiveUI;
using SixLabors.ImageSharp.Processing;
using Spectre.Console;
using System.Reactive.Linq;
using Text = PolyhydraGames.Extensions.Text;
namespace PolyhydraGames.Core.Console.Display;

public class Page : ReactiveObject, IConsolePage
{
    public object? BindingContext { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string LastMesage { get; set; }
    public string ImageFile { get; set; }

    public List<ConsoleMenuItem> Menu { get; set; }
    public async Task Process(string? result)
    {
        if (string.IsNullOrEmpty(result)) return;
        var action = Menu.FirstOrDefault(x => x.ShortcutKey == result);
        if (action == null)
        {
            LastMesage = ($"Invalid selection: {result}");
            return;
        }
        await action.Run.Execute();

    }

    public async Task RefreshMore()
    {
        // while (true)
        //{
        AnsiConsole.Clear();
        AnsiConsole.Write(Grid());
        //  }

    }

    private Grid Grid()
    {
        var grid = new Grid();

        // Add columns 
        grid.AddColumn();
        grid.AddColumn();

        // Add header row 
        grid.AddRow(new Spectre.Console.Text(Title), GetMenuPanel());
        grid.AddRow(new Spectre.Console.Text(Details)); //, RenderImage()
        grid.AddRow(LastMesage ?? "");

        return grid;
    }


    private Panel GetMenuPanel()
    {
        var items = Menu.Select(x => x.ToString());
        var panel = new Panel(Text.ToCodedArray(items.Select(x => x.ToString()), Environment.NewLine))
        {
            Header = new PanelHeader("Options"),
            Border = BoxBorder.Double,
            //panel.Border = BoxBorder.Square;
            //panel.Border = BoxBorder.Rounded;
            //panel.Border = BoxBorder.Heavy;
            //panel.Border = BoxBorder.Double;
            //panel.Border = BoxBorder.None;
            Padding = new Padding(2, 2, 2, 2),
            Expand = true
        };
        return panel;
    }
    private CanvasImage RenderImage()
    {
        var dir = Environment.CurrentDirectory;
        var image = new CanvasImage($"{dir}\\Images\\{ImageFile}");
        image.MaxWidth(16);

        // Set a sampler that will be used when scaling the image.
        image.BilinearResampler();

        // Mutate the image using ImageSharp
        image.Mutate(ctx => ctx.Grayscale().Rotate(-45).EntropyCrop());

        return image;
    }
}