using Patterns.Behavioral.Observer.EventData;
using Patterns.Behavioral.Observer.Implementation;
using Patterns.Behavioral.Observer.Implementation.Observer;
using Patterns.Behavioral.Observer.Implementation.Subject;
using Patterns.Behavioral.Observer.Interface;
using Patterns.Simulator.Interface;
using System;
using System.Collections.Generic;

namespace Patterns.Simulator.Implementation
{
    internal class ObserverSimulator : ISimulator
    {
        public void Simulate()
        {
            Console.WriteLine("[System] Simulating classic Observer pattern behavior"); 
            SimulateClassicBehaviour();
            Console.WriteLine("\n\n[System] Now simulating standard .NET Observer pattern behavior");
            SimulateStandardBehaviour();
        }

        private void SimulateClassicBehaviour()
        {
            // Create Subject
            var alertGenerator = new CentralAlertGenerator();

            // Create Observers
            var emailService = new EmailAlertHandler();
            var dashboardService = new DashboardAlertHandler();

            // Subscribe observers to the subject
            alertGenerator.RegisterObserver(emailService);
            alertGenerator.RegisterObserver(dashboardService);

            // Trigger real-time events
            alertGenerator.NotifyObservers("CPU utilization exceeded 95%!", "Critical");
            alertGenerator.NotifyObservers("Database backup completed with minor warnings.", "Warning");

            // Unsubscribe an observer and fire another alert
            alertGenerator.RemoveObserver(emailService);
            alertGenerator.NotifyObservers("API Gateway latency is high.", "Major");
        }


        private void SimulateStandardBehaviour()
        {
            var provider = new AlertProvider();

            var emailClient = new StandardEmailAlertObserver(provider);
            var dashboardClient = new StandardDashboardAlertObserver(provider);

            // Subscribe using the native pattern (returns an IDisposable)
            IDisposable emailSubscription = provider.Subscribe(emailClient);
            IDisposable dashboardSubscription = provider.Subscribe(dashboardClient);

            // Fire an incident
            provider.GenerateAlert("SQL Database deadlock detected!", "Critical");

            // Unsubscribe the email client via standard .NET Diposal pattern
            emailSubscription.Dispose();
            Console.WriteLine("\n[System] Email service unsubscribed cleanly via Dispose.");

            // Fire another incident (Only dashboard reacts and clears)
            provider.GenerateAlert("Memory consumption exceeding 90%", "Warning");

            // Teardown the system stream completely
            provider.CloseStream();
        }
    }
}
