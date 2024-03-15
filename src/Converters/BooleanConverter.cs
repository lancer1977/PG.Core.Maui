namespace PolyhydraGames.Core.Maui.Converters;

public class BooleanConverter : Converter<bool,bool>, IMarkupExtension
{
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }



    protected override bool T2ToT(bool value) => !value;

    protected override bool TToT2(bool value) => !value;
}