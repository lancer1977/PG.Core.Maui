using PolyhydraGames.Core.Maui.Controls;

namespace PolyhydraGames.Core.Maui.Views;

public partial class MenuPageBase : PageBase
{
    private readonly IApp _app;

    public MenuPageBase(IApp app)
    {
        _app = app;
        InitializeComponent();
        Title = "Menu";
    }

    public new IListViewModel ViewModel
    {
        get
        {
            var vm = BindingContext as IListViewModel;
            if (vm == null) throw new NullReferenceException(nameof(ViewModel));
            return vm;
        }
    }

    public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selected = e.SelectedItem;
        if (selected == null) return;
        _menu.SelectedItem = null;
        ViewModel.ItemClick.Execute(selected);
        if (_app.MainPage is FlyoutPage master) master.IsPresented = false;
    }
}