namespace PolyhydraGames.Core.Maui;

public class MauiIOC : IIOCContainer
{
    public MauiIOC(MauiContext context)
    {
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
        return Context.Services.GetService(type) ?? throw new InvalidOperationException();
    }

    public void Setup(List<IIOCRegistration> registrations)
    {
        throw new NotImplementedException(
            "I feel this is too brittle and not well maintained. The basic IOC container will be respected.");
    }
}