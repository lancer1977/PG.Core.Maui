namespace PolyhydraGames.Core.Maui.Controls;

public partial class ListPageBase : ContentPage
{
    public ListPageBase()
    {
        InitializeComponent();
    }

    public IListViewModelAsync ViewModel => this.GetViewModel<IListViewModelAsync>();

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel?.OnAppearingAsync();
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await ViewModel?.OnDisappearingAsync();
    }

    public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;
        var clicked = e.SelectedItem;
        list.SelectedItem = null;
        ViewModel.ItemClick.Execute(clicked);
    }
}