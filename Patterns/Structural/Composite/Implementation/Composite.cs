using System;
using System.Collections.Generic;
using Patterns.Structural.Composite.Interfaces;

namespace Patterns.Structural.Composite.Implementation
{
    internal class Composite : IComposite
    {
        private readonly string name;
        private readonly List<IComponent> children = new List<IComponent>();
        public Composite(string name) => this.name = name;
        public void Add(IComponent c) => children.Add(c);
        public void Remove(IComponent c) => children.Remove(c);
        public void Operation()
        {
            Console.WriteLine($"Composite {name} operation");

            foreach (IComponent child in children)
            {
                child.Operation();
            }
        }
    }
}
