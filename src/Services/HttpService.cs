namespace PolyhydraGames.Core.Maui.Services;

public class HttpService : IHttpService
{
    private readonly IPolyhydraToken _token;

    public HttpService(IPolyhydraToken token)
    {
        _token = token;
    }

    public Task<string> GetAuthToken()
    {
        return Task.FromResult(_token.Token);
    }

    public HttpClient GetClient { get; set; } = new();
}