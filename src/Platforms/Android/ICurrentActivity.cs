using Android.App;

namespace PolyhydraGames.Core.Maui.Services;

/// <summary>
/// </summary>
public interface ICurrentActivityLocator
{
    /// <summary>
    /// </summary>
    /// <returns></returns>
    Activity GetCurrentActivity();
}