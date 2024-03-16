using System.ComponentModel;

namespace PolyhydraGames.Core.Console.Controls;

public abstract class PageBase : ContentPage
{
    protected virtual bool IsModal => false;
#pragma warning disable CS8603
    public IViewModelAsync ViewModel => BindingContext as IViewModelAsync;
#pragma warning restore CS8603

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (!IsModal)
            return;
        //var pad = On<iOS>().SafeAreaInsets();

        //this.Padding = pad;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel?.OnAppearing();
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        ViewModel?.OnDisappearing();
    }
}

public class PageBase<T> : PageBase where T : class, IViewModelAsync, INotifyPropertyChanged
{
#pragma warning disable CS8603
    public new T ViewModel => BindingContext as T;
#pragma warning restore CS8603
}