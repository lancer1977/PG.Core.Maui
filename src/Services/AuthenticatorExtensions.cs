namespace PolyhydraGames.Core.Maui.Services;

public static class AuthenticatorExtensions
{
    public static IExternalUserRecord ToExternalUserRecord(this WebAuthenticatorResult result)
    {
        return new ExternalUserRecord
        {
            UserId = result.Properties["userid"].ToGuid(), // result.IdToken,
            AuthToken = result.AccessToken,
            Email = result.RefreshToken,
            Provider = result.Properties["provider"]
        };
    }
}