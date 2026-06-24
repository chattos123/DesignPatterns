using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.Observer.Interface
{
    /// <summary>
    ///   The Subject (Observable) Interface
    /// </summary>
    internal interface IAlertGenerator
    {
        void RegisterObserver(IAlertObserver observer);
        void RemoveObserver(IAlertObserver observer);
        void NotifyObservers(string message, string severity);
        void AcknowledgeAlert(string alertId, string observerName);
    }
}
