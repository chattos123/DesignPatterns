using Patterns.Creational.FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.FactoryMethod.Implementation.WatchComponent.Quartz
{
    internal class Battery : IWatchComponent
    {
        public int GetComponentPrice()
        {
            return 20;
        }

        public string GetComponentType()
        {
            return "Quartz Battery";
        }
    }
}
