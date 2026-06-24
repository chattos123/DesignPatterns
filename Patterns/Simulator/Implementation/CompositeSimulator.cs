using System;
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

            IComposite subTree = new Composite("SubTree");
            subTree.Add(new Leaf("Leaf X"));
            subTree.Add(new Leaf("Leaf Y"));

            root.Add(subTree);

            root.Operation();
        }
    }
}
