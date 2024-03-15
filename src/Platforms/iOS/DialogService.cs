using PolyhydraGames.Core.Global.Extensions;
using UIKit;
// ReSharper disable once CheckNamespace
namespace PolyhydraGames.Core.Maui.Services.Dialogs;

/// <summary>
/// </summary>
public class DialogService : IDialogService
{
    IUIAlertViewDelegate UIDelegate { get; }

    private void InvokeOnMainThread(Action act)
    {
            MainThread.BeginInvokeOnMainThread(act);
        }

    private async Task InvokeOnMainThreadAsync(Func<Task> act)
    {
            await MainThread.InvokeOnMainThreadAsync(act);
        }
    public DialogService()
    {
            UIDelegate = new UIAlertViewDelegate();
        }

    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="title"></param>
    /// <param name="button"></param>
    /// <returns></returns>
    public async Task NotificationAsync(string message, string title = "", string button = "OK")
    {
            var tcs = new TaskCompletionSource<object>();
            InvokeOnMainThread(() =>
          {
              var alert = new UIAlertView(title ?? string.Empty, message, UIDelegate, button);
              alert.Clicked += (sender, args) => tcs.SetResult(null);
              alert.Dismissed += (sender, args) => tcs.SetResult(null);
              alert.Show();
          });
            await tcs.Task;
        }

    /// <summary>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <param name="default"></param>
    /// <returns></returns>
    public Task<IDialogResult<int>> GetIntAsync(string title, int low, int high, int @default = 0)
    {
            var tcs = new TaskCompletionSource<IDialogResult<int>>();

            InvokeOnMainThread(() =>
          {
              var message = $"Between {low} and {high}";
              var input = new UIAlertView(title ?? string.Empty, message, UIDelegate, "Cancel", "OK");
              input.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
              var textField = input.GetTextField(default);
              input.Clicked += (sender, args) =>
              {
                  var num = 0;
                  var legal = input.CancelButtonIndex != args.ButtonIndex && int.TryParse(textField.Text, out num);
                  if (legal)
                  {
                      legal = num.Between(low, high);
                  }

                  tcs.SetResult(new DialogResult<int>(legal, num));
              };
              input.Show();
          });
            return tcs.Task;
        }


    /// <summary>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="default"></param>
    /// <returns></returns>
    public Task<IDialogResult<int>> GetIntAsync(string title, string message = "", int @default = 0)
    {
            var tcs = new TaskCompletionSource<IDialogResult<int>>();

            InvokeOnMainThread(() =>
          {
              var input = new UIAlertView(title ?? string.Empty, message, UIDelegate, "Cancel", "OK");
              input.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
              var textField = input.GetTextField(default);
              textField.Text = @default.ToString();
              input.Clicked += (sender, args) =>
              {
                  var num = 0;
                  var legal = input.CancelButtonIndex != args.ButtonIndex && int.TryParse(textField.Text, out num);
                  tcs.SetResult(new DialogResult<int>(legal, num));
              };
              input.Show();
          });
            return tcs.Task;
        }

    public Task<IDialogResult<bool>> GetBooleanAsync(string message, string title, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
            var tcs = new TaskCompletionSource<IDialogResult<bool>>();
            InvokeOnMainThread(() =>
          {
              var confirm = new UIAlertView(title ?? string.Empty, message, UIDelegate, labelCancel, labelOk);
              confirm.Clicked += (sender, args) =>
                  tcs.SetResult(new DialogResult<bool>(true, confirm.CancelButtonIndex != args.ButtonIndex));
              confirm.Show();
          });
            return tcs.Task;
        }

    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="title"></param>
    /// <param name="labelOk"></param>
    /// <param name="labelCancel"></param>
    /// <returns></returns>
    public Task<IDialogResult<string>> GetStringAsync(string message, string title, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
            var tcs = new TaskCompletionSource<IDialogResult<string>>();
            InvokeOnMainThread(() =>
          {
              var input = new UIAlertView(title ?? string.Empty, message, UIDelegate, labelCancel, labelOk);
              input.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
              var textField = input.GetTextField(default);
              input.Clicked += (sender, args) =>
                  tcs.SetResult(new DialogResult<string>(input.CancelButtonIndex != args.ButtonIndex, textField.Text));
              input.Show();
          });
            return tcs.Task;
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
            var act = new Action<T>(i => { tcs.TrySetResult(new DialogResult<T>(true, i)); });
            // Create a new Alert Controller
            var actionSheetAlert = UIAlertController.Create(title, null, UIAlertControllerStyle.ActionSheet);

            foreach (var item in choices)
            {
                actionSheetAlert.AddAction(item.CreateUIAlertAction(act));
            }
            // Add Actions

            actionSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel,
                (action) => tcs.TrySetResult(DialogResults.Cancel<T>())));

            // Required for iPad - You must specify a source for the Action Sheet since it is
            // displayed as a popover
            var presentationPopover = actionSheetAlert.PopoverPresentationController;
            if (presentationPopover != null)
            {
                var view = RootControllerHelper.GetCurrentViewController().View;
                if (view == null)
                {
                    throw new NotImplementedException(nameof(view));

                }

                presentationPopover.SourceView = view;
                presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Up;
            }

            // Display the alert
            RootControllerHelper.GetCurrentViewController().PresentViewController(actionSheetAlert, true, null);
            return await tcs.Task;
        }


    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task ToastAsync(string message)
    {
            await NotificationAsync(message);
        }
}