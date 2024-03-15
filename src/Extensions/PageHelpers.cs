namespace PolyhydraGames.Core.Maui.Controls;

public static class PageHelpers
{
    public static T GetViewModel<T>(this ContentPage page) where T : class
    {
        var vm = page.BindingContext as T;
        if (vm == null) throw new NullReferenceException("GetViewModel");
        return vm;
    }
}