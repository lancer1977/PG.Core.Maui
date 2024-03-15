using System.Diagnostics;

namespace PolyhydraGames.Core.Maui.Views;

public abstract class RootPageBase : FlyoutPage, IInitializeAsync
{
    private readonly IViewFactoryAsync _viewFactory;
    private readonly IApp _app;

    public RootPageBase(IViewFactoryAsync viewFactory, IApp app)
    {
        _viewFactory = viewFactory;
        _app = app;
    }

    protected abstract Type MenuType { get; }
    protected abstract Type MainType { get; }



    public async Task SetStateAsync<T>(Func<T, Task> action) where T : class, IViewModelAsync
    {
    }


    public async Task OnAppearingAsync()
    {
        base.OnAppearing();

    }

    public async Task OnDisappearingAsync()
    {
        base.OnDisappearing();
    }

    public async Task RefreshAsync()
    {
    }

    public async Task InitializeAsync()
    {
        try
        {

            var menuPage = await _viewFactory.ResolveAsync(MenuType);
            if (menuPage == null) throw new Exception("Couldn't find MenuPage");
            var page = await _viewFactory.ResolveAsync(MainType);
            if (page == null) throw new Exception("Couldn't find MainPage");
            Flyout = menuPage;
#pragma warning disable CS8602
            Detail = _app.GetNavigationPage(page);
#pragma warning restore CS8602 
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }
    }
}