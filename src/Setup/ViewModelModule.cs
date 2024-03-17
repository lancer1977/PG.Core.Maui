using System.Diagnostics;

namespace PolyhydraGames.Core.Maui.Setup;

public static class ViewModelModule
{
    public static MauiAppBuilder RegisterViewModelsAndPages(this MauiAppBuilder app, params Assembly[] assembies)
    {
        foreach (var item in assembies)
            app.RegisterViewModels(item)
                .RegisterPages(item);

        return app;
    }

    public static void RegisterViewFactory(this IViewFactoryAsync app, params Assembly[] assembies)
    {
        foreach (var item in assembies) app.ViewFactoryRegistration(item);
    }

    public static IEnumerable<Type> Pages(this Assembly assembly)
    {
        return assembly.CreatableTypes().EndingWith("Page");
    }

    public static IEnumerable<Type> ViewModels(this Assembly assembly)
    {
        return assembly.CreatableTypes().EndingWith("ViewModel");
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder, Assembly assembly)
    {
        var vms = assembly.ViewModels();
        foreach (var item in vms)
        {
            if (item.Name.Contains("DatabaseLoader")) Debug.WriteLine(item.Name);
            mauiAppBuilder.Services.AddTransient(item);
            var interfaces = item.GetInterfaces().Where(x => x.Name.Contains("ViewModel"));
            foreach (var @interface in interfaces)
            {
                mauiAppBuilder.Services.AddTransient(@interface, item);
            }

        }

        return mauiAppBuilder;
    }


    public static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder, Assembly assembly)
    {
        foreach (var item in assembly.Pages()) mauiAppBuilder.Services.AddTransient(item);
        return mauiAppBuilder;
    }

    public static void ViewFactoryRegistration(this IViewFactoryAsync factory, params Assembly[] assembies)
    {
        var pageList = new List<Type>();
        var viewModelList = new List<Type>();
        foreach (var item in assembies)
        {
            pageList.AddRange(item.Pages());
            viewModelList.AddRange(item.ViewModels());
        }

        factory.PairMVVMInterfaces(pageList, viewModelList.ToArray());
    }

    public static void PairMVVM<TVM, TPage>(this IViewFactoryAsync factory) where TVM : IViewModelAsync where TPage : Page
    { 
        factory.Register(typeof(TVM), typeof(TPage));

    }
    private static void PairMVVMInterfaces(this IViewFactoryAsync factory, IEnumerable<Type> pages, IEnumerable<Type> viewModels)
    { 
        foreach (var page in pages)
        {
            if (page.Name.Contains("DatabaseLoader")) Debug.WriteLine(page.Name);
            var prefix = page.GetTypeInfo().Name.Replace("Page", "");
            var viewModel = viewModels.FirstOrDefault(i => i.GetTypeInfo().Name.Replace("ViewModel", "") == prefix);
            if (viewModel == null)
            {
                Debug.WriteLine(page.Name);
                continue;
                throw new Exception($"No viewmodel found for type of {page.Name}");
            }

            var iviewmodel = typeof(IViewModelAsync);
            var implementedInterfaces = viewModel
                .GetInterfaces()
                .Where(p => iviewmodel.IsAssignableFrom(p))
                .Except(typeof(IViewModelAsync));
            foreach (var t in implementedInterfaces)
            {
                Debug.WriteLine($"Registring {t.Name} to {page.Name}");
                factory.Register(t, page);
            }

            factory.Register(viewModel, page);
        }
    }
}