using Android.App;

namespace PolyhydraGames.Core.Maui.Services.Abstract;

/// <summary>
///     Used to provide the current activity to services that inherit
/// </summary>
public abstract class CurrentActivityBasedService
{
    private readonly ICurrentActivityLocator _locator;

    /// <summary>
    ///     Requires the basic activity locator
    /// </summary>
    /// <param name="locator"></param>
    protected CurrentActivityBasedService(ICurrentActivityLocator locator)
    {
        _locator = locator;
    }

    /// <summary>
    ///     Returns the current activity of the app
    /// </summary>
    protected Activity CurrentActivity => _locator.GetCurrentActivity();
}