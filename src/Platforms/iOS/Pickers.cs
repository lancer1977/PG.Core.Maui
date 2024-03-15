using UIKit;

namespace PolyhydraGames.Core.Maui.Services.ItemPickers;

/// <summary>
/// </summary>
public class Pickers : IItemPicker
{
    /// <inheritdoc />
    public void Dispose()
    {
        }
    // Required for iPad - You must specify a source for the Action Sheet since it is
    // displayed as a popover
    public void PrepIpad(UIAlertController uiController)
    {
        var presentationPopover = uiController.PopoverPresentationController;
        if (presentationPopover == null) return; //Was not an Ipad
#pragma warning disable CS8601
        presentationPopover.SourceView = RootControllerHelper.GetCurrentViewController()?.View ?? null;
#pragma warning restore CS8601
        presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Up;

    }
    /// <summary>
    /// </summary>
    /// <param name="items"></param>
    /// <param name="okClicked"></param>
    /// <param name="title"></param>
    /// <param name="cancelButton"></param>
    /// <typeparam name="T"></typeparam>
    public void Picker<T>(IList<T> items, Action<int> okClicked, string title = "",
        string cancelButton = "Cancel")
    {
            // Create a new Alert Controller
            var actionSheetAlert = UIAlertController.Create(title, null, UIAlertControllerStyle.ActionSheet);

            void Act(T i)
            {
                var index = items.IndexOf(i);
                okClicked(index);
            }

            ;
            foreach (var item in items)
            {
                actionSheetAlert.AddAction(item.CreateUIAlertAction(Act));
            }

            // Add Actions
            var cancel = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel,
                (action) => Console.WriteLine("Cancel button pressed."));
            // cancel.Se
            actionSheetAlert.AddAction(cancel);
            cancel.SetValueForKey(UIColor.Red, "titleTextColor".ToNSString());
            // Required for iPad - You must specify a source for the Action Sheet since it is
            // displayed as a popover

            // Display the alert
            RootControllerHelper.GetCurrentViewController().PresentViewController(actionSheetAlert, true, null);
        }

    public void Picker<T>(IList<T> items, Action<T> okClicked, string title = "", string cancelButton = "Cancel")
    {
            // Create a new Alert Controller
            var actionSheetAlert = UIAlertController.Create(title, null, UIAlertControllerStyle.ActionSheet);

            foreach (var item in items)
            {
                actionSheetAlert.AddAction(item.CreateUIAlertAction(okClicked));
            }
            // Add Actions

            actionSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel,
                (action) => Console.WriteLine("Cancel button pressed.")));


            PrepIpad(actionSheetAlert);


            // Display the alert
            RootControllerHelper.GetCurrentViewController().PresentViewController(actionSheetAlert, true, null);
        }

    public Task<T> PickerAsync<T>(IList<T> items, string title = "", string cancelButton = "Cancel")
        where T : class
    {
        var tcs = new TaskCompletionSource<T>();
        var act = new Action<T>(i => { tcs.TrySetResult(i); });
        // Create a new Alert Controller
        var actionSheetAlert = UIAlertController.Create(title, null, UIAlertControllerStyle.ActionSheet);

        foreach (var item in items)
        {
            actionSheetAlert.AddAction(item.CreateUIAlertAction(act));
        }
        // Add Actions

        actionSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel,
#pragma warning disable CS8625
            (action) => tcs.TrySetResult(null)));
#pragma warning restore CS8625

        PrepIpad(actionSheetAlert);

        // Display the alert
        RootControllerHelper.GetCurrentViewController().PresentViewController(actionSheetAlert, true, null);
        return tcs.Task;
    }
}