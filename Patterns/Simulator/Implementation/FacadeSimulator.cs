using Patterns.Structural.Facade.Interface.Facade;
using Patterns.Structural.Facade.implementation.FacadeBuilder;
using Patterns.Structural.Facade.implementation.Data;
using Patterns.Simulator.Interface;
using System;

namespace Patterns.Simulator.Implementation
{
    internal class FacadeSimulator: ISimulator
    {
        public void Simulate()
        {
            IBankFacade bankFacade = BankFacadeBuilder.BuildBankFacade();

            if(null !=  bankFacade )
            {
                //bankFacade.
                CustomerData customer = new CustomerData("John Doe", 750);
                customer.AccountNumber = -1;

                if (bankFacade.OpenAccount(customer, out int accountId))
                {
                    Console.WriteLine($"Account opened successfully for {customer.Name}. Account ID: {accountId}");
                    customer.AccountNumber = accountId;
                }
                else
                {
                    Console.WriteLine("Failed to open account.");
                }

                if(bankFacade.ApplyLoan(customer, 5000, out int loanId))
                {
                    Console.WriteLine($"Loan approved for {customer.Name}. Loan ID: {loanId}");
                }
                else
                {
                    Console.WriteLine("Failed to approve loan.");
                }

                if (bankFacade.MakeDeposit(customer, 10000, out int transctionID))
                {
                    Console.WriteLine($"Deposit successful for {customer.Name}. Transaction ID: {transctionID}");
                }
                else
                {
                    Console.WriteLine("Failed to make deposit.");
                }

                if (bankFacade.MakeWithdrawal(customer, 2000, out int withdrawalTransactionId))
                {
                    Console.WriteLine($"Withdrawal successful for {customer.Name}. Transaction ID: {withdrawalTransactionId}");
                }
                else
                {
                    Console.WriteLine("Failed to make withdrawal.");
                }
            }
        }          
    }
}
