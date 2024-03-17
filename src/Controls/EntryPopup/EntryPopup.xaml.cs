namespace PolyhydraGames.Core.Maui.Controls.EntryPopup;

public partial class EntryPopupPage
{
    public EntryPopupPage()
    {
        InitializeComponent();
    }

    //This will force the pop to close when the background area is clicked
    protected override bool OnBackgroundClicked()
    {
        CloseAllPopup();
        var vm = ViewModel as EntryPopupViewModel;
        if (vm != null)
        {

            vm.CancelCommand.Execute(null);
            return false;
        }

        return false;
    }


    private async Task CloseAllPopup()
    {
        await Navigation.PopAllPopupAsync(false);
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //var item = e.SelectedItem as object;
        if (e.SelectedItem == null) return;
#pragma warning disable CS8602
        (ViewModel as EntryPopupViewModel).Choice = e.SelectedItem;
#pragma warning restore CS8602
    }
}