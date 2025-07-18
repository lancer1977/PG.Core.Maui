﻿
using Microsoft.Extensions.Logging;

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
                var ioc = new MauiIOC(x.GetRequiredService<ILogger<MauiIOC>>(),new MauiContext(x));
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