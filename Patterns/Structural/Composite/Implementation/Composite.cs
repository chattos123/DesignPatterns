using System;
using System.Collections.Generic;
using Patterns.Structural.Composite.Interface;

namespace Patterns.Structural.Composite.Implementation
{
    internal class Composite : IComposite
    {
        private readonly string name;
        private readonly List<IComponent> children = new List<IComponent>();

        // Cache for expensive operations
        private string? cachedResult;
        private bool isDirty = true; // flag to invalidate cache

        public Composite(string name) => this.name = name;
        // non optimized version
        //public void Add(IComponent c) => children.Add(c);
        //optimized version with caching
        public void Add(IComponent c)
        {
            children.Add(c);
            isDirty = true; // mark cache as dirty
        }

        // non optimized version
        //public void Remove(IComponent c) => children.Remove(c);
        // optimized version with caching
        public void Remove(IComponent c)
        {
            children.Remove(c);
            isDirty = true; // mark cache as dirty
        }

        public void Operation()
        {
            // non optimized version
            //Console.WriteLine($"Composite {name} operation");

            //foreach (IComponent child in children)
            //{
            //    child.Operation();
            //}

            //optimized version with caching

            // Lazy evaluation: recompute only if children changed
            if (isDirty)
            {
                Console.WriteLine($"Composite {name} recalculating...");
                cachedResult = $"Composite {name} has {children.Count} children";
                isDirty = false;
            }

            Console.WriteLine(cachedResult);

            // Iterative traversal instead of deep recursion
            var stack = new Stack<IComponent>(children);

            while (stack.Count > 0)
            {
                var child = stack.Pop();
                child.Operation();

                if (child is IComposite compositeChild)
                {
                    foreach (var grandChild in compositeChild.GetChildren())
                        stack.Push(grandChild);
                }
            }
        }

        public IReadOnlyList<IComponent> GetChildren() => children.AsReadOnly();
    }
}
