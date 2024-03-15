using Plugin.Maui.Audio;
using PolyhydraGames.Core.Maui.Navigation;
using PolyhydraGames.Core.Maui.Services;
using System.Diagnostics;
using ITextToSpeech = PolyhydraGames.Core.Interfaces.ITextToSpeech;

namespace PolyhydraGames.Core.Maui.Setup;

public static class AppBuilder
{
    public static MauiAppBuilder RegisterMauiCoreServices(this MauiAppBuilder appBuilder)
    {
#pragma warning disable CS8603
        appBuilder.Services.AddSingleton(x => Application.Current as IApp);
        appBuilder.Services.AddSingleton(x => Application.Current as IMenuControl);
#pragma warning restore CS8603
        appBuilder.AddSingleton<IViewFactoryAsync, ViewFactoryAsync>();
        appBuilder.AddSingleton<ISettings, SettingService>();
        appBuilder.AddSingleton<INavigatorAsync, NavigatorAsync>();
        appBuilder.AddSingleton<IItemPicker, ItemPicker>();

        appBuilder.AddSingleton<IHttpService, HttpService>();
        appBuilder.AddSingleton<IPolyhydraToken, TokenService>();
        appBuilder.AddSingleton<IDialogService, PopupDialogService>();
        appBuilder.AddSingleton<IFilePickerService, FilePickerService>();
        appBuilder.AddSingleton<IMainThreadDispatcher, MainThreadDispatcher>();
        appBuilder.AddSingleton<ISoundService, SoundService>();
        appBuilder.AddSingleton<ITextToSpeech, TextToSpeechWrapper>();

        appBuilder.Services.AddSingleton(AudioManager.Current);
        appBuilder.RegisterPlatformServices();
        return appBuilder;
    }

    public static MauiAppBuilder RegisterTypesAsInterfaces(this MauiAppBuilder builder, IList<Type> types)
    {
        foreach (var t in types.OrderBy(x => x.Name))
        {
            var interfaces = t.GetInterfaces();
            foreach (var i in interfaces)
                try
                {
                    builder.Services.AddSingleton(i, t);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(
                        $"IOC Error! {t.Name} was not able to be registered as {i.Name} - Error {e.Message}");
                }
        }

        return builder;
    }
     

    public static void AddSingleton<TInterface, TImplementation>(this MauiAppBuilder builder)
        where TImplementation : class, TInterface
        where TInterface : class
    {
        builder.Services.AddSingleton<TInterface, TImplementation>();
    }
}