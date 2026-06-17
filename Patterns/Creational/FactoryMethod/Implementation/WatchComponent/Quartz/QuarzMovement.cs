using Patterns.Creational.FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.FactoryMethod.Implementation.WatchComponent.Quartz
{
    internal class QuarzMovement : IWatchComponent
    {
        public string GetComponentType()
        {
            return "Quartz Movement";
        }

        public int GetComponentPrice()
        {
            return 200;
        }
    }
}
