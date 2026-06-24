using Patterns.Structural.Decorator.Interface;
using System;

namespace Patterns.Structural.Decorator.Implementation
{
    internal class CaramelDecorator : BeverageDecorator
    {
        public CaramelDecorator(IBeverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Caramel";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.75; // Adding caramel price
        }
    }
}
