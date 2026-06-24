using System;
using Patterns.Structural.Decorator.Interface;


namespace Patterns.Structural.Decorator.Implementation
{
    internal class BeverageDecorator: IBeverage
    {
        protected IBeverage _beverage;
        public BeverageDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }
        public virtual string GetDescription()
        {
            return _beverage.GetDescription();
        }
        public virtual double GetCost()
        {
            return _beverage.GetCost();
        }
    }
}
