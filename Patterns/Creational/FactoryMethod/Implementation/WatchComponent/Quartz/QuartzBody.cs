using Patterns.Creational.FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.FactoryMethod.Implementation.WatchComponent.Quartz
{
    internal class QuartzBody : IWatchComponent
    {
        public string GetComponentType()
        {
            return "Quartz Body";
        }

        public int GetComponentPrice()
        {
            return 1000;
        }
    }
}
