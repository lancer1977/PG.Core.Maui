
using System.ComponentModel;

namespace PolyhydraGames.Core.Maui.Views.Web;

public class WebPageBase : ContentPage
{
    private readonly WebView _web;

    public WebPageBase()
    {
        //  InitializeComponent();

        this.SetBinding(TitleProperty, "Title");
        Content = _web = new WebView();
    }

#pragma warning disable CS8603
    public IWebViewModelAsync ViewModel => BindingContext as IWebViewModelAsync;
#pragma warning restore CS8603

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        UpdateSource();
        ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        await ViewModel.OnAppearingAsync();

    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
        await ViewModel.OnDisappearingAsync();
    }


    private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs? e)
    {
        if (e?.PropertyName != "Html") return;
        var htmlSource = new HtmlWebViewSource { Html = ViewModel.Html };
        _web.Source = htmlSource;
    }

    private void UpdateSource()
    {
        var htmlSource = new HtmlWebViewSource { Html = ViewModel.Html };
        _web.Source = htmlSource;
    }
}