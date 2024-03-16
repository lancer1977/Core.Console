using PolyhydraGames.Core.Console.Interfaces;

namespace PolyhydraGames.Core.Console.Controls;

public class PopupPageBase : PopupPage, IPopupPage
{
    public IViewModelAsync? ViewModel => BindingContext as IViewModelAsync;

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel?.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ViewModel?.OnDisappearing();
    }

    protected override bool OnBackgroundClicked()
    {
        return Task.Run(async () =>
        {
            await Navigation.PopPopupAsync(false);
            return false;
        }).Result;
    }

    private async void CloseAllPopup()
    {
        await Navigation.PopAllPopupAsync(false);
    }
}