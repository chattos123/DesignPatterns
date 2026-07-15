using System;
using Patterns.Structural.Facade.Interface.Facade;
using Patterns.Structural.Facade.Interface.Service;
using Patterns.Structural.Facade.implementation.Subsystem;
using Patterns.Structural.Facade.implementation.Facade;

namespace Patterns.Structural.Facade.implementation.FacadeBuilder
{
    internal class BankFacadeBuilder
    {
        public static IBankFacade BuildBankFacade()
        {
            // Create service instances
            IAccountService accountService = new AccountService();
            IPaymentService transactionService = new PaymentService();  
            ICreditService creditService = new CreditService();
            ILoanService loanService = new LoanService();

            // Create and return the facade
            return new BankFacade(accountService, creditService, loanService, transactionService);
        }
    }
}
