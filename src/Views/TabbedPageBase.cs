using System.Diagnostics;

namespace PolyhydraGames.Core.Maui.Views;
public abstract class TabbedPageBase : TabbedPage
{
    private bool _tabsInitialized;

    protected TabbedPageBase()
    {
        _viewFactory = IOC.IOC.Get<IViewFactoryAsync>();
        Badges = new List<string>();
    }

    protected abstract IEnumerable<IViewModelAsync> SubViewModels { get; }

    /// <summary>
    /// Registered Listeners, calls ViewModel.OnAppearing as well
    /// Loads any content set in ViewModel.LocalPage already
    /// </summary>					 
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Device.BeginInvokeOnMainThread(async () =>
        {
            if (_tabsInitialized) return;
            _tabsInitialized = true;
            foreach (var model in SubViewModels)
            {
                var item = await _viewFactory.ResolveAsync(model);
                Children.Add(item);
            }
        });
        //ViewModel.OnAppearing();
    }

    protected override void OnCurrentPageChanged()
    {
        base.OnCurrentPageChanged();
        if (!_tabsInitialized) return;
        try
        {
            var index = Children.IndexOf(CurrentPage);
            ViewModel.OnIndexChanged(index);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }

    protected TabbedViewModelBase ViewModel => BindingContext as TabbedViewModelBase;

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ViewModel?.OnDisappearing();
    }


    public static readonly BindableProperty TintColorProperty = BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(TabbedPageBase));
    public static readonly BindableProperty BarTintColorProperty = BindableProperty.Create(nameof(BarTintColor), typeof(Color), typeof(TabbedPageBase));
    public static readonly BindableProperty BadgesProperty = BindableProperty.Create(nameof(Badges), typeof(List<string>), typeof(TabbedPageBase));
    public static readonly BindableProperty TabBarSelectedImageProperty = BindableProperty.Create(nameof(TabBarSelectedImage), typeof(string), typeof(TabbedPageBase));
    public static readonly BindableProperty TabBarBackgroundImageProperty = BindableProperty.Create(nameof(TabBarBackgroundImage), typeof(string), typeof(TabbedPageBase));
    public static readonly BindableProperty ItemTemplateSelectorProperty = BindableProperty.Create(nameof(ItemTemplateSelector), typeof(DataTemplateSelector), typeof(TabbedPageBase), default(DataTemplateSelector), propertyChanged: (bindable, value, newValue) => OnDataTemplateSelectorChanged(bindable, value as DataTemplateSelector, newValue as DataTemplateSelector));

    private readonly IViewFactoryAsync _viewFactory;

    /// <summary>
    ///     Initializes a new instance of the <see cref="TabbedPageBase" /> class.
    /// </summary>


    /// <summary>
    ///     Gets or sets the item template selector.
    /// </summary>
    /// <value>The item template selector.</value>
    public DataTemplateSelector ItemTemplateSelector
    {
        get => (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty);
        set => SetValue(ItemTemplateSelectorProperty, value);
    }

    /// <summary>
    ///     Gets or sets the color of the tint.
    /// </summary>
    /// <value>The color of the tint.</value>
    public Color TintColor
    {
        get => (Color)GetValue(TintColorProperty);
        set => SetValue(TintColorProperty, value);
    }

    /// <summary>
    ///     Gets or sets the color of the bar tint.
    /// </summary>
    /// <value>The color of the bar tint.</value>
    public Color BarTintColor
    {
        get => (Color)GetValue(BarTintColorProperty);
        set => SetValue(BarTintColorProperty, value);
    }

    /// <summary>
    ///     Gets or sets the badges.
    /// </summary>
    /// <value>The badges.</value>
    public List<string> Badges
    {
        get => (List<string>)GetValue(BadgesProperty);
        set => SetValue(BadgesProperty, value);
    }

    /// <summary>
    ///     Gets or sets the tab bar selected image.
    /// </summary>
    /// <value>The tab bar selected image.</value>
    public string TabBarSelectedImage
    {
        get => (string)GetValue(TabBarSelectedImageProperty);
        set => SetValue(TabBarSelectedImageProperty, value);
    }

    /// <summary>
    ///     Gets or sets the tab bar background image.
    /// </summary>
    /// <value>The tab bar background image.</value>
    public string TabBarBackgroundImage
    {
        get => (string)GetValue(TabBarBackgroundImageProperty);
        set => SetValue(TabBarBackgroundImageProperty, value);
    }

    private static void OnDataTemplateSelectorChanged(BindableObject bindable, DataTemplateSelector oldvalue, DataTemplateSelector newvalue)
    {
        ((TabbedPageBase)bindable).OnDataTemplateSelectorChanged(oldvalue, newvalue);
    }

    /// <summary>
    ///     Called when [data template selector changed].
    /// </summary>
    /// <param name="oldValue">The old value.</param>
    /// <param name="newValue">The new value.</param>
    /// <exception cref="System.ArgumentException">Cannot set both ItemTemplate and ItemTemplateSelector;ItemTemplateSelector</exception>
    protected virtual void OnDataTemplateSelectorChanged(DataTemplateSelector oldValue,
        DataTemplateSelector newValue)
    {
        // check to see we don't have an ItemTemplate set
        if (ItemTemplate != null && newValue != null)
            throw new ArgumentException("Cannot set both ItemTemplate and ItemTemplateSelector",
                "ItemTemplateSelector");
         
    }
}
