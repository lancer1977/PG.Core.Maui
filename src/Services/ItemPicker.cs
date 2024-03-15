namespace PolyhydraGames.Core.Maui.Services;

public class ItemPicker : IItemPicker
{
    public ItemPicker(IApp app)
    {
        _app = app;
    }

    private readonly IApp _app;

    public void Dispose()
    {
    }

    public async Task<T?> PickerAsync<T>(IList<T> items, string title = "", string cancelButton = "Cancel")
        where T : class
    {
        var page = _app.MainPage;
        if (page == null) throw new NullReferenceException("App Mainpage was null");
        var names = items.Select(i => i.ToString()).ToArray();
        var result = await page.DisplayActionSheet(title, cancelButton, null, names);
        T? item = null;
        if (!string.IsNullOrEmpty(result))
        {
            var index = Array.IndexOf(names, result);
            item = items[index];
        }

        return item;
    }

    public async void Picker<T>(IList<T> items, Func<int, Task> okClicked, string title = "",
        string cancelButton = "Cancel")
    {
        var page = _app.MainPage;
        if (page == null) throw new NullReferenceException("App Mainpage was null");
        var names = items.Select(i => i?.ToString()).ToArray();
        var result = await page.DisplayActionSheet(title, cancelButton, null, names);
        if (!string.IsNullOrEmpty(result))
        {
            var index = Array.IndexOf(names, result);
            await okClicked.Invoke(index);
        }
    }

    public async void Picker<T>(IList<T> items, Func<T, Task> okClicked, string? title = null,
        string cancelButton = "Cancel")
    {
        var page = _app.MainPage;
        if (page == null) throw new NullReferenceException("App Mainpage was null");
        var names = items.Select(i => i?.ToString()).ToArray();
        var result = await page.DisplayActionSheet(title, cancelButton, null, names);
        if (!string.IsNullOrEmpty(result))
        {
            var index = Array.IndexOf(names, result);
            var item = items[index];
            await okClicked.Invoke(item);
        }
    }
}