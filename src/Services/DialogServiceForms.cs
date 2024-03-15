namespace PolyhydraGames.Core.Maui.Services;

public abstract class DialogServiceForms
{
    private Page MainPage => IOC.IOC.Get<IApp>().MainPage ?? new Page();
    public abstract Task ToastAsync(string title, string message, int noteType = 0, int seconds = 2);

    public async Task<bool> InputBoxAsync(string title, string message, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
        return await MainPage.DisplayAlert(title, message, labelOk, labelCancel);
    }

    public async Task InputBoxAsync<T>(string title, IEnumerable<T> choices, Func<T, Task> Func) where T : class
    {
        var items = choices.ToArray();
        var choice =
            await MainPage.DisplayActionSheet(title, "Cancel", null,
                items.Select(i => i.ToString()).ToArray());
        var objectChoice = items.FirstOrDefault(i => i.ToString() == choice);
        if (objectChoice != null)
            await Func(objectChoice);
    }
}