using System;
using Patterns.Structural.Facade.implementation.Data;


namespace Patterns.Structural.Facade.Interface.Facade
{
    internal interface IBankFacade
    {
        bool OpenAccount(CustomerData customer, out int accountId);
        bool ApplyLoan(CustomerData customer, double amount, out int loanId);

        bool MakeDeposit(CustomerData customer, double amount, out int transactionId);

        bool MakeWithdrawal(CustomerData customer, double amount, out int transactionId);

    }
}
