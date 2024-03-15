
using Android.App;

namespace PolyhydraGames.Core.Maui.Services.Abstract;

/// <summary>
/// </summary>
public abstract class ActivityServiceBase
{
    private readonly ICurrentActivityLocator _locator;

    /// <summary>
    /// </summary>
    /// <param name="locator"></param>
    protected ActivityServiceBase(ICurrentActivityLocator locator)
    {
            _locator = locator;
        }

    /// <summary>
    /// </summary>
    protected Activity Activity => _locator.GetCurrentActivity();
}