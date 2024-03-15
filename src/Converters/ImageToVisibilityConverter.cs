namespace PolyhydraGames.Core.Maui.Converters;

public class ImageToVisibilityConverter : Converter<string, bool>
{
    protected override string T2ToT(bool value) => "";

    protected override bool TToT2(string value) => !value.ToLower().Contains("no_art");

}

