using Patterns.Behavioral.ChainofResponsibility.Implementation.Data;
using System;

namespace Patterns.Behavioral.ChainofResponsibility.Implementation
{
    internal class FinalSupport : SupportHandler
    {
        protected override bool CanHandle(SupportTicket ticket)
        {
            // Final support can handle any ticket that reaches this point
            if (ticket.Severity == 3)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"[INFO] Final support cannot handle ticket '{ticket.Description}' with ID {ticket.Id}. No further escalation possible.");
                return false;
            }
        }

        protected override void Execute(SupportTicket ticket)
        {
            Console.WriteLine($"[SUCCESS] Final support resolved ticket '{ticket.Description}' with ID {ticket.Id}.");
        }
    }
}
