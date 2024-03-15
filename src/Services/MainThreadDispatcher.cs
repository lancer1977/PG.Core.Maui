namespace PolyhydraGames.Core.Maui.Services;

public static class MainThreadDispatcherExtension
{
    public static void InvokeOnMainThread(this BindableObject obj, Action act)
    {
        obj.Dispatcher.Dispatch(act);
    }
}

public class MainThreadDispatcher : IMainThreadDispatcher
{
    private readonly IApp _app;

    public MainThreadDispatcher(IApp app)
    {
        _app = app;
    }

    public void InvokeOnMainThread(Action action)
    {
        if (_app.MainPage == null) throw new NullReferenceException(nameof(_app.MainPage));
        //MainThread.BeginInvokeOnMainThread(action);
        _app.MainPage.InvokeOnMainThread(action);
    }
}