
namespace PolyhydraGames.Core.Maui.Setup;

public static class DeviceModuleExtensions
{
    public static MauiAppBuilder RegisterPlatformServices(this MauiAppBuilder app)
    {
        return DeviceModule.Instance.RegisterPlatformServices(app);
    }
}