using Patterns.Behavioral.Observer.EventData;
using Patterns.Behavioral.Observer.Interface;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Patterns.Behavioral.Observer.Implementation.Observer
{
    internal class DashboardAlertHandler: IAlertObserver
    {
        public string Name => "DevOpsLiveDashboard";

    public void OnAlertReceived(AlertEventArgs alert, Action<string, string> acknowledgeCallback)
    {
        Console.WriteLine($"🖥️ [{Name}] Rendering red flash on screen for: '{alert.Message}'");

        // Simulate processing time and acknowledge
        acknowledgeCallback(alert.AlertId, Name);
    }
}
}
