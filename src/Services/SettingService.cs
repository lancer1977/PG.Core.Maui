namespace PolyhydraGames.Core.Maui.Services;

public class SettingService : ISettings
{
    public void AddOrUpdateValue(string key, bool value)
    {
        Preferences.Set(key, value);
    }

    public void AddOrUpdateValue(string key, int value)
    {
        Preferences.Set(key, value);
    }

    public void AddOrUpdateValue(string key, string value)
    {
        Preferences.Set(key, value);
    }

    public void AddOrUpdateValue(string key, double value)
    {
        Preferences.Set(key, value);
    }

    public double GetValueOrDefault(string key, double defaultValue)
    {
        return Preferences.Get(key, defaultValue);
    }

    public bool GetValueOrDefault(string key, bool defaultValue)
    {
        return Preferences.Get(key, defaultValue);
    }

    public int GetValueOrDefault(string key, int defaultValue)
    {
        return Preferences.Get(key, defaultValue);
    }

    public string GetValueOrDefault(string key, string defaultValue)
    {
        return Preferences.Get(key, defaultValue);
    }
}