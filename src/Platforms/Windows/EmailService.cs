namespace PolyhydraGames.Core.Maui.Services.Email;

public class EmailService : IEmailService
{
    public async Task RequestNewEmail(string address, string subject, string messagebody = "")
    {
        throw new NotImplementedException("RequestNewEmail");
        await Task.Delay(1);
    }
}