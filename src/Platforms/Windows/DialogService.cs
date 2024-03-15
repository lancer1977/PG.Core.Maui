using CommunityToolkit.Maui.Core;
using PolyhydraGames.Core.Global.Extensions;
using Toast = CommunityToolkit.Maui.Alerts.Toast;

namespace PolyhydraGames.Core.Maui.Services.Dialogs;

public class DialogService : IDialogService
{
    private Page RootPage => Application.Current?.MainPage ?? new Page();

    public virtual async Task NotificationAsync(string message, string title = "", string button = "OK")
    {
        await RootPage.DisplayAlert(title, message, button);
    }

    public virtual async Task<IDialogResult<int>> GetIntAsync(string title, string message = "", int def = 0)
    {
        return await CTS(async () =>
        {
            var task = await RootPage.DisplayPromptAsync(title, message, "Ok", placeholder: def.ToString());
            if (int.TryParse(task, out var result)) return new DialogResult<int>(true, result);

            return new DialogResult<int>(false, -1);
        });
    }

    public virtual async Task<IDialogResult<int>> GetIntAsync(string title, int low, int high, int @default = 0)
    {
        return await CTS(async () =>
        {
            var task = await RootPage.DisplayPromptAsync(title, $"{low} to {high}", "Ok",
                placeholder: @default.ToString());
            if (int.TryParse(task, out var result) && result >= low && result <= high)
                return new DialogResult<int>(true, result);

            return new DialogResult<int>(false, -1);
        });
    }

    public virtual async Task<IDialogResult<bool>> GetBooleanAsync(string message, string title, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
        return await CTS(async () =>
        {
            var task = await RootPage.DisplayAlert(title, message, labelOk, labelCancel);

            return new DialogResult<bool>(true, task);
        });
    }

    public virtual async Task<IDialogResult<string>> GetStringAsync(string message, string title, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
        return await CTS(async () =>
        {
            var task = await RootPage.DisplayPromptAsync(title, message, labelOk, labelCancel);

            return new DialogResult<string>(true, task);
        });
    }

    public virtual async Task<IDialogResult<T>> InputBoxAsync<T>(string title, IEnumerable<T> items)
    {
        return await CTS(async () =>
        {
            var stringItems = items.Select(x => x?.ToString()).ToArray();
            var task = await RootPage.DisplayActionSheet(title, "Cancel", null, stringItems);
            var selection = stringItems.FirstOrDefault(x => x == task);
            if (selection != null)
            {
                var index = stringItems.IndexOf(selection);
                var itemIdex = items.ToList()[index];
                return DialogResults.Result(itemIdex);
            }
            return DialogResults.Cancel<T>();
        });
    }

    public virtual async Task ToastAsync(string message)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var duration = ToastDuration.Short;
        var fontSize = 14;
        var toast = Toast.Make(message, duration, fontSize);
        await toast.Show(cancellationTokenSource.Token);
    }

    public async Task<DialogResult<T>> CTS<T>(Func<Task<DialogResult<T>>> task)
    {
        var token = new CancellationTokenSource();
        var rawTask = task();
        await rawTask.WaitAsync(token.Token);
        //Task.WaitAll(task);
#pragma warning disable CS8604
        if (token.IsCancellationRequested) return new DialogResult<T>(false, default);
#pragma warning restore CS8604

        return rawTask.Result;
    }
}