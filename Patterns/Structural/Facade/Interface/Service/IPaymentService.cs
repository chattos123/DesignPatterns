using System;
using Patterns.Structural.Facade.implementation.Data;

namespace Patterns.Structural.Facade.Interface.Service
{
    internal interface IPaymentService
    {
        bool MakeDeposit(CustomerData customer, double amount, out int transactionId);
        bool MakeWithdrawal(CustomerData customer, double amount, out int transactionId);

    }
}
