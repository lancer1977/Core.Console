namespace PolyhydraGames.Core.Console.Services;

public class SettingService : ISettings
{
    public void AddOrUpdateValue(string key, bool value)
    {
    }

    public void AddOrUpdateValue(string key, int value)
    {
    }

    public void AddOrUpdateValue(string key, string value)
    {
    }

    public void AddOrUpdateValue(string key, double value)
    {
    }

    public double GetValueOrDefault(string key, double defaultValue)
    {
        return defaultValue;
    }

    public bool GetValueOrDefault(string key, bool defaultValue)
    {
        return defaultValue;
    }

    public int GetValueOrDefault(string key, int defaultValue)
    {
        return defaultValue;
    }

    public string GetValueOrDefault(string key, string defaultValue)
    {
        return defaultValue;
    }
}