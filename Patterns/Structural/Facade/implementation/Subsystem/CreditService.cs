using System;
using Patterns.Structural.Facade.implementation.Data;
using Patterns.Structural.Facade.Interface.Service;

namespace Patterns.Structural.Facade.implementation.Subsystem
{
    internal class CreditService: ICreditService
    {
        public CreditService() { }

        public bool CheckCreditScore(CustomerData customer)
        {
            // Simulate checking credit for a customer
            Console.WriteLine($"Checking credit for customer {customer.Name}...");
            // For demonstration purposes, let's assume all customers have good credit
            return true;
        }
    }
}
