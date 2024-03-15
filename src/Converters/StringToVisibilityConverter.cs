
namespace PolyhydraGames.Core.Maui.Converters;

public class StringToVisibilityConverter : Converter<string, bool>
{
    protected override string T2ToT(bool value) => value.ToString();

    protected override bool TToT2(string value) => !string.IsNullOrEmpty(value);
}