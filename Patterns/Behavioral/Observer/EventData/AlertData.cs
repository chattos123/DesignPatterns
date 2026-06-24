using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.Observer.EventData
{
    internal class AlertData
    {
        public string AlertId { get; } = Guid.NewGuid().ToString()[..8];
        public string Message { get; init; } = string.Empty;
        public string Severity { get; init; } = "Info";
    }
}
