using System;
using Patterns.Structural.Composite.Interface; 

namespace Patterns.Structural.Composite.Implementation
{
    internal sealed class Leaf : IComponent
    {
        private readonly string name;
        public Leaf(string name) => this.name = name;

        public void Operation() => Console.WriteLine($"Leaf {name} operation");
    }
}
