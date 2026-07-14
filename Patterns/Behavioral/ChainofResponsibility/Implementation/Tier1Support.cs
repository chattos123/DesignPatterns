using System;
using Patterns.Behavioral.ChainofResponsibility.Implementation.Data;


namespace Patterns.Behavioral.ChainofResponsibility.Implementation
{
    internal class Tier1Support : SupportHandler
    {
        protected override bool CanHandle(SupportTicket ticket)
        {
            if (ticket.Severity <= 1)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"[INFO] Tier 1 cannot handle ticket '{ticket.Description}' with ID {ticket.Id}. Escalating to Tier 2.");
                return false;
            }
        }

        protected override void Execute(SupportTicket ticket)
        {
            Console.WriteLine($"[SUCCESS] Tier 1 resolved ticket '{ticket.Description}' with ID {ticket.Id}.");
        }

    }
}
