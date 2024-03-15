using System.Globalization;
using PolyhydraGames.Core.Maui.Extensions;
using PolyhydraGames.Core.Maui.Helpers;

namespace PolyhydraGames.Core.Maui.Converters;

public class HexStringToColorConverter : Converter<string,Color>
{
 
    protected override string T2ToT(Color value) => value.ToHex();


    protected override Color TToT2(string value) => value.ToColor();
}