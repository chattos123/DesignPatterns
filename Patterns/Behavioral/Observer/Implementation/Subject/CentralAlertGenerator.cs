using Patterns.Behavioral.Observer.EventData;
using Patterns.Behavioral.Observer.Interface;
using System;
using System.Collections.Generic;

namespace Patterns.Behavioral.Observer.Implementation.Subject
{
    internal class CentralAlertGenerator: IAlertGenerator
    {
        private readonly List<IAlertObserver> _observers = new();
        private readonly Dictionary<string, HashSet<string>> _pendingAcknowledgements = new();

        public void RegisterObserver(IAlertObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                Console.WriteLine($"[System] {observer.Name} connected to alert stream.");
            }
        }

        public void RemoveObserver(IAlertObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
                Console.WriteLine($"[System] {observer.Name} disconnected.");
            }
        }

        public void NotifyObservers(string message, string severity)
        {
            var alert = new AlertEventArgs(message, severity);
            Console.WriteLine($"\n🚨 [ALERT GENERATED] ID: {alert.AlertId} | {alert.Severity.ToUpper()} | {alert.Message}");

            // Track which observers need to acknowledge this alert
            _pendingAcknowledgements[alert.AlertId] = new HashSet<string>();
            foreach (var observer in _observers)
            {
                _pendingAcknowledgements[alert.AlertId].Add(observer.Name);
            }

            // Broadcast to all observers
            foreach (var observer in _observers)
            {
                // Passing a callback delegate so observers can acknowledge asynchronously/instantly
                observer.OnAlertReceived(alert, AcknowledgeAlert);
            }
        }

        public void AcknowledgeAlert(string alertId, string observerName)
        {
            if (_pendingAcknowledgements.TryGetValue(alertId, out var observersPending))
            {
                if (observersPending.Remove(observerName))
                {
                    Console.WriteLine($"✅ [ACK RECEIVED] Alert {alertId} acknowledged by {observerName}.");
                }

                if (observersPending.Count == 0)
                {
                    Console.WriteLine($"🎉 [ALERT CLOSED] All components acknowledged Alert {alertId}.");
                    _pendingAcknowledgements.Remove(alertId);
                }
            }
        }
    }
}
