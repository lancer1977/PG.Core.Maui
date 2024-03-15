namespace PolyhydraGames.Core.Maui.Models;

public class ToggleBoolean : PropertyChangedBase
{
    private readonly string _title;
    private Func<bool> Get { get; }

    private Action<bool> Set { get; }

    public bool IsToggled
    {
        get { return Get(); }
        set
        {
                Set(value);
                OnPropertyChanged();
            }
    }
    public string Title => _title;

    public ToggleBoolean(string title, Func<bool> get, Action<bool> set)
    {
            _title = title;
            Get = get;
            Set = set;
        }

}