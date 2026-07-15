using System;
using Patterns.Structural.Facade.implementation.Data;

namespace Patterns.Structural.Facade.Interface.Service
{
    internal interface ILoanService
    {
        bool ApplyLoan(CustomerData customer, double amount, out int loanId);
    }
}
