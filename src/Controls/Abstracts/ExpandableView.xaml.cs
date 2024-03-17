using CommunityToolkit.Maui.Views;


namespace PFAssistant.Maui.Controls;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ExpandableView : ContentView
{
    public ExpandableView()
    {
        InitializeComponent();
        BindingContextChanged += OnBindingContextChanged;
    }
    public static readonly BindableProperty SymbolProperty =
      BindableProperty.Create(nameof(Symbol), typeof(string), typeof(ExpandableView), null, propertyChanged:
          (bindable, value, newValue) =>
          {
              var view = (ExpandableView)bindable;
              view.SymbolLabel.Text = newValue as string;
          });

    public string Symbol
    {
        get { return (string)GetValue(SymbolProperty); }
        set { SetValue(SymbolProperty, value); }
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(ExpandableView), null, propertyChanged:
            (bindable, value, newValue) =>
            {
                var view = (ExpandableView)bindable;
                view.TitleLabel.Text = newValue as string;
            });

    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }



    public static readonly BindableProperty ExpanderContentProperty =
        BindableProperty.Create(nameof(ExpanderContent), typeof(IView), typeof(ExpandableView), null, propertyChanged:
            (bindable, value, newValue) =>
            {
                var view = (ExpandableView)bindable;
                view.Expander.Content = newValue as IView;
            });

    public IView? ExpanderContent
    {
        get { return (IView)GetValue(ExpanderContentProperty); }
        set { SetValue(ExpanderContentProperty, value); }
    }


    protected Expander Expander { get; set; } = new();
    public INotifyPropertyChanged ViewModel => (INotifyPropertyChanged)BindingContext;

    public void Dispose()
    {
        if (ViewModel == null) return;
        ViewModel.PropertyChanged -= ViewModelOnPropertyChanged;
    }

    private void OnBindingContextChanged(object sender, EventArgs e)
    {

        if (ViewModel != null)
        {
            ViewModel.PropertyChanged -= ViewModelOnPropertyChanged;
        }
        ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
    }

    private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsExpanded")
        {
            Expander.ForceLayout();
        }
        if (e.PropertyName == "CountChanged")
        {
            Expander.ForceLayout();
        }
    }
}
