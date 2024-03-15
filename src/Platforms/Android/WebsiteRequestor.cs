using Android.Content;
using PolyhydraGames.Core.Maui.Services.Abstract;
using Uri = Android.Net.Uri;

namespace PolyhydraGames.Core.Maui.Services.WebsiteRequestors;

/// <summary>
///     Requests that the OS open a new website window
/// </summary>
public class WebsiteRequestor : ActivityServiceBase, IWebsiteRequestor
{
    /// <summary>
    /// </summary>
    /// <param name="locator"></param>
    public WebsiteRequestor(ICurrentActivityLocator locator) : base(locator)
    {
        }

    /// <summary>
    ///     Requests the website.
    /// </summary>
    /// <param name="address">The wesbite address.</param>
    public async Task RequestWebsite(string address)
    {
            var intent = new Intent(Intent.ActionView, Uri.Parse(address));
            Activity.StartActivity(intent);
        }
}