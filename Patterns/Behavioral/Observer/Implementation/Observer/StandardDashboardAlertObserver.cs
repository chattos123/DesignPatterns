using Patterns.Behavioral.Observer.EventData;
using Patterns.Behavioral.Observer.Implementation.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.Observer.Implementation.Observer
{
    internal class StandardDashboardAlertObserver : IObserver<AlertData>
    {
        private readonly AlertProvider _provider;
        public string Name => nameof(StandardDashboardAlertObserver);

        public StandardDashboardAlertObserver(AlertProvider provider) => _provider = provider;

        public void OnNext(AlertData value)
        {
            Console.WriteLine($"🖥️ [{Name}] Flashing red warning on UI dashboard for: {value.AlertId}");
            _provider.Acknowledge(value.AlertId, Name);
        }

        public void OnError(Exception error) => Console.WriteLine($"❌ [{Name}] Error encountered: {error.Message}");
        public void OnCompleted() => Console.WriteLine($"🏁 [{Name}] Alert stream closed cleanly.");
    }
}
