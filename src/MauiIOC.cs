using Microsoft.Extensions.Logging;

namespace PolyhydraGames.Core.Maui;

public class MauiIOC : IIOCContainer
{
    private readonly ILogger<MauiIOC> _log;

    public MauiIOC(ILogger<MauiIOC> log, MauiContext context)
    {
        _log = log;
        Context = context;
    }

    private MauiContext Context { get; }


    public T Get<T>()
    {
        return Context.Services.GetService<T>() ?? throw new InvalidOperationException();
    }

    public T Resolve<T>()
    {
        return Get<T>();
    }

    public T Resolve<T>(Type type)
    {
#pragma warning disable CS8603
#pragma warning disable CS8600
        return (T)Context.Services.GetService(type);
#pragma warning restore CS8600
#pragma warning restore CS8603
    }

    public object Resolve(Type type)
    {
        return Context.Services.GetService(type) ?? NotFound(type);
    }

    
    private object NotFound(Type type)
    {

        var error = new InvalidOperationException($"{type.Name} was not found in IOC container.");
        _log.LogCritical(error, "IOC");
        throw error;
    }
    [Obsolete]
    public void Setup(List<IIOCRegistration> registrations)
    {
        throw new NotImplementedException("I feel this is too brittle and not well maintained. The basic IOC container will be respected.");
    }
}