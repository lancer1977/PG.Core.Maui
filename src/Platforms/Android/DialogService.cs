using Android.App;
using Android.Widget; 
using PolyhydraGames.Core.Global.Extensions;
using PolyhydraGames.Core.Maui.Services.Abstract;

//using PolyhydraGames.DialogServiceHelpers;
namespace PolyhydraGames.Core.Maui.Services.Dialogs;

/// <summary>
/// </summary>
public class DialogService : CurrentActivityBasedService, IDialogService
{
    /// <inheritdoc />
    public DialogService(ICurrentActivityLocator locator) : base(locator)
    {
        }

    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="title"></param>
    /// <param name="button"></param>
    /// <returns></returns>
    public Task NotificationAsync(string message, string title = "", string button = "OK")
    {
            var tcs = new TaskCompletionSource<object>();
            Dispatcher.GetForCurrentThread()?.Dispatch(() =>
            {
                new AlertDialog.Builder(CurrentActivity).SetMessage(message)?
                    .SetTitle(title)?.SetPositiveButton(button, delegate { tcs.SetResult(null); })?
                    .Show();
            });
            return tcs.Task;
        }

    /// <summary>
    /// </summary>
    /// <param name="title"></param> 
    /// <param name="default"></param>
    /// <returns></returns>
    public async Task<IDialogResult<int>> GetIntAsync(string title, string message = "", int @default = 0)
    {
            var tcs = new TaskCompletionSource<IDialogResult<int>>();

            Dispatcher.GetForCurrentThread()?.Dispatch(() =>
            {
                var input = new EditText(CurrentActivity) { Text = @default.ToString() };

                new AlertDialog.Builder(CurrentActivity)?
                    .SetTitle(title)?
                    .SetMessage(message)?
                    .SetView(input)?
                    .SetPositiveButton("OK", delegate
                    {
                        var legal = int.TryParse(input.Text, out var num);
                        tcs.SetResult(new DialogResult<int>(legal, num));
                    })?
                    .SetNegativeButton("Cancel", delegate { tcs.SetResult(DialogResults.Cancel<int>()); })?
                    .SetCancelable(false)?
                    .Show();
            });
            return await tcs.Task;
        }


    /// <summary>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <param name="default"></param>
    /// <returns></returns>
    public async Task<IDialogResult<int>> GetIntAsync(string title, int low, int high, int @default = 0)
    {
            var message = $"Between {low} and {high}";
            var tcs = new TaskCompletionSource<IDialogResult<int>>();

            Dispatcher.GetForCurrentThread()?.Dispatch(() =>
            {
                var input = new EditText(CurrentActivity) { Text = @default.ToString() };

                new AlertDialog.Builder(CurrentActivity)
                    .SetMessage(message)?
                    .SetTitle(title)?
                    .SetView(input)?
                    .SetPositiveButton("OK", delegate
                    {
                        var legal = int.TryParse(input.Text, out var num);
                        if (legal)
                        {
                            legal = num.Between(low, high);
                        }

                        tcs.SetResult(new DialogResult<int>(legal, num));
                    })?
                    .SetNegativeButton("Cancel", delegate { tcs.SetResult(DialogResults.Cancel<int>()); })?
                    .SetCancelable(false)?
                    .Show();
            });
            return await tcs.Task;
        }


    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="title"></param>
    /// <param name="labelOk"></param>
    /// <param name="labelCancel"></param>
    /// <returns></returns>
    public async Task<IDialogResult<bool>> GetBooleanAsync(string message, string title, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
            var tcs = new TaskCompletionSource<IDialogResult<bool>>();

            Dispatcher.GetForCurrentThread()?.Dispatch(() =>
            {
                new AlertDialog.Builder(CurrentActivity)?
                    .SetMessage(message)?
                    .SetTitle(title)?
                    .SetPositiveButton(labelOk, delegate { tcs.SetResult(DialogResults.Yes()); })?
                    .SetNegativeButton(labelCancel, delegate { tcs.SetResult(DialogResults.No()); })?
                    .SetCancelable(false)?
                    .Show();
            });

            return await tcs.Task;
        }

    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="title"></param>
    /// <param name="labelOk"></param>
    /// <param name="labelCancel"></param>
    /// <returns></returns>
    public async Task<IDialogResult<string>> GetStringAsync(string message, string title, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
        var tcs = new TaskCompletionSource<IDialogResult<string>>();

        Dispatcher.GetForCurrentThread()?.Dispatch(() =>
        {
            if (CurrentActivity == null) return;
            var input = new EditText(CurrentActivity) { };
#pragma warning disable CS8602
            new AlertDialog.Builder(CurrentActivity)
                .SetMessage(message)
                .SetTitle(title)

                .SetView(input)
                .SetPositiveButton(labelOk, delegate { tcs.SetResult(new DialogResult<string>(true, input.Text)); })

                .SetNegativeButton(labelCancel, delegate { tcs.SetResult(DialogResults.Cancel<string>()); })
                .SetCancelable(false)
                .Show();
#pragma warning restore CS8602
        });
        return await tcs.Task;
    }

    /// <summary>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="choices"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public async Task<IDialogResult<T>> InputBoxAsync<T>(string title, IEnumerable<T> choices)
    {
            var tcs = new TaskCompletionSource<IDialogResult<T>>();
            var items = choices.ToList();
            if (CurrentActivity != null)
            {
                Dispatcher.GetForCurrentThread()?.Dispatch(() =>
                {
                    if (CurrentActivity == null) return;
                    var builder = new AlertDialog.Builder(CurrentActivity);
                    builder.SetTitle(title)?
                        .SetIcon(Android.Resource.Drawable.IcDialogAlert)?
                        .SetItems(items.Select(i => i?.ToString() ?? "NULL").ToArray(),
                            (sender, e) => tcs.SetResult(new DialogResult<T>(true, items[e.Which])))?
                        .SetNegativeButton("Cancel", (sender, e) => { tcs.SetResult(DialogResults.Cancel<T>()); })?
                        .SetCancelable(false)?
                        .Show();
                });
            }
            else
            {
                tcs.SetResult(new DialogResult<T>());
            }

            return await tcs.Task;
        }


    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task ToastAsync(string message)
    {
            Dispatcher.GetForCurrentThread()?.Dispatch(() =>
            {
                Toast.MakeText(CurrentActivity, message, ToastLength.Short)?.Show();
            });
        }
}