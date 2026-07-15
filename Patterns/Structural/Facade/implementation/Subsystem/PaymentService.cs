using System;
using Patterns.Structural.Facade.implementation.Data;
using Patterns.Structural.Facade.Interface.Service;

namespace Patterns.Structural.Facade.implementation.Subsystem
{
    internal class PaymentService: IPaymentService
    {
        public PaymentService() { }

        public bool MakeDeposit(CustomerData customer, double amount, out int transactionId)
        {
            // Simulate deposit logic
            Console.WriteLine($"Depositing {amount:C} to account {customer.AccountNumber} for customer {customer.Name}.");
            transactionId = 1; // Assign a valid transaction ID here as per your logic
            return true;
        }

        public bool MakeWithdrawal(CustomerData customer, double amount, out int transactionId)
        {
            // Simulate withdrawal logic
            Console.WriteLine($"Withdrawing {amount:C} from account {customer.AccountNumber} for customer {customer.Name}.");
            transactionId = 1; // Assign a valid transaction ID here as per your logic
            return true;    
        }
    }
}