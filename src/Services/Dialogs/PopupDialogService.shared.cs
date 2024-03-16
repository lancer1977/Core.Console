using PolyhydraGames.Core.Console.Interfaces;


namespace PolyhydraGames.Core.Console.Services.Dialogs;

public class PopupDialogService : IDialogService
{
    private readonly IApp app;

    public PopupDialogService(INavigatorAsync navigator, IApp app)
    {
        Navigator = navigator;
        this.app = app;
    }

    public INavigatorAsync Navigator { get; }

    public async Task NotificationAsync(string message, string title = "", string button = "OK")
    {
        throw new NotImplementedException();
    }

    public async Task<IDialogResult<int>> GetIntAsync(string title, string message = "", int def = 0)
    {
        throw new NotImplementedException();
    }

    public async Task<IDialogResult<int>> GetIntAsync(string title, int low, int high, int @default = 0)
    {
        throw new NotImplementedException();
    }

    public async Task<IDialogResult<bool>> GetBooleanAsync(string message, string title, string labelOk = "OK", string labelCancel = "Cancel")
    {
        throw new NotImplementedException();
    }

    public async Task<IDialogResult<string>> GetStringAsync(string message, string title, string labelOk = "OK", string labelCancel = "Cancel")
    {
        throw new NotImplementedException();
    }

    public async Task<IDialogResult<T>> InputBoxAsync<T>(string title, IEnumerable<T> items)
    {
        throw new NotImplementedException();
    }

    public async Task ToastAsync(string message)
    {
        throw new NotImplementedException();
    }
}