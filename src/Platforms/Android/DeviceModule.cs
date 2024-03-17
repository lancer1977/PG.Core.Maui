using PolyhydraGames.Core.Maui.Platforms.Android;
using PolyhydraGames.Core.Maui.Services;
using PolyhydraGames.Core.Maui.Services.Abstract;
using PolyhydraGames.Core.Maui.Services.Dialogs;
using PolyhydraGames.Core.Maui.Services.Email;
using PolyhydraGames.Core.Maui.Services.FileService;
using PolyhydraGames.Core.Maui.Services.Folders;
using PolyhydraGames.Core.Maui.Services.StatusBar;
using PolyhydraGames.Core.Maui.Services.WebsiteRequestors; 
namespace PolyhydraGames.Core.Maui.Setup;
    /// <summary>
    /// </summary>
    public partial class DeviceModule
    {
        /// <summary>
        /// </summary>
        public partial MauiAppBuilder RegisterPlatformServices(MauiAppBuilder builder)
        {
            builder.AddSingleton<IEmailService, EmailService>();
            builder.AddSingleton<IStorageFolder, FolderService>();
            builder.AddSingleton<IWebsiteRequestor, WebsiteRequestor>();
            builder.AddSingleton<IDialogService, DialogService>(); 
            builder.AddSingleton<IStatusBarManager, StatusBarManager>();
            builder.AddSingleton<IFileService,FileService >();
            builder.AddSingleton<IAvailiableAppsService,AvailiableAppsService>();
            builder.AddSingleton<ICurrentActivityLocator,CurrentActivityLocatorService>();
            
            return builder;
        }
    }




//email
//folder
//website
//IDialogService

//IItemPicker
//IStatusBarManager