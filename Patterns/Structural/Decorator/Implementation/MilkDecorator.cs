using Patterns.Structural.Decorator.Interface;
using System;

namespace Patterns.Structural.Decorator.Implementation
{
    internal class MilkDecorator : BeverageDecorator
    {
        public MilkDecorator(IBeverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Milk";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.50; // Adding milk price
        }
    }
}
