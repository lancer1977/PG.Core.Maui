namespace PolyhydraGames.Core.Maui;

public abstract class ShellApplication : Application, IApp, IMenuControl, INavigationBarController
{
    protected Color _navigationBarColor;
    protected INavigatorAsync? _navigator;


    public NavigationPage NavigationPage
    {
        get
        {
            if (MainPage is Shell page) return page.CurrentPage as NavigationPage;
            return MainPage as NavigationPage;
        }
    }

    public Page DetailPage => MainPage is FlyoutPage page ? page.Detail : MainPage;

    public INavigation Navigation => DetailPage.Navigation;


    public virtual void SetDetailPage(Page page)
    {
        var mainPage = MainPage as FlyoutPage;
        if (mainPage == null) throw new NullReferenceException("MainPage");
        mainPage.Detail = GetNavigationPage(page);
    }

    public virtual Page GetNavigationPage(Page page)
    {
        var result = new NavigationPage(page);
        return result;
    }

    public void SetNavigationBarColor(string hex = "#00263A")
    {
        _navigationBarColor = Color.FromHex(hex);
        var page = NavigationPage;
        if (page == null) return;
        page.BarBackgroundColor = _navigationBarColor;
    }
    public async Task ShowMenu()
    {
        if (DeviceInfo.Platform != DevicePlatform.WinUI && MainPage is FlyoutPage master) master.IsPresented = true;
    }

    public async Task HideMenu()
    {
        if (DeviceInfo.Platform != DevicePlatform.WinUI && MainPage is FlyoutPage master) master.IsPresented = false;
    }
}