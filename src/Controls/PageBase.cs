/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-ios)'
Before:
using PolyhydraGames.Core.Interfaces;
After:
using System.ComponentModel;
*/

/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-windows10.0.22621.0)'
Before:
using PolyhydraGames.Core.Interfaces;
After:
using System.ComponentModel;
*/

using System.ComponentModel;

namespace PolyhydraGames.Core.Maui.Controls;

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

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await ViewModel?.OnAppearingAsync();
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await ViewModel?.OnDisappearingAsync();
    }
}

public class PageBase<T> : PageBase where T : class, IViewModelAsync, INotifyPropertyChanged
{
#pragma warning disable CS8603
    public new T ViewModel => BindingContext as T;
#pragma warning restore CS8603
}