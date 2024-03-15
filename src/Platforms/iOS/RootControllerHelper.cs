using UIKit;

namespace PolyhydraGames.Core.Maui.Services;

public static class RootControllerHelper
{
    public static UIViewController GetCurrentViewController()
    {
            var root = UIApplication.SharedApplication?.KeyWindow?.RootViewController;
            while (true)
            {
                switch (root)
                {
                    case UINavigationController navigationController:
                        root = navigationController.VisibleViewController;
                        continue;
                    case UITabBarController uiTabBarController:
                        root = uiTabBarController.SelectedViewController;
                        continue;
                }

                if (root != null && root.PresentedViewController == null) return root;
                root = root?.PresentedViewController;
            }
        }
}