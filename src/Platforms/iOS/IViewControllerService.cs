using UIKit;

namespace PolyhydraGames.Core.Maui.Services;

/// <summary>
///     For getting the view controller
/// </summary>
public interface IViewControllerService
{
    /// <summary>
    ///     Gets root view controller
    /// </summary>
    /// <returns></returns>
    UIViewController GetViewController();
}