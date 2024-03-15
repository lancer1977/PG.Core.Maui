namespace PolyhydraGames.Core.Maui.Controls.Abstracts;

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