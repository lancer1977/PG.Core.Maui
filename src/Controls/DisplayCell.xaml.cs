namespace PolyhydraGames.Core.Maui.Controls;

/// <summary>
/// Legacy ViewCell from Xamarin.Forms. Consider using CollectionView with DataTemplate instead.
/// </summary>
[Obsolete("DisplayCell uses ViewCell which is a Xamarin.Forms pattern. Use CollectionView with DataTemplate for MAUI compatibility.")]
public partial class DisplayCell : ViewCell
{
    public DisplayCell()
    {
        InitializeComponent();
    }
}