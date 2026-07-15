using System;
using Patterns.Structural.Facade.implementation.Data;
using Patterns.Structural.Facade.Interface.Service;

namespace Patterns.Structural.Facade.implementation.Subsystem
{
    internal class AccountService : IAccountService
    {
        public AccountService() { }

        public bool CreateAccount(CustomerData customer, out int accountId)
        {
            // Simulate account creation
            Console.WriteLine($"Creating account for customer {customer.Name}...");
            // For demonstration purposes, let's assume the account ID is generated as a random number
            Random random = new Random();
            accountId = random.Next(1000, 9999);
            Console.WriteLine($"Account created with ID: {accountId}");
            return true;
        }
    }
}
