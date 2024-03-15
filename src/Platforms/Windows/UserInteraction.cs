namespace PolyhydraGames.Core.Maui.Services.Useriteraction;

public class Command<T> : Command
{
    public Command(Action<T> act) : base((x) => act((T)x))
    {
        }
}