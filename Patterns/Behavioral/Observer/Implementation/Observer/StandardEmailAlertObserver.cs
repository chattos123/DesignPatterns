using Patterns.Behavioral.Observer.EventData;
using Patterns.Behavioral.Observer.Implementation.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.Observer.Implementation.Observer
{
    internal class StandardEmailAlertObserver : IObserver<AlertData>
    {
        private readonly AlertProvider _provider;
        public string Name => nameof(StandardEmailAlertObserver);

        public StandardEmailAlertObserver(AlertProvider provider) => _provider = provider;

        public void OnNext(AlertData value)
        {
            Console.WriteLine($"📧 [{Name}] Dispatching rapid email alert for: {value.AlertId}");

            // Dynamic acknowledgment back to the provider
            _provider.Acknowledge(value.AlertId, Name);
        }

        public void OnError(Exception error) => Console.WriteLine($"❌ [{Name}] Error encountered: {error.Message}");
        public void OnCompleted() => Console.WriteLine($"🏁 [{Name}] Alert stream closed cleanly.");
    }
}
