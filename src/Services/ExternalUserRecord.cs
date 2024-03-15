namespace PolyhydraGames.Core.Maui.Services;

public class ExternalUserRecord : IExternalUserRecord
{
    public Guid UserId { get; set; }
#pragma warning disable CS8618
    public string Provider { get; set; }

    public string Email { get; set; }
    public string AuthToken { get; set; }
#pragma warning restore CS8618
}