using System;
using System.Diagnostics;
using Patterns.Simulator.Interface;
using Patterns.Structural.Decorator.Interface;
using Patterns.Structural.Decorator.Implementation;

namespace Patterns.Simulator.Implementation
{
    internal class DecoratorSimulator: ISimulator
    {
        public void Simulate()
        {
            // 1. Order a plain coffee
            IBeverage coffee = new PlainCoffee();
            Console.WriteLine($"{coffee.GetDescription()} -> ${coffee.GetCost():F2}");
            // Output: Plain Coffee -> $2.00

            // 2. Add Milk to it
            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} -> ${coffee.GetCost():F2}");
            // Output: Plain Coffee, Milk -> $2.50

            // 3. Add Caramel to the same coffee
            coffee = new CaramelDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} -> ${coffee.GetCost():F2}");
            // Output: Plain Coffee, Milk, Caramel -> $3.25
        }
    }
}
