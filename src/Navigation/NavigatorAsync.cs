namespace PolyhydraGames.Core.Maui.Navigation;

public class NavigatorAsync : INavigatorAsync
{
    private readonly IStatusBarManager _statusBarManager;
    private readonly IViewFactoryAsync _viewFactory;

    public NavigatorAsync(IViewFactoryAsync viewFactory, IStatusBarManager statusBarManager)
    {
        _viewFactory = viewFactory;
        _statusBarManager = statusBarManager;
    }

    private static IApp App => (IApp)Application.Current;
    private static INavigation Navigation => App.Navigation;

    public async Task PopToRootAsync(bool animated = true)
    {
        await Navigation.PopToRootAsync(animated);
    }

    public async Task<IViewModelAsync> PopAsync(bool animated = true)
    {
        var view = await Navigation.PopAsync(animated);
        return view.BindingContext as IViewModelAsync;
    }

    public async Task<IViewModelAsync> PopModalAsync(bool animated = true)
    {
        var nav = Navigation;
        var view = await nav.PopModalAsync(animated);
        _statusBarManager.Show(true);
        return view.BindingContext as IViewModelAsync;
    }

    public async Task<IViewModelAsync> PopPopupAsync(bool animated = true)
    {
        var nav = Navigation;
        await nav.PopPopupAsync(animated);
        return null;
    }

    public async Task PushAsync(Type viewModel, bool animated = true)
    {
        var view = await _viewFactory.ResolveAsync(viewModel);
        await Navigation.PushAsync(view, animated);
    }

    public async Task PushAsync(Type viewModel, Func<object, Task> setStateFunc, bool animated = true)
    {
        var view = await _viewFactory.ResolveAsync(viewModel, setStateFunc);
        await Navigation.PushAsync(view, animated);
    }

    public async Task PushAsync<TViewModel>(TViewModel viewModel, bool animated = true)
        where TViewModel : class, IViewModelAsync
    {
        var view = await _viewFactory.ResolveAsync(viewModel);
        await Navigation.PushAsync(view, animated);
    }

    public async Task PushAsync<TViewModel>(Func<TViewModel, Task> setStateFunc = null, bool animated = true)
        where TViewModel : class, IViewModelAsync
    {
        var view = await _viewFactory.ResolveAsync(setStateFunc);
        await Navigation.PushAsync(view, animated);
    }


    public async Task PushModalAsync<TViewModel>(Func<TViewModel, Task> setStateFunc = null, bool animated = true)
        where TViewModel : class, IViewModelAsync
    {
        _statusBarManager.Show(false);
        var nav = Navigation;

        var view = await _viewFactory.ResolveAsync(setStateFunc);
        await nav.PushModalAsync(view, animated);
    }

    public async Task PushModalAsync<TViewModel>(TViewModel viewModel, bool animated = true)
        where TViewModel : class, IViewModelAsync
    {
        _statusBarManager.Show(false);
        var nav = Navigation;
        var view = await _viewFactory.ResolveAsync(viewModel);
        await nav.PushModalAsync(view, animated);
    }

    public async Task PushModalAsync<TViewModel, TPage>(TViewModel viewModel, TPage page, bool animated = true)
        where TViewModel : class, IViewModelAsync
    {
        _statusBarManager.Show(false);
        var nav = Navigation;
        var safePage = page as Page;
        if (safePage == null) throw new ArgumentNullException();
        safePage.BindingContext = viewModel;
        await viewModel.StartAsync();
        await nav.PushModalAsync(safePage, animated);
    }

    public async Task PushModalAsync(Type viewModel, Func<object, Task> setStateFunc = null, bool animated = true)
    {
        _statusBarManager.Show(false);
        var nav = Navigation;
        var view = await _viewFactory.ResolveAsync(viewModel, setStateFunc);
        await nav.PushModalAsync(view, animated);
    }


    public async Task PushModalAsync(Type viewModel, bool animated = true)
    {
        _statusBarManager.Show(false);
        var nav = Navigation;
        var view = await _viewFactory.ResolveAsync(viewModel);
        await nav.PushModalAsync(view, animated);
    }

    public async Task PushPopupAsync<TViewModel>(Func<TViewModel, Task> setStateFunc = null, bool animated = true)
        where TViewModel : class, IViewModelAsync
    {
        var nav = Navigation;
        if (!(await _viewFactory.ResolveAsync(setStateFunc) is IPopupPage view))
            throw new Exception($"Popup page not found for {typeof(TViewModel)}");
        await nav.PushPopupAsync(view, animated);
    }

    public async Task PushPopupAsync<TViewModel, TPage>(TViewModel viewModel, TPage page, bool animated = true)
        where TViewModel : class, IViewModelAsync
    {
        var nav = Navigation;
        var safePage = page as IPopupPage;
        if (safePage == null) throw new ArgumentNullException();
        await viewModel.StartAsync();
        safePage.BindingContext = viewModel;

        await nav.PushPopupAsync(safePage, animated);
    }


    public async Task PushPopupAsync(Type viewModel, bool animated = true)
    {
        var nav = Navigation;
        var view = (IPopupPage)await _viewFactory.ResolveAsync(viewModel);
        await nav.PushPopupAsync(view, animated);
    }

    public async Task PushPopupAsync(Type viewModel, Func<object, Task> setStateFunc, bool animated = true)
    {
        var nav = Navigation;
        var view = (IPopupPage)await _viewFactory.ResolveAsync(viewModel, setStateFunc);
        await nav.PushPopupAsync(view, animated);
    }


    public async Task SetRoot<TViewModel>(Func<TViewModel, Task> setStateFunc = null)
        where TViewModel : class, IViewModelAsync
    {
        var view = await _viewFactory.ResolveAsync(setStateFunc);
        Application.Current.MainPage = view;
    }


    public async Task SetRoot(Type type, Func<object, Task> setStateFunc = null)
    {
        var view = await _viewFactory.ResolveAsync(type, setStateFunc);
        Application.Current.MainPage = view;
    }

    public async Task NavigateTo(Type type, Func<object, Task> setStateFunc = null)
    {
        var view = await _viewFactory.ResolveAsync(type, setStateFunc);
        App.SetDetailPage(view);
    }

    public async Task NavigateTo<TViewModel>(Func<TViewModel, Task> setStateFunc = null)
        where TViewModel : class, IViewModelAsync
    {
        var view = await _viewFactory.ResolveAsync(setStateFunc);
        App.SetDetailPage(view);
    }
}