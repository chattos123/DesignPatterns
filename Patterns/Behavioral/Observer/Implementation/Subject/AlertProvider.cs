using Patterns.Behavioral.Observer.EventData;
using Patterns.Behavioral.Observer.Implementation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.Observer.Implementation.Subject
{
    internal class AlertProvider : IObservable<AlertData>
    {
        private readonly List<IObserver<AlertData>> _observers = new();
        private readonly Dictionary<string, HashSet<string>> _pendingAcks = new();

        // Enforce the IObservable contract
        public IDisposable Subscribe(IObserver<AlertData> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }

        // Broadcasts an alert downstream
        public void GenerateAlert(string message, string severity)
        {
            var alert = new AlertData { Message = message, Severity = severity };
            Console.WriteLine($"\n🚨 [ALERT GENERATED] ID: {alert.AlertId} | {alert.Severity.ToUpper()} | {alert.Message}");

            // Track who needs to acknowledge this alert
            _pendingAcks[alert.AlertId] = new HashSet<string>();

            foreach (var observer in _observers)
            {
                // By standard, we use the class type name or an internal identifier
                _pendingAcks[alert.AlertId].Add(observer.GetType().Name);

                // Push alert to observer
                observer.OnNext(alert);
            }
        }

        // The Ack mechanism
        public void Acknowledge(string alertId, string observerName)
        {
            if (_pendingAcks.TryGetValue(alertId, out var observersPending))
            {
                if (observersPending.Remove(observerName))
                {
                    Console.WriteLine($"   ✅ [ACK] Alert {alertId} acknowledged by {observerName}.");
                }
                else
                {
                    Console.WriteLine($"   ⚠️  Alert {alertId} was not pending acknowledgment from {observerName}.");
                }

                if (observersPending.Count == 0)
                {
                    Console.WriteLine($"🎉 [ALERT CLOSED] All observers acknowledged Alert {alertId}.");
                    _pendingAcks.Remove(alertId);
                }
            }
            else
            {
                Console.WriteLine($"   ⚠️  Alert {alertId} not found in pending acknowledgments.");
            }
        }

        public void CloseStream()
        {
            foreach (var observer in _observers.ToArray())
            {
                observer.OnCompleted();
            }
            _observers.Clear();
        }
    }
}
