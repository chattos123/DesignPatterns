# Chain of Responsibility Design Pattern in C#

The **Chain of Responsibility** is a behavioral design pattern that decouples a request's sender from its receivers by giving multiple objects a chance to handle the request. Upon receiving a request, each handler decides either to process the request or to pass it to the next handler down the chain.

---

## Intent & Problem Space

Imagine a scenario where your system needs to process incoming requests (e.g., support tickets, HTTP payloads, or authentication steps) that require multiple checks or levels of authority. Hardcoding the logic to decide which module executes which request creates rigid, tightly-coupled code. 

Instead, the **Chain of Responsibility** allows you to pass requests along a chain of handlers dynamically. The sender doesn't need to know which specific object will ultimately execute the operation, satisfying the **Single Responsibility** and **Open/Closed Principles**.

---

## Structural Architecture (UML Blueprint)

A complete production-level Chain of Responsibility system consists of the following foundational layers:

1. **Client**: Initializes the dynamic links of the chain and dispatches the initial transaction payload.
2. **Abstract Handler**: Standardizes state management by keeping a reference to the structural successor (`NextHandler`). It provides template frameworks for validation mechanisms.
3. **Concrete Handlers**: Pure architectural implementations containing distinct business capabilities. They choose whether to consume a payload or pass it along.
4. **Context Data**: Encapsulates runtime metadata (e.g., security parameters, tenant scopes, environment states) isolated cleanly away from structural properties.

---

## Complete Production C# Implementation

The code below utilizes an explicit, clean syntax framework (avoiding inline lambda notation) to model a comprehensive, context-aware support routing subsystem.

```csharp
using System;

namespace ChainOfResponsibilityExample
{
    // =========================================================================
    // 1. THE REQUEST MODEL
    // =========================================================================
    public class SupportTicket
    {
        public string Description { get; }
        public int Severity { get; } // 1 = Low, 2 = Medium, 3 = High

        public SupportTicket(string description, int severity)
        {
            Description = description;
            Severity = severity;
        }
    }

    // =========================================================================
    // 2. RUNTIME CONTEXT DATA ENVIRONMENT
    // =========================================================================
    public class ContextData
    {
        public int TicketID { get; set; }
        public string UserType { get; set; } // e.g., "VIP", "Standard"
        public string IPAddress { get; set; }

        public ContextData(int ticketId, string userType, string ipAddress)
        {
            TicketID = ticketId;
            UserType = userType;
            IPAddress = ipAddress;
        }
    }

    // =========================================================================
    // 3. THE BASE STRUCTURAL ABSTRACT HANDLER (Houses Aggregation/Self-Reference)
    // =========================================================================
    public abstract class SupportHandler
    {
        // This structural self-reference links the aggregation pattern
        protected SupportHandler NextHandler;

        // Fluent API method configuration hook
        public SupportHandler SetNext(SupportHandler nextHandler)
        {
            NextHandler = nextHandler;
            return nextHandler;
        }

        // Structural Template Control Method
        public void HandleRequest(SupportTicket ticket, ContextData context)
        {
            if (CanHandle(ticket, context))
            {
                Execute(ticket, context);
            }
            else if (NextHandler != null)
            {
                PassToNext(ticket, context);
            }
            else
            {
                Console.WriteLine($"[End of Chain] Ticket #{context.TicketID} ('{ticket.Description}') remained unhandled.");
            }
        }

        protected abstract bool CanHandle(SupportTicket ticket, ContextData context);
        protected abstract void Execute(SupportTicket ticket, ContextData context);

        private void PassToNext(SupportTicket ticket, ContextData context)
        {
            Console.WriteLine($"{this.GetType().Name} could not process Ticket #{context.TicketID}. Forwarding context...");
            NextHandler.HandleRequest(ticket, context);
        }
    }

    // =========================================================================
    // 4. CONCRETE IMPLEMENTATIONS
    // =========================================================================
    
    // Tier 1 Support: Process low severity issues for Standard consumers
    public class Tier1Support : SupportHandler
    {
        protected override bool CanHandle(SupportTicket ticket, ContextData context)
        {
            if (ticket.Severity == 1 && context.UserType != "VIP")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void Execute(SupportTicket ticket, ContextData context)
        {
            Console.WriteLine($"[RESOLVED] Tier 1 completed Ticket #{context.TicketID} ('{ticket.Description}') for client IP: {context.IPAddress}.");
        }
    }

    // Tier 2 Support: Consumes mid-tier operational requests
    public class Tier2Support : SupportHandler
    {
        protected override bool CanHandle(SupportTicket ticket, ContextData context)
        {
            if (ticket.Severity == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void Execute(SupportTicket ticket, ContextData context)
        {
            Console.WriteLine($"[RESOLVED] Tier 2 executed advanced repairs on Ticket #{context.TicketID} ('{ticket.Description}').");
        }
    }

    // Manager Support: Responds to hyper-critical payloads or VIP exemptions
    public class ManagerSupport : SupportHandler
    {
        protected override bool CanHandle(SupportTicket ticket, ContextData context)
        {
            if (ticket.Severity == 3 || context.UserType == "VIP")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void Execute(SupportTicket ticket, ContextData context)
        {
            Console.WriteLine($"[RESOLVED] Manager priority bypass triggered for Ticket #{context.TicketID} ('{ticket.Description}'). Account Status: {context.UserType}.");
        }
    }

    // =========================================================================
    // 5. CLIENT APPLICATION BOOTSTRAPPER
    // =========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize structural handler tiers
            SupportHandler tier1 = new Tier1Support();
            SupportHandler tier2 = new Tier2Support();
            SupportHandler manager = new ManagerSupport();

            // Establish the structural pipeline sequence
            tier1.SetNext(tier2).SetNext(manager);

            // Mock Case A: Standard User Tier 1 Ticket
            SupportTicket ticketA = new SupportTicket("Reset Windows password", 1);
            ContextData contextA = new ContextData(101, "Standard", "192.168.1.50");

            // Mock Case B: Low-Severity Ticket sent by a VIP (Must skip straight to Manager)
            SupportTicket ticketB = new SupportTicket("Need a new corporate mouse replacement", 1);
            ContextData contextB = new ContextData(102, "VIP", "10.0.0.12");

            // Execute workflows
            Console.WriteLine("--- Executing Transaction Pipeline A ---");
            tier1.HandleRequest(ticketA, contextA);

            Console.WriteLine("\n--- Executing Transaction Pipeline B ---");
            tier1.HandleRequest(ticketB, contextB);
        }
    }
}