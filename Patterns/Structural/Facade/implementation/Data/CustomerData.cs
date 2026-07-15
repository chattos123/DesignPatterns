using System;

namespace Patterns.Structural.Facade.implementation.Data
{
    internal class CustomerData
    {
        public string Name { get; }
        public int CreditScore { get; }

        public int AccountNumber { get; set; } // Optional property for account number

        public CustomerData(string name, int creditScore)
        {
            Name = name;
            CreditScore = creditScore;
        }
    }
}
