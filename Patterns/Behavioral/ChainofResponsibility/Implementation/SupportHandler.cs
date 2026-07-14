using Patterns.Behavioral.ChainofResponsibility.Implementation.Data;
using System;

namespace Patterns.Behavioral.ChainofResponsibility.Implementation
{
    internal abstract class SupportHandler
    {
        // The Abstract Handler (Houses the Aggregation/Successor Link)

        // This is the self-reference (aggregation) that links the chain together
        protected SupportHandler? NextHandler;

        // Fluent method to build the chain dynamically
        public SupportHandler SetNext(SupportHandler nextHandler)
        {
            NextHandler = nextHandler;
            return nextHandler; // Returns the handler to allow chaining: h1.SetNext(h2).SetNext(h3);
        }

        // The Template Method that handles the structural flow of the chain
        public void HandleRequest(SupportTicket ticket)
        {
            if (CanHandle(ticket))
            {
                Execute(ticket);
            }
            else if (NextHandler != null)
            {
                PassToNext(ticket);
            }
            else
            {
                Console.WriteLine($"[End of Chain] Ticket '{ticket.Description}' could not be handled by anyone.");
            }
        }

        // Methods for concrete handlers to implement their specific behavior
        protected abstract bool CanHandle(SupportTicket ticket);
        protected abstract void Execute(SupportTicket ticket);

        private void PassToNext(SupportTicket ticket)
        {
            Console.WriteLine($"{this.GetType().Name} could not handle it. Passing it down the chain...");
            NextHandler?.HandleRequest(ticket);
        }
    }
}
