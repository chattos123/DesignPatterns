using System;
using Patterns.Behavioral.ChainofResponsibility.Implementation;
using Patterns.Behavioral.ChainofResponsibility.Implementation.Data;
using Patterns.Simulator.Interface;

namespace Patterns.Simulator.Implementation
{
    internal class ChainofResponsibilitySimulator : ISimulator
    {
        // Move handler declarations to fields to ensure they are assigned before use
        private SupportHandler? tier1;
        private SupportHandler? tier2;
        private SupportHandler? manager;

        public void Simulate()
        {
            // Set up handlers
            SetupEnvironment();


            if (tier1 == null || tier2 == null || manager == null)
            {
                Console.WriteLine("Error: Handlers are not properly initialized.");
                return;
            }

            // Link the chain
            SetupChain();

            // 1. A standard low severity ticket
            //TBD late we can introduce a context adta for a ticket to simulate a more complex scenario
            SupportTicket ticketA = new SupportTicket("Reset Windows password", 1, 33476);
            //ContextData contextA = new ContextData(101, "Standard", "192.168.1.50");

            // 2. A medium severity ticket, 
            SupportTicket ticketB = new SupportTicket("Need a new mouse", 2, 33468);


            // 3. A high severity ticket, which should be escalated to the manager
            SupportTicket ticketC = new SupportTicket("System crash on login", 3, 33005);

            //4. A critical severity ticket, which should be escalated to the manager
            SupportTicket ticketD = new SupportTicket("Data breach detected", 4, 33006);

            // Execute the chain
            Console.WriteLine("--- Processing Ticket A ---");
            tier1.HandleRequest(ticketA);

            Console.WriteLine("\n--- Processing Ticket B ---");
            tier1.HandleRequest(ticketB);

            Console.WriteLine("\n--- Processing Ticket C ---");
            tier1.HandleRequest(ticketC);

            Console.WriteLine("\n--- Processing Ticket D ---");
            tier1.HandleRequest(ticketD);
        }

        private void SetupEnvironment()
        {
            // Assign handler fields
            tier1 = new Tier1Support();
            tier2 = new Tier2Support();
            manager = new FinalSupport();
        }

        private void SetupChain()
        {
            if (tier1 == null || tier2 == null || manager == null)
            {
                Console.WriteLine("Error: Handlers are not properly initialized.");
                return;
            }
            // Link the chain
            tier1.SetNext(tier2).SetNext(manager);
        }
    }
}
