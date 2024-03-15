using Moq;

namespace PolyhydraGames.Core.Maui.Test;

public static class PolyMocks
{
    
    public static T Get<T>(this IServiceProvider provider, Action<Mock<T>> registrations = null) where T : class
    {
        var moq = new Moq.Mock<T>();
        registrations?.Invoke(moq);
        return moq.Object;
    }
}