using System.Diagnostics;

namespace PolyhydraGames.Core.Maui.Navigation;

public class ViewFactoryAsync : IViewFactoryAsync
{
    private readonly IIOCContainer _componentContext;
    private readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();

    public ViewFactoryAsync(IIOCContainer componentContext)
    {
        _componentContext = componentContext;
    }

    public void Register<TViewModel, TView>() where TViewModel : class, IViewModelAsync where TView : Page
    {
        Register(typeof(TViewModel), typeof(TView));
    }

    public bool IsRegistered<T>()
    {
        return _map.ContainsKey(typeof(T));
    }

    public void Register(Type viewModel, Type page)
    {
        if (!viewModel.IsAssignableTo(typeof(IViewModelAsync)))
            throw new Exception($"Type {viewModel.Name} was not assignable to IViewModelAsync");
        if (!page.IsAssignableTo(typeof(Page)))
            throw new Exception($"Type {page.Name} was not assignable to page");
        _map[viewModel] = page;
    }


    public async Task<Page> ResolveAsync<TViewModel>(Func<TViewModel, Task>? setStateFunc = null)
        where TViewModel : class, IViewModelAsync
    {
        try
        {
            var viewModel = _componentContext.Resolve<TViewModel>();
            if (setStateFunc != null)
                await viewModel.SetStateAsync(setStateFunc);
            var viewType = GetMapType(typeof(TViewModel));
            var view = GetPage(viewType);
            await InitializeAsync(viewModel);
            await InitializeAsync(view);
            view.BindingContext = viewModel;
            return view;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{typeof(TViewModel).Name}: {ex.Message}");
            throw;
        }



    }


    public async Task<Page> ResolveAsync(IViewModelAsync viewModel)
    {
        var viewType = GetMapType(viewModel.GetType());
        var view = _componentContext.Resolve(viewType) as Page;
        if (view == null)
            throw new NullReferenceException($"View factory unable to resolve view for type of {viewModel.GetType()}");
        await InitializeAsync(viewModel);
        await InitializeAsync(view);
        view.BindingContext = viewModel;

        return view;
    }

    public Task<Page> ResolveAsync(Type viewModel)
    {
        return ResolveAsync(viewModel, null);
    }

    public async Task<Page> ResolveAsync(Type viewModelType, Func<object, Task>? setStateFunc = null)
    {
        var viewModel = _componentContext.Resolve(viewModelType);
        var viewType = GetMapType(viewModelType);
        if (setStateFunc != null)
            await setStateFunc.Invoke(viewModel);
        var view = GetPage(viewType);
        await InitializeAsync(viewModel);
        await InitializeAsync(view);
        view.BindingContext = viewModel;
        return view;
    }

    private Page GetPage(Type viewtype)
    {
        if (_componentContext.Resolve(viewtype) is not Page view)
            throw new NullReferenceException($"View factory unable to resolve view for type of {viewtype}");
        return view;
    }

    private Type GetMapType(Type type)
    {
        try
        {
            return _map[type];
        }
        catch (Exception ex)
        {
            throw new Exception($"{type.FullName} was not in the map. {ex.Message}");
        }
    }

    private async Task InitializeAsync(object? obj)
    {
        if (obj is IViewModelAsync viewModel)
            await viewModel.StartAsync();
        if (obj is IInitializeAsync initializer)
            await initializer.InitializeAsync();
    }
    private async Task InitializeAsync(IViewModelAsync viewModel)
    {
        await viewModel.StartAsync();
    }
    //public async Task<Page> ResolveAsync(Type viewModelType, Func<object> setStateFunc = null)

    //{

    //  var viewModel = _componentContext.Resolve(viewModelType);
    //  if (_map.ContainsKey(viewModelType) == false)
    //    throw new NullReferenceException($"View factory has no key for type of {viewModelType}");
    //  var viewType = GetMapType(viewModelType);
    //  if (setStateFunc != null)
    //    setStateFunc.Invoke(viewModel);
    //  var view = _componentContext.Resolve(viewType) as Page;
    //  if (view == null)
    //    throw new NullReferenceException($"View factory unable to resolve view for type of {viewModelType}");
    //  view.BindingContext = viewModel;
    //  var model = viewModel as IViewModelAsync;
    //  model?.StartAsync();
    //  return view;
    //}
}