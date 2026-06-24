using System;

// 1. Define custom Event Arguments
// In modern C#, it's standard to inherit from EventArgs

namespace Patterns.Behavioral.Observer.EventData
{
    internal class StandardAlertEventArgs: EventArgs
    {
        public string AlertId { get; }
        public string Message { get; }
        public string Severity { get; }

        public StandardAlertEventArgs(string message, string severity)
        {
            AlertId = Guid.NewGuid().ToString()[..8];
            Message = message;
            Severity = severity;
        }
    }
}
