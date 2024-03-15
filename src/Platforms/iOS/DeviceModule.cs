using PolyhydraGames.Core.Maui.Services.Dialogs;
using PolyhydraGames.Core.Maui.Services.Email;
using PolyhydraGames.Core.Maui.Services.Folders;
using PolyhydraGames.Core.Maui.Services.ItemPickers;
using PolyhydraGames.Core.Maui.Services.StatusBar;
using PolyhydraGames.Core.Maui.Services.WebsiteRequestors;

namespace PolyhydraGames.Core.Maui.Setup;

public partial class DeviceModule
{
    /// <summary>
    /// </summary>
    /// <param name="builder"></param>
    public partial MauiAppBuilder RegisterPlatformServices(MauiAppBuilder builder)
    {
        builder.AddSingleton<IEmailService, EmailService>();
        builder.AddSingleton<IStorageFolder, FolderService>();
        builder.AddSingleton<IWebsiteRequestor, WebsiteRequestor>();
        builder.AddSingleton<IDialogService, DialogService>();
        builder.AddSingleton<IItemPicker, Pickers>();
        builder.AddSingleton<IStatusBarManager, StatusBarManager>();


        return builder;
    }
}