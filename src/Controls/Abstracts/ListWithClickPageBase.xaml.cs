namespace PolyhydraGames.Core.Maui.Controls.Abstracts;

/// <summary>
/// Legacy list page from Xamarin.Forms. Consider using CollectionView with SelectionChanged instead.
/// </summary>
[Obsolete("ListWithClickPageBase is a legacy Xamarin.Forms pattern. Use CollectionView with SelectionChanged for MAUI compatibility.")]
public partial class ListWithClickPageBase : PageBase
{
    public ListWithClickPageBase()
    {
        InitializeComponent();
    }

    public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;
        var clicked = e.SelectedItem;
        list.SelectedItem = null;
        ItemClick(clicked);
    }

    public virtual void ItemClick(object item)
    {
    }
}