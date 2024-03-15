using UIKit;

namespace PolyhydraGames.Core.Maui.Services;

/// <summary>
/// </summary>
public static class Extensions
{
    /// <summary>
    /// </summary>
    /// <param name="item"></param>
    /// <param name="action"></param>
    /// <param name="title"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static UIAlertAction CreateUIAlertAction<T>(this T item, Action<T> action, string title = "")
    {
            if (item == null) throw new NullReferenceException("CreateUIAlertAction");

            title = string.IsNullOrEmpty(title) ? item.ToString() ?? "" : title;

            return UIAlertAction.Create(title, UIAlertActionStyle.Default, (ctx) => action(item));

        }

    /// <summary>
    ///     Add method for converting to NS String
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static Foundation.NSString ToNSString(this string val)
    {
            return new Foundation.NSString(val);
        }
}