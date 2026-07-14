using Patterns.Behavioral.ChainofResponsibility.Implementation.Data;
using System;

namespace Patterns.Behavioral.ChainofResponsibility.Implementation
{
    internal class Tier2Support: SupportHandler
    {
        protected override bool CanHandle(SupportTicket ticket)
        {
            if (ticket.Severity <= 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"[INFO] Tier 2 cannot handle Ticket #{ticket.Id} ('{ticket.Description}'). Escalating to Tier 3.");
                return false;
            }
        }

        protected override void Execute(SupportTicket ticket)
        {
            Console.WriteLine($"[SUCCESS] Tier 2 resolved advanced Ticket #{ticket.Id} ('{ticket.Description}').");
        }
    }
}
