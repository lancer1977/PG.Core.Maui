 

namespace PolyhydraGames.Core.Maui.Controls;

public abstract class PageBase : ContentPage
{
    protected virtual bool IsModal => false;
    public IViewModelAsync ViewModel => (IViewModelAsync)BindingContext;
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (!IsModal) return;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.OnAppearingAsync();
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await ViewModel.OnDisappearingAsync();
    }
}

public class PageBase<T> : PageBase where T : class, IViewModelAsync, INotifyPropertyChanged
{
    public new T ViewModel => BindingContext as T;

}