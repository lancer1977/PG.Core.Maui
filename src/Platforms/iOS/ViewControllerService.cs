using UIKit;

namespace PolyhydraGames.Core.Maui.Services;

public class ViewControllerService : IViewControllerService
{
    public UIViewController GetViewController()
    {
            return RootControllerHelper.GetCurrentViewController();
        }
}