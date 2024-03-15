namespace PolyhydraGames.Core.Maui.Setup;

public partial class DeviceModule
{

    private static DeviceModule? _instance;
    public static DeviceModule Instance => _instance ??= new DeviceModule();

    public partial MauiAppBuilder RegisterPlatformServices(MauiAppBuilder builder);
}