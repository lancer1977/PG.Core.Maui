/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-ios)'
Before:
using System.Linq;
using System.Reflection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
After:
using System.Maui.Graphics;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
*/

/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-windows10.0.22621.0)'
Before:
using System.Linq;
using System.Reflection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
After:
using System.Maui.Graphics;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
*/

using System.Diagnostics;
using BindingFlags = System.Reflection.BindingFlags;

namespace PolyhydraGames.Core.Maui.Extensions;

public static class ResourceDictionaryExtensions
{
    public static Color GetColorResource(this ResourceDictionary resource, string key)
    {
        object obj;
        try
        {
            var val = resource.TryGetValue(key, out obj);
            return val ? (Color)obj : ColorDefs.Black;
        }
        catch (Exception ex)
        {
            return ColorDefs.MediumOrchid;
        }
    }

 
    //public static bool TryUpdateColor(this ResourceDictionary dictionary, string key, string hex)
    //{
    //    var color = ColorDefs.White;
    //    try
    //    {
    //        if (string.IsNullOrEmpty(hex) || !hex.Contains('#')) return false;
    //        if (hex.TryFromArgb(ref color)) return dictionary.TrySetValue(key, color);
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.ToString());
    //    }

    //    return false;
    //}

    //public static bool TrySetValue(this ResourceDictionary dictionary, string key, object value)
    //{
    //    if (!dictionary.ContainsKey(key))
    //        return dictionary.SetMergedInstance(key, value) ||
    //               dictionary.MergedDictionaries.Any(item => TrySetValue(item, key, value));
    //    dictionary[key] = value;
    //    return true;
    //}

    //public static bool SetMergedInstance(this ResourceDictionary dictionary, string key, object value)
    //{
    //    //FieldInfo fi = typeof(ResourceDictionary).GetField("_mergedInstance", BindingFlags.NonPublic | BindingFlags.Instance);
    //    var obj = typeof(ResourceDictionary).GetField("_mergedInstance",
    //            BindingFlags.NonPublic | BindingFlags.Instance)
    //        ?.GetValue(dictionary);
    //    if (!(obj is ResourceDictionary mergedInstance)) return false;
    //    return mergedInstance.TrySetValue(key, value);
    //}
}