using System;
using Patterns.Structural.Facade.implementation.Data;

namespace Patterns.Structural.Facade.Interface.Service
{
    internal interface ICreditService
    {
        bool CheckCreditScore(CustomerData customer);
    }
}
