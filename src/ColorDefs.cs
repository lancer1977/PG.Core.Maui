namespace PolyhydraGames.Core.Maui;

public static class ColorDefs
{
    public static readonly Color White = Color.FromArgb("#FFFFFFFF");
    public static readonly Color Black = Color.FromArgb("#00000000");

    public static readonly Color MediumOrchid = Color.FromArgb("#ABCDABCD");

    public static bool TryFromArgb(this string argb, ref Color color)
    {
        try
        {
            color = Color.FromArgb(argb);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}