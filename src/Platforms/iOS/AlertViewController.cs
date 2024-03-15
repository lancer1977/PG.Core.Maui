using UIKit;

namespace PolyhydraGames.Core.Maui.Services.Dialogs;

/// <summary>
/// </summary>
public class AlertViewController
{
    /// <summary>
    ///     resents a UI Alert Controller
    /// </summary>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="controller"></param>
    /// <returns></returns>
    public static UIAlertController PresentOKAlert(string title, string description, UIViewController controller)
    {
            // No, inform the user that they must create a home first
            var alert = UIAlertController.Create(title, description, UIAlertControllerStyle.Alert);

            // Configure the alert
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (action) => { }));

            // Display the alert
            controller.PresentViewController(alert, true, null);

            // Return created controller
            return alert;
        }

    /// <summary>
    ///     Ok Cancel Alert
    /// </summary>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="controller"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static UIAlertController PresentOKCancelAlert(string title, string description,
        UIViewController controller, AlertOKCancelDelegate action)
    {
            // No, inform the user that they must create a home first
            var alert = UIAlertController.Create(title, description, UIAlertControllerStyle.Alert);

            // Add cancel button
            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (actionCancel) =>
            {
                // Any action?
                if (action != null)
                {
                    action(false);
                }
            }));

            // Add ok button
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (actionOK) =>
            {
                // Any action?
                if (action != null)
                {
                    action(true);
                }
            }));

            // Display the alert
            controller.PresentViewController(alert, true, null);

            // Return created controller
            return alert;
        }

    /// <summary>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="placeholder"></param>
    /// <param name="text"></param>
    /// <param name="controller"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static UIAlertController PresentTextInputAlert(string title, string description, string placeholder,
        string text, UIViewController controller, AlertTextInputDelegate action)
    {
            // No, inform the user that they must create a home first
            var alert = UIAlertController.Create(title, description, UIAlertControllerStyle.Alert);
            UITextField? field = null;

            // Add and configure text field
            alert.AddTextField((textField) =>
            {
                // Save the field
                field = textField;

                // Initialize field
                field.Placeholder = placeholder;
                field.Text = text;
                field.AutocorrectionType = UITextAutocorrectionType.No;
                field.KeyboardType = UIKeyboardType.Default;
                field.ReturnKeyType = UIReturnKeyType.Done;
                field.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            });

            // Add cancel button
            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (actionCancel) =>
            {
                // Any action?
                if (action != null)
                {
                    action(false, "");
                }
            }));

            // Add ok button
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (actionOK) =>
            {
                // Any action?
                if (action != null && field != null)
                {
                    action(true, field.Text ?? "");
                }
            }));

            // Display the alert
            controller.PresentViewController(alert, true, null);

            // Return created controller
            return alert;
        }


    /// <summary>
    /// </summary>
    /// <param name="OK"></param>
    public delegate void AlertOKCancelDelegate(bool OK);

    /// <summary>
    /// </summary>
    /// <param name="OK"></param>
    /// <param name="text"></param>
    public delegate void AlertTextInputDelegate(bool OK, string text);

}