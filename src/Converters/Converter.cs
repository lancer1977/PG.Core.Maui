using System.Globalization;

namespace PolyhydraGames.Core.Maui.Converters;

public abstract class Converter<T, T2> : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return TToT2((T)value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return T2ToT((T2)value);
    }

    protected abstract T T2ToT(T2 value);
    protected abstract T2 TToT2(T value);
}