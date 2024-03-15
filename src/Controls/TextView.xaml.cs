
namespace PolyhydraGames.Core.Maui.Controls;
public partial class TextView
{
    public TextView()
    {
        InitializeComponent();
        IsVisible = false;
    }
    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title",
        typeof(string),
        typeof(TextView),
        string.Empty,
        BindingMode.OneWay,
        propertyChanged: TitlePropertyChanged);

    private static void TitlePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var titleLabel = (TextView)bindable;
        titleLabel.title.Text = (string)newvalue;
    }

    public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value",
        typeof(string),
        typeof(TextView),
        null,
        BindingMode.OneWay,

        propertyChanged: ValuePropertyChanged);

    private static void ValuePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var titleLabel = (TextView)bindable;
        var text = (string)newvalue;
        titleLabel.value.Text = text;
        titleLabel.IsVisible = !string.IsNullOrWhiteSpace(text);
    }


    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
}
