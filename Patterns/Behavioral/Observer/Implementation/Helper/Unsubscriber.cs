using System;
using System.Collections.Generic;
using Patterns.Behavioral.Observer.EventData;

namespace Patterns.Behavioral.Observer.Implementation.Helper
{
    // A helper class that allows observers to unsubscribe cleanly via Dispose()
    internal class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<AlertData>> _observers;
        private readonly IObserver<AlertData> _observer;

        public Unsubscriber(List<IObserver<AlertData>> observers, IObserver<AlertData> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
