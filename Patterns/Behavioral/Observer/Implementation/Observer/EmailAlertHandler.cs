using System;
using System.Collections.Generic;
using Patterns.Behavioral.Observer.EventData;
using Patterns.Behavioral.Observer.Interface;

namespace Patterns.Behavioral.Observer.Implementation.Observer
{
    internal class EmailAlertHandler : IAlertObserver
    {
        public string Name => "EmailNotificationService";

        public void OnAlertReceived(AlertEventArgs alert, Action<string, string> acknowledgeCallback)
        {
            Console.WriteLine($"📧 [{Name}] Dispatching urgent email for: '{alert.Message}'");

            // Simulate processing time and acknowledge
            acknowledgeCallback(alert.AlertId, Name);
        }
    }
}
