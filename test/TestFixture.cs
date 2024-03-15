using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PolyhydraGames.Core.Maui.Test;

public static class TestFixtures
{
    public static IHost GetHost(Action<HostBuilderContext, IServiceCollection> registrations)
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((ctx, services) =>
            { 
                registrations.Invoke(ctx, services);
                services.AddLogging(x =>
                {
                    x.AddConsole();
                });
            }).Build();
    }
}