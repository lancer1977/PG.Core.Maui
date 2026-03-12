/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-ios)'
Before:
using Microsoft.Maui.Controls;
After:
using System.Windows.Input;
*/

/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-windows10.0.22621.0)'
Before:
using Microsoft.Maui.Controls;
After:
using System.Windows.Input;
*/

using System.Windows.Input;

namespace PolyhydraGames.Core.Maui.Controls;

/// <summary>
/// Legacy label button from Xamarin.Forms. Consider using Label with TapGestureRecognizer directly instead.
/// </summary>
[Obsolete("LabelButton is a legacy control. Use Label with TapGestureRecognizer for MAUI compatibility.")]
public partial class LabelButton : Label
{
    public static readonly BindableProperty CommandProperty = BindableProperty.Create("CommandProperty",
        typeof(ICommand), typeof(LabelButton), propertyChanged: OnCommandPropertyChanged);

    public LabelButton()
    {
        InitializeComponent();
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var picker = (LabelButton)bindable;
        if (picker.Command == null) return;
        picker.GestureRecognizers.Clear();
        picker.GestureRecognizers.Add(new TapGestureRecognizer { Command = (ICommand)newValue });
    }
}