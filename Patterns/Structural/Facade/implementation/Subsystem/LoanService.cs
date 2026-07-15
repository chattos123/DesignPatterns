using System;
using Patterns.Structural.Facade.implementation.Data;
using Patterns.Structural.Facade.Interface.Service;

namespace Patterns.Structural.Facade.implementation.Subsystem
{
    internal class LoanService: ILoanService
    {
        public LoanService() { }

       

        public bool ApplyLoan(CustomerData customer, double amount, out int loanId)
        {
            // Simulate loan application
            Console.WriteLine($"Applying for a loan of {amount} for customer {customer.Name}...");
            // For demonstration purposes, let's assume the loan ID is generated as a random number
            Random random = new Random();
            loanId = random.Next(1000, 9999);
            Console.WriteLine($"Loan approved with ID: {loanId}");
            return true;
        }
    }
}