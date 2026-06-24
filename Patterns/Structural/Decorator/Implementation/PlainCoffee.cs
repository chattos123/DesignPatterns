using System;
using Patterns.Structural.Decorator.Interface;  

namespace Patterns.Structural.Decorator.Implementation
{
    internal class PlainCoffee: IBeverage
    {
        public string GetDescription()
        {
            return "Plain Coffee";
        }

        public double GetCost()
        {
            return 2.00; // Base price
        }
    }
}
