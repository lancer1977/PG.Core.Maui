
//using PolyhydraGames.Core.Maui.Services.AppLauncher;
//using PolyhydraGames.Core.Maui.Services.AvailiableAppsServices;
using PolyhydraGames.Core.Maui.Services.Email;
using PolyhydraGames.Core.Maui.Services.Folders;
using PolyhydraGames.Core.Maui.Services.StatusBar;
using PolyhydraGames.Core.Maui.Services.WebsiteRequestors;

namespace PolyhydraGames.Core.Maui.Setup;

public partial class DeviceModule
{
    public partial MauiAppBuilder RegisterPlatformServices(MauiAppBuilder builder)
    {
        builder.AddSingleton<IEmailService, EmailService>();
        builder.AddSingleton<IWebsiteRequestor, WebsiteRequestor>();
        builder.AddSingleton<IStatusBarManager, StatusBarManager>();
        builder.AddSingleton<IStorageFolder, FolderService>();
        //builder.AddSingleton<IAppLauncher, AppLauncherService>();
        //builder.AddSingleton<IAvailiableAppsService, AvailiableAppsService>();

        //builder.Register((ctx) => Plugin.Settings.CrossSettings.Current).As<ISettings>();
        return builder;
    }
    //email
    //folder
    //website
    //IDialogService

    //IItemPicker
    //IStatusBarManager
}