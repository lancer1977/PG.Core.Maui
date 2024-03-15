using MessageUI;

namespace PolyhydraGames.Core.Maui.Services.Email;

/// <summary>
///     Implements IEmail Service
/// </summary>
public class EmailService : IEmailService
{
    /// <inheritdoc />
    public async Task RequestNewEmail(string address, string subject, string messageBody = "")
    {
            var controller = new MFMailComposeViewController();
            controller.SetToRecipients(new[] { address });
            controller.SetSubject(subject);
            if (!string.IsNullOrEmpty(messageBody))
                controller.SetMessageBody(messageBody, false);
            controller.Finished += (sender, e) => { e.Controller.DismissViewController(true, null); };
            var rootController = RootControllerHelper.GetCurrentViewController();
            rootController.PresentViewController(controller, true, null);
            await Task.Delay(1);
        }
}