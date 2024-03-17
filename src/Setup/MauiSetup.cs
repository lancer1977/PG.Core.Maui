
/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-ios)'
Before:
using System.Reflection;
After:
using PolyhydraGames.Core.Interfaces;
*/

/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-windows10.0.22621.0)'
Before:
using System.Reflection;
After:
using PolyhydraGames.Core.Interfaces;
*/

namespace PolyhydraGames.Core.Maui.Setup;

public static class MauiSetup
{
    public static MauiAppBuilder RegisterTypes(this MauiAppBuilder builder, List<(Type, Type)> items)
    {
        foreach (var item in items)
        {
            var (instance, inter) = item;
            builder.Services.AddScoped(instance, inter);
        }

        return builder;
    }

    public static MauiAppBuilder RegisterIOC(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IIOCContainer, MauiIOC>(x =>
            {
                var ioc = new MauiIOC(new MauiContext(x));
                IOC.IOC.Initialize(ioc);
                return ioc;
            }
        );
        return builder;
    }

    public static MauiAppBuilder RegisterPageRoutes(this MauiAppBuilder builder, Assembly assembly)
    {
        var types = assembly.CreatableTypes().EndingWith("Page").ToArray();
        foreach (var item in types)
        {
            Routing.RegisterRoute(item.Name.Replace("Page", ""), item);
            Routing.RegisterRoute(item.Name, item);
        }

        return builder;
    }

}