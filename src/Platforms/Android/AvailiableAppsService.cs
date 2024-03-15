using Android.Content.PM;
using PolyhydraGames.Core.Maui.Services;
using PolyhydraGames.Core.Maui.Services.Abstract;

namespace PolyhydraGames.Core.Maui.Platforms.Android;

public class AvailiableAppsService : ActivityServiceBase, IAvailiableAppsService
{
    /// <inheritdoc />
    public AvailiableAppsService(ICurrentActivityLocator locator) : base(locator)
    {
        }

    /// <inheritdoc />
    public bool IsAppInstalled(Enum app)
    {
            //switch (app)
            //{
            //    case PFApps.PFAssistant:
            //        return IsAppInstalled("com.polyhydragames.pathfinderpaid");
            //    case PFApps.PFCraftingCalculator:
            //        return IsAppInstalled("com.polyhydragames.PFCraftingCalculator");
            //    case PFApps.PFGrimoire:
            //        return IsAppInstalled("com.polyhydragames.PFSpellbookCalculator");
            //    case PFApps.PFLootRoller:
            //        return IsAppInstalled("com.polyhydragames.PFLootRoller");
            //}

            return false;
        }

    private bool IsAppInstalled(string uri)
    {
            var pm = Activity.PackageManager;
            bool appInstalled;
            try
            {
                pm.GetPackageInfo(uri, PackageInfoFlags.Activities);
                appInstalled = true;
            }
            catch (PackageManager.NameNotFoundException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                appInstalled = false;
            }

            return appInstalled;
        }
}