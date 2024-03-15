

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
     
}