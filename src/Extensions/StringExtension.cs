using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using Color = Microsoft.Maui.Graphics.Color;

namespace PolyhydraGames.Core.Maui.Extensions;
public static class ColorExtensions
{
    public static Color ToColor(this string value)
    {
        var stringValue = value as string;
        var returnValue = ColorDefs.Black;
        if (!string.IsNullOrEmpty(stringValue)) stringValue.TryColorFromHex(ref returnValue);
        return returnValue;
    }

    public static string ToHex(this Color color)
    {
        var red = (int)(color.Red * 255);
        var green = (int)(color.Green * 255);
        var blue = (int)(color.Blue * 255);
        var alpha = (int)(color.Alpha * 255);
        var hex = $"{alpha:X2}{red:X2}{green:X2}{blue:X2}";

        return hex;
    }

    public static bool TryColorFromHex(this string input, ref Color setColor)
    {
        //var reg = @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3}|[A-Fa-f0-9]{8})$";
        var reg = @"^#(?:[0-9a-fA-F]{3}){1,2}$";
        var isValidHex = !string.IsNullOrEmpty(input) && Regex.IsMatch(input, reg);
        if (isValidHex)
            setColor = Color.FromArgb(input);
        return isValidHex;
    }



}

public static class ConfigHelpers
{
    public static T GetPlatformOption<T>(this IConfiguration config, string key)
    {
        var section = config.GetSection(DeviceInfo.Platform.ToString()).GetSection(key);
        return ConfigurationBinder.Get<T>(section);
        //section.Get<T>( ); 
    }
}