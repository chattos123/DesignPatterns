using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.ChainofResponsibility.Implementation.Data
{
    internal class SupportTicket
    {
        //The Request Object
        public string Description { get; }
        public int Severity { get; } // 1 = Low, 2 = Medium, 3 = High

        public int Id { get; set; } // Unique identifier for the ticket

        public SupportTicket(string description, int severity, int id)
        {
            Description = description;
            Severity = severity;
            Id = id;
        }
    }
}
