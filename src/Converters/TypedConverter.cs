
using System.Globalization;

namespace PolyhydraGames.Core.Maui.Converters;

public abstract class TypedConverter<T, T2> : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => To(value);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => From(value);

    protected abstract T2 To(object value);
    protected abstract T From(object value);
}