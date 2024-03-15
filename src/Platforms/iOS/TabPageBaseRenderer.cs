//using System;
//using System.Linq;
//using Microsoft.Maui.Controls.Compatibility;
//using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
//using Microsoft.Maui.Controls.Platform;
//using PolyhydraGames.Core.Maui;
//using PolyhydraGames.Core.Maui.Views;
//using UIKit;

//[assembly: ExportRenderer(typeof(TabbedPageBase), typeof(TabPageBaseRenderer))]
//namespace PolyhydraGames.Core.Maui
//{
//  public class TabPageBaseRenderer : TabbedRenderer
//  {
//    /// <summary>
//    ///   Handles the <see cref="E:ElementChanged" /> event.
//    /// </summary>
//    /// <param name="e">The <see cref="VisualElementChangedEventArgs" /> instance containing the event data.</param>
//    protected override void OnElementChanged(VisualElementChangedEventArgs e)
//    {
//      base.OnElementChanged(e);

//      var page = (ExtendedTabbedPage)Element;

//      TabBar.TintColor = page.TintColor.ToUIColor();
//      TabBar.BarTintColor = page.BarTintColor.ToUIColor();
//      TabBar.BackgroundColor = page.BackgroundColor.ToUIColor();
//    }


//    /// <summary>
//    ///   Views the will appear.
//    /// </summary>
//    /// <param name="animated">if set to <c>true</c> [animated].</param>
//    public override void ViewWillAppear(bool animated)
//    {
//      base.ViewWillAppear(animated);

//      var page = (ExtendedTabbedPage)Element;

//      if (!string.IsNullOrEmpty(page.TabBarSelectedImage))
//      {
//        TabBar.SelectionIndicatorImage =
//          UIImage.FromFile(page.TabBarSelectedImage)
//            .CreateResizableImage(new UIEdgeInsets(0, 0, 0, 0), UIImageResizingMode.Stretch);
//      }

//      if (!string.IsNullOrEmpty(page.TabBarBackgroundImage))
//      {
//        TabBar.BackgroundImage =
//          UIImage.FromFile(page.TabBarBackgroundImage)
//            .CreateResizableImage(new UIEdgeInsets(0, 0, 0, 0), UIImageResizingMode.Stretch);
//      }

//      if (page.Badges != null && page.Badges.Count != 0)
//      {
//        var items = TabBar.Items;

//        for (var i = 0; i < page.Badges.Count; i++)
//        {
//          if (i >= items.Count())
//          {
//            continue;
//          }

//          items[i].BadgeValue = page.Badges[i];
//        }
//      }
//    }
//  }


//}

