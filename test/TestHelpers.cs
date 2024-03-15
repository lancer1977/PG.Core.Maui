using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PolyhydraGames.Core.Maui.Test; 
public static class TestHelpers
{
    public static IConfiguration GetConfig()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public static ILogger<T> GetLogger<T>()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        return loggerFactory.CreateLogger<T>();
    }
}