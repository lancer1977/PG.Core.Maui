
using ReactiveUI;

namespace PolyhydraGames.Core.Maui.Controls.MultiPickerDialog;

public class MultiPickerItem : ReactiveObject
{
    private object _data;

    private string _name;
    private bool _selected;

    public bool Selected
    {
        get => _selected;
        set => SetValue(ref _selected, value);
    }

    public string Name
    {
        get => _name;
        set => SetValue(ref _name, value);
    }

    public object Data
    {
        get => _data;
        set => SetValue(ref _data, value);
    }


    protected void SetValue<T>(ref T refVal, T value, [CallerMemberName] string propertyName = "")
    {
        if (Equals(refVal, value)) return;

        refVal = value;
        this.RaisePropertyChanged(propertyName);
    }

    public MultiPickerItem(object data, string name)
    {
        _data = data;
        _name = name;
    }
}