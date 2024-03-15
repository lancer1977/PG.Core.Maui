using Mopups.Pages;
using PolyhydraGames.Core.Maui.Navigation;

namespace PolyhydraGames.Core.Maui.Controls;

public class PopupPageBase : PopupPage, IPopupPage
{
    public IViewModelAsync? ViewModel => BindingContext as IViewModelAsync;

    protected override async Task OnAppearingAnimationBeginAsync()
    {
        await base.OnAppearingAnimationEndAsync();
        await ViewModel?.OnAppearingAsync();

    }

    protected override async Task OnDisappearingAnimationBeginAsync()
    {
        await base.OnDisappearingAnimationEndAsync();
        await ViewModel?.OnDisappearingAsync();

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