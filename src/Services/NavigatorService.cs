namespace PolyhydraGames.Core.Maui.Services;

public class NavigatorService : IViewNavigator
{
    public async Task ShellNavigate(string url)
    {
        await Shell.Current.GoToAsync(url);
    }

    public async Task ShellNavigate(string url, Dictionary<string, object> parameters)
    {
        await Shell.Current.GoToAsync(url, parameters);
    }
}