using System;
using Patterns.Structural.Facade.implementation.Data;
using Patterns.Structural.Facade.Interface.Facade;
using Patterns.Structural.Facade.Interface.Service;


namespace Patterns.Structural.Facade.implementation.Facade
{
    internal class BankFacade : IBankFacade
    {
        private readonly IAccountService _accountService;
        private readonly ICreditService _creditService;
        private readonly ILoanService _loanService;
        private readonly IPaymentService _paymentService;

        public BankFacade(IAccountService accountService, ICreditService creditService, ILoanService loanService, IPaymentService paymentService)
        {
            _accountService = accountService;
            _creditService = creditService;
            _loanService = loanService;
            _paymentService = paymentService;
        }

        public bool ApplyLoan(CustomerData customer, double amount, out int loanId)
        {
            //simulate the loan application process
            if (_loanService == null || _creditService == null)
            {
                loanId = -1;
                return false;
            }
            else
            {
                // Check credit score
                if (_creditService.CheckCreditScore(customer))
                {
                    // Apply for loan
                    if (_loanService.ApplyLoan(customer, amount, out loanId))
                    {
                        return true;
                    }
                    else
                    {
                        loanId = -1;
                        return false;
                    }
                }
                else
                {
                    loanId = -1;
                    return false;
                }
            }

         }

        public bool MakeDeposit(CustomerData customer, double amount, out int transactionId)
        {
            //simulate the deposit process
            if (_accountService == null || _paymentService == null)
            {
                transactionId = -1;
                return false;
            }
            else
            {
                // Make deposit
                if (_paymentService.MakeDeposit(customer, amount, out transactionId))
                {
                    return true;
                }
                else
                {
                    transactionId = -1;
                    return false;
                }
            }
        }

        public bool MakeWithdrawal(CustomerData customer, double amount, out int transactionId)
        {
            //simulate the withdrawal process       
            if (_accountService == null || _paymentService == null)
                {
                    transactionId = -1;
                    return false;
                }
                else
                {
                    // Make withdrawal
                    if (_paymentService.MakeWithdrawal(customer, amount, out transactionId))
                    {
                        return true;
                    }
                    else
                    {
                        transactionId = -1;
                        return false;
                    }
            }
        }

        public bool OpenAccount(CustomerData customer, out int accountId)
        {
            //simulate the account opening process
            if (_accountService == null)
            {
                accountId = -1;
                return false;   
            }
            else
            {
                // Open account
                return _accountService.CreateAccount(customer, out accountId);
            }
        }
    }
}
