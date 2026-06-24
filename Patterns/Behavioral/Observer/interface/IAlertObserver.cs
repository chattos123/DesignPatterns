using Patterns.Behavioral.Observer.EventData;
using System;


namespace Patterns.Behavioral.Observer.Interface
{
    /// <summary>
    /// Represents an observer that receives alerts.
    /// </summary>
    internal interface IAlertObserver
    {
        string Name { get; }
        void OnAlertReceived(AlertEventArgs alert, Action<string, string> acknowledgeCallback);
    }
}
