using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace PolyhydraGames.Core.Console.Services;

//
[Obsolete("This should go into its own repository")]
public class AppCenterAnalyticsService : IAnalytics
{
    private Dictionary<string, string> _standardProperties;

    public async void Init()
    {
        IOC.IOC.Get<IAnalyticsManager>().AddService(this);
        await Analytics.SetEnabledAsync(true);
        await Crashes.SetEnabledAsync(true);
        Enabled = true;
    }

    public void SetUser(string identifier, Dictionary<string, string> userProperties = null)
    {
        _standardProperties = new Dictionary<string, string> { { "User Name", identifier } };
    }

    public void LogViewLoaded(string name)
    {
        TrackEvent();
    }

    public void LogViewUnloaded(string name)
    {
        TrackEvent();
    }

    public void LogViewDisplayed(string name)
    {
        TrackEvent();
    }

    public void LogViewHidden(string name)
    {
        TrackEvent();
    }

    public void LogEvent(string name, string category, string eventName, string eventData)
    {
        var dic = new Dictionary<string, string>
        {
            { "Category", category },
            { eventName, eventData }
        };
        TrackEvent(props: dic);
    }

    public void LogError(string name, string title, string message)
    {
        //_display.NotificationAsync(message, title + " " + name);
        var dic = new Dictionary<string, string>
        {
            { title, message }
        };
        TrackEvent(props: dic);
    }

    public void LogPerformance(string category, TimeSpan performanceCounter, Dictionary<string, string> values = null)
    {
        TrackEvent();
    }

    public bool Enabled { get; set; }

    private void TrackEvent([CallerMemberName] string callerName = "", Dictionary<string, string> props = null)
    {
        if (Enabled == false) return;
        var dic = _standardProperties != null
            ? new Dictionary<string, string>(_standardProperties)
            : new Dictionary<string, string>();

        if (props != null)
            foreach (var item in props)
                dic.Add(item.Key, item.Value);
        Analytics.TrackEvent(callerName, dic);
    }
}