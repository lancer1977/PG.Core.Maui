namespace PolyhydraGames.Core.Maui.Controls;

public class UserControl : Frame
{
    private readonly Dictionary<string, object> _cache = new();

    public UserControl()
    {
        Padding = new Thickness(0, 0, 0, 0);
    }

    protected T FindByViewPrivate<T>(string name)
    {
        if (_cache.TryGetValue(name, out var value1)) return (T)value1;

        var value = this.FindByField<T>(name);
        _cache.Add(name, value);
        return value;
    }

    protected T FindByViewPrivateOld<T>(string name)
    {
        if (_cache.ContainsKey(name)) return (T)_cache[name];

        var t = GetType();
        var fi = t.GetRuntimeFields().FirstOrDefault(f => f.Name == name);
        if (fi == null) throw new NullReferenceException($"Field {name} not found.");
        var value = (T) fi.GetValue(this);
        _cache.Add(name, value);
        return value;
    }
}