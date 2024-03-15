using PolyhydraGames.Core.Maui.Navigation;

namespace PolyhydraGames.Core.Maui.Controls.MultiPickerDialog;

public partial class MultiPickerDialogPage : PopupPageBase
{
    public MultiPickerDialogPage()
    {
        InitializeComponent();
    }

    private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var vm = ViewModel as MultiPickerDialogViewModel;
        var selected = e.SelectedItem as MultiPickerItem;
        if (selected != null)
            vm?.ItemSelected(selected);
        list.SelectedItem = null;
    }

    //This will force the pop to close when the background area is clicked
    protected override bool OnBackgroundClicked()
    {
        Task.Run(() =>
        {
            Navigation.PopAllPopupAsync(false);

            return false;
        });

        return true;

    }
}