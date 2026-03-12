namespace PolyhydraGames.Core.Maui.Controls;

/// <summary>
/// Legacy display view from Xamarin.Forms. Consider using ContentView directly instead.
/// </summary>
[Obsolete("DisplayableView is a legacy control. Use ContentView directly for MAUI compatibility.")]
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class DisplayableView
{
    public DisplayableView()
    {
        InitializeComponent();
    }
}