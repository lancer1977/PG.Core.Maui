namespace PolyhydraGames.Core.Maui;

public static class Keys
{
    public const string BackgroundColor = "defaultBackgroundColor";
    public const string SplashColor = "splashColor";

    public const string LabelTitleTextColor = "labelTitleTextColor";
    public const string LabelTitleBackgroundColor = "labelTitleBackgroundColor";

    public const string LabelHeaderTextColor = "labelHeaderTextColor";
    public const string LabelHeaderBackgroundColor = "labelHeaderBackgroundColor";

    public const string LabelNormalTextColor = "labelNormalTextColor";
    public const string LabelNormalBackgroundColor = "labelNormalBackgroundColor";

    public const string TextCellTextColor = "textCellTextColor";
    public const string TextCellDetailColor = "textCellDetailColor";
    public const string TextCellBackgroundColor = "textCellBackgroundColor";

    public const string ButtonTextColor = "buttonTextColor";
    public const string ButtonColor = "buttonColor";

    public static string[] GetKeys()
    {
        return new[]
        {
            BackgroundColor, SplashColor,
            LabelTitleTextColor, LabelTitleBackgroundColor,
            LabelHeaderTextColor, LabelHeaderBackgroundColor,
            LabelNormalTextColor, LabelNormalBackgroundColor,
            TextCellTextColor, TextCellDetailColor, TextCellBackgroundColor,
            ButtonTextColor, ButtonColor
        };
    }
}