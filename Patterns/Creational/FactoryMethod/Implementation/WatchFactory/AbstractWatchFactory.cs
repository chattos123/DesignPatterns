using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Creational.FactoryMethod.Interfaces;

namespace Patterns.Creational.FactoryMethod.Implementation.WatchFactory
{
    internal abstract class AbstractWatchFactory : IWatchFactory
    {
        protected List<IWatchComponent> _components = new List<IWatchComponent>();
        public abstract void CreateWatch();
       
        public void DisplayWatch()
        {
            foreach (var component in _components)
            {
                Console.WriteLine($"Component: {component.GetComponentType()}");
                Console.WriteLine($"Price: {component.GetComponentPrice()}");    
            }
        }
    }
}
