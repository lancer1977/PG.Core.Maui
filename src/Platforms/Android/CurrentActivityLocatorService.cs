using Android.App;

namespace PolyhydraGames.Core.Maui.Services.Abstract;

/// <summary>
/// </summary>
public class CurrentActivityLocatorService : ICurrentActivityLocator
{
    /// <summary>
    ///     Get current Activity
    /// </summary>
    /// <returns></returns>
    public Activity GetCurrentActivity()
    {
            return Platform.CurrentActivity;
        }
}