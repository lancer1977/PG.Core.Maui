using System.Collections;

namespace PolyhydraGames.Core.Maui.Controls;

/// <summary>
///     Class GridView.
/// </summary>
public class GridView : ContentView
{
    //
    // Static Fields
    //
    /// <summary>
    ///     The items source property
    /// </summary>
    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(GridView));

    /// <summary>
    ///     The item template property
    /// </summary>
    public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(GridView));

    /// <summary>
    ///     The row spacing property
    /// </summary>
    public static readonly BindableProperty RowSpacingProperty = BindableProperty.Create("RowSpacing", typeof(double), typeof(GridView), (double)0);

    /// <summary>
    ///     The column spacing property
    /// </summary>
    public static readonly BindableProperty ColumnSpacingProperty = BindableProperty.Create("ColumnSpacing", typeof(double), typeof(GridView), (double)0);

    /// <summary>
    ///     The item width property
    /// </summary>
    public static readonly BindableProperty ItemWidthProperty = BindableProperty.Create("ItemWidth", typeof(double), typeof(GridView), (double)100);

    /// <summary>
    ///     The item height property
    /// </summary>
    public static readonly BindableProperty ItemHeightProperty = BindableProperty.Create("ItemHeight", typeof(double), typeof(GridView), (double)100);

    /// <summary>
    ///     Initializes a new instance of the <see cref="GridView" /> class.
    /// </summary>
    public GridView()
    {
        SelectionEnabled = true;

    }

    //
    // Properties
    //
    /// <summary>
    ///     Gets or sets the items source.
    /// </summary>
    /// <value>The items source.</value>
    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    /// <summary>
    ///     Gets or sets the item template.
    /// </summary>
    /// <value>The item template.</value>
    public DataTemplate ItemTemplate
    {
        get => (DataTemplate)GetValue(ItemTemplateProperty);
        set => SetValue(ItemTemplateProperty, value);
    }

    /// <summary>
    ///     Gets or sets the row spacing.
    /// </summary>
    /// <value>The row spacing.</value>
    public double RowSpacing
    {
        get => (double)GetValue(RowSpacingProperty);
        set => SetValue(RowSpacingProperty, value);
    }

    /// <summary>
    ///     Gets or sets the column spacing.
    /// </summary>
    /// <value>The column spacing.</value>
    public double ColumnSpacing
    {
        get => (double)GetValue(ColumnSpacingProperty);
        set => SetValue(ColumnSpacingProperty, value);
    }

    /// <summary>
    ///     Gets or sets the width of the item.
    /// </summary>
    /// <value>The width of the item.</value>
    public double ItemWidth
    {
        get => (double)GetValue(ItemWidthProperty);
        set => SetValue(ItemWidthProperty, value);
    }

    /// <summary>
    ///     Gets or sets the height of the item.
    /// </summary>
    /// <value>The height of the item.</value>
    public double ItemHeight
    {
        get => (double)GetValue(ItemHeightProperty);
        set => SetValue(ItemHeightProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether [selection enabled].
    /// </summary>
    /// <value><c>true</c> if [selection enabled]; otherwise, <c>false</c>.</value>
    public bool SelectionEnabled { get; set; }

    /// <summary>
    ///     Occurs when item is selected.
    /// </summary>
    public event EventHandler<object>? ItemSelected;

    /// <summary>
    ///     Invokes the item selected event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="item">Item.</param>
    public void InvokeItemSelectedEvent(object? sender, object item)
    {
        ItemSelected?.Invoke(sender, item);
    }
}