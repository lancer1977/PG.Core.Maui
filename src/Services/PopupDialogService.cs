using PolyhydraGames.Core.Maui.Controls.EntryPopup;

namespace PolyhydraGames.Core.Maui.Services;

public class PopupDialogService : IDialogService
{
    private readonly IApp app;

    public PopupDialogService(INavigatorAsync navigator, IApp app)
    {
        Navigator = navigator;
        this.app = app;
    }

    public INavigatorAsync Navigator { get; }

    public async Task<IDialogResult<bool>> GetBooleanAsync(string? message, string title, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
        var tcs = new TaskCompletionSource<DialogResult<bool>>();
        Action<DialogResult<bool>>? callback = z => { tcs.SetResult(z); };
        await Navigator.PushPopupAsync<EntryPopupViewModel>(async x =>
            x.LoadBoolean(message, title, callback, labelOk, labelCancel));
        return await tcs.Task;
    }

    public async Task<IDialogResult<int>> GetIntAsync(string? title, string message = "", int def = 0)
    {
        var tcs = new TaskCompletionSource<DialogResult<int>>();

        void Callback(DialogResult<int> z)
        {
            tcs.SetResult(z);
        }

        await Navigator.PushPopupAsync<EntryPopupViewModel>(async x => x.LoadInt(title, message, Callback));
        return await tcs.Task;
    }

    public async Task<IDialogResult<int>> GetIntAsync(string title, int low, int high, int @default = 0)
    {
        var tcs = new TaskCompletionSource<DialogResult<int>>();
        Action<DialogResult<int>>? callback = z => { tcs.SetResult(z); };
        await Navigator.PushPopupAsync<EntryPopupViewModel>(async x =>
            x.LoadInt($"Between {low} and {high}. ", title, callback));
        return await tcs.Task;
    }

    public async Task<IDialogResult<string>> GetStringAsync(string message, string? title, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
        var tcs = new TaskCompletionSource<DialogResult<string>>();
        Action<DialogResult<string>>? callback = z => { tcs.SetResult(z); };
        await Navigator.PushPopupAsync<EntryPopupViewModel>(async x =>
            x.LoadString(title, message, callback, labelOk, labelCancel));
        return await tcs.Task;
    }

    public async Task<IDialogResult<T>> InputBoxAsync<T>(string title, IEnumerable<T> items)
    {
        var tcs = new TaskCompletionSource<DialogResult<T>>();
        Action<DialogResult<T>> callback = z => { tcs.SetResult(z); };
        await Navigator.PushPopupAsync<EntryPopupViewModel>(async x =>
        {
            x.LoadObj("", title, items.Cast<object>().ToList(), callback);
        });

        return await tcs.Task;
    }

    public async Task NotificationAsync(string message, string title = "", string button = "OK")
    {
        await app.MainPage.DisplayAlert(title, message, button);
    }

    public async Task ToastAsync(string? message)
    {
        await Navigator.PushPopupAsync<EntryPopupViewModel>(async x => x.LoadToast(message));
        await Task.Delay(1500);
        await Navigator.PopPopupAsync();
    }
}