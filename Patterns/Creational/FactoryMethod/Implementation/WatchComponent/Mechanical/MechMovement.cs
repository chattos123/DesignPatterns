using Patterns.Creational.FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.FactoryMethod.Implementation.WatchComponent.Mechanical
{
    internal class MechMovement: IWatchComponent
    {
        public int GetComponentPrice()
        {
            return 10000;
        }

        public string GetComponentType()
        {
            return "Mechanical Watch Movement";
        }
    }
}
