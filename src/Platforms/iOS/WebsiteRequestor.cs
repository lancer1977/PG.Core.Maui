using Foundation;
using UIKit;

namespace PolyhydraGames.Core.Maui.Services.WebsiteRequestors;

public class WebsiteRequestor : IWebsiteRequestor
{
    private readonly IDialogService _dialogService;

    public WebsiteRequestor(IDialogService dialog)
    {
            _dialogService = dialog;
        }

    /// <summary>
    ///     Requests the website.
    /// </summary>
    /// <param name="address">The wesbite address.</param>
    public async Task RequestWebsite(string address)
    {
            var url = new NSUrl(address.Replace(" ", "%20"));
            if (UIApplication.SharedApplication.CanOpenUrl(url))
            {
                UIApplication.SharedApplication.OpenUrl(url);
            }
            else
            {
                await _dialogService.NotificationAsync("Error", "Unable to open a website on this device.");
            }
        }
}