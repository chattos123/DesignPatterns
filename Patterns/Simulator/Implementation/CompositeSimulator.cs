using System;
using System.Diagnostics;
using Patterns.Simulator.Interface;
using Patterns.Structural.Composite.Interfaces;
using Patterns.Structural.Composite.Implementation;

namespace Patterns.Simulator.Implementation
{
    internal class CompositeSimulator: ISimulator   
    {
        public void Simulate()
        {
            IComposite root = new Composite("Root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            IComposite subTree1 = new Composite("SubTree1");
            subTree1.Add(new Leaf("Leaf X"));
            subTree1.Add(new Leaf("Leaf Y"));
            subTree1.Add(new Leaf("Leaf Z"));

            root.Add(subTree1);

            IComposite subTree2 = new Composite("SubTree2");
            subTree2.Add(new Leaf("Leaf X"));
            subTree2.Add(new Leaf("Leaf Y"));
            subTree2.Add(new Leaf("Leaf Z"));

            root.Add(subTree2);

            //root.Operation();

            // First call: recalculates
            Stopwatch sw = Stopwatch.StartNew();
            root.Operation();
            sw.Stop();
            Console.WriteLine($"\nOperation completed in {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("\nSecond call (cached):");
            // Second call: uses cached result, avoids recomputation
            sw.Restart();
            root.Operation();
            sw.Stop();
            Console.WriteLine($"\nOperation completed in {sw.ElapsedMilliseconds} ms");

            Console.WriteLine("\nChildren of Root:");
            foreach (var child in root.GetChildren())
                child.Operation();
        }
    }
}
