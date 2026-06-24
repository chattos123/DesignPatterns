using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.Observer.EventData
{
    internal class AlertEventArgs
    {
        public string AlertId { get; }
        public string Message { get; }
        public string Severity { get; }
        public DateTime Timestamp { get; }

        public AlertEventArgs(string message, string severity)
        {
            AlertId = Guid.NewGuid().ToString()[..8]; // Short unique ID
            Message = message;
            Severity = severity;
            Timestamp = DateTime.UtcNow;
        }
    }
}
