using UIKit;

namespace PolyhydraGames.Core.Maui.Services.StatusBar;

/// <summary>
/// </summary>
public class StatusBarManager : IStatusBarManager
{
    /// <summary>
    ///     Enable or disable
    /// </summary>
    /// <param name="showBar"></param>
    public void Show(bool showBar)
    {
            UIApplication.SharedApplication.StatusBarHidden = !showBar;
        }
}