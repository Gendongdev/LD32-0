using UnityEngine;
using System.Collections;

public class Analytics : MonoBehaviour
{
    public GoogleAnalyticsV3 googleAnalytics;

    public void TrackEvent(string action)
    {
        try
        {
            googleAnalytics.LogEvent("Game", action, "common", 0);
        }
        catch { }
    }
}
