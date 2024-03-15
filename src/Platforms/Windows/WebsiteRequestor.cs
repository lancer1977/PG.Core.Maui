
namespace PolyhydraGames.Core.Maui.Services.WebsiteRequestors;

public class WebsiteRequestor : IWebsiteRequestor
{
    private readonly IBrowser _browser;

    public WebsiteRequestor(IBrowser browser)
    {
        _browser = browser;
    }
    public async Task RequestWebsite(string address)
    {
        var success = await _browser.OpenAsync(address);

        if (!success)
        {
            // Handle the case where the URI could not be launched
            // (e.g., the user does not have a default web browser set)
        }
    }
}