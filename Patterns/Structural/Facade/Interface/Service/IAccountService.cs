using System;
using Patterns.Structural.Facade.implementation.Data;

namespace Patterns.Structural.Facade.Interface.Service
{
    internal interface IAccountService
    {
        bool CreateAccount(CustomerData customer, out int accountId);
    }
}
