using Mopups.Pages;
using Mopups.Services;

namespace PolyhydraGames.Core.Maui.Navigation;

public static class NavigationExtensions
{
    public static async Task PushPopupAsync(this INavigation navigation, IPopupPage page, bool animated)
    {
        var mopPage = page as PopupPage;
        if (mopPage == null)
        {
            throw new Exception($"page was not a popup {page.ToString()}");

        }

        await MopupService.Instance.PushAsync(mopPage, animated);
    }

    public static async Task PopPopupAsync(this INavigation navigation, bool animated)
    {
        await MopupService.Instance.PopAsync(animated);
    }

    public static async Task PopAllPopupAsync(this INavigation navigation, bool animated)
    {
        await MopupService.Instance.PopAllAsync(animated);
    }
}