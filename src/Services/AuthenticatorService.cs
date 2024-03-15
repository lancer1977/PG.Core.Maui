using IWebAuthenticator = PolyhydraGames.Core.Interfaces.IWebAuthenticator;

namespace PolyhydraGames.Core.Maui.Services;

public class AuthenticatorService : IWebAuthenticator
{
    public async Task<IExternalUserRecord> AuthenticateAsync(Uri address, Uri callback)
    {
        var result = await WebAuthenticator.AuthenticateAsync(address, callback);
        return result.ToExternalUserRecord();
    }
}