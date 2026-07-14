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
            Console.WriteLine("\n\n[System] Now simulating delegate-based Observer pattern behavior");
            SimulateDelegateBasedObserver();
            Console.WriteLine("\n\n[System] Now simulating standard .NET Observer pattern behavior");
            // TBD: need to fix a bug in the standard implementation before enabling this simulation
            // SimulateStandardBehaviour();
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

        public void SimulateDelegateBasedObserver()
        {
            var newsAgency = new NewsAgency();
            newsAgency.ExamineInvokationList();
            var subscriber1 = new Subscriber("Subscriber 1");
            var subscriber2 = new Subscriber("Subscriber 2");
            // Subscribe to the event
            newsAgency.NewsPublished += subscriber1.OnNewsPublished;
            newsAgency.ExamineInvokationList();
            newsAgency.NewsPublished += subscriber2.OnNewsPublished;
            newsAgency.ExamineInvokationList();
            // Publish news
            newsAgency.AddNews("Breaking News: Observer Pattern in Action via Events!");
            newsAgency.AddNews("Update: Delegates make life easier!");
            // Unsubscribe one of the subscribers
            newsAgency.NewsPublished -= subscriber1.OnNewsPublished;
            // Publish more news
            newsAgency.AddNews("Final Update: Observer Pattern Demo Complete!");
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
