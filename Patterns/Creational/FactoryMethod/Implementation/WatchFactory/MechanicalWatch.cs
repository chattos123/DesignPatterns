using Patterns.Creational.FactoryMethod.Implementation.WatchComponent.Mechanical;
using Patterns.Creational.FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.FactoryMethod.Implementation.WatchFactory
{
    internal class MechanicalWatch : AbstractWatchFactory
    {
        
        public override void CreateWatch()
        {
            _components.Add(new MechMovement());
            _components.Add(new MechBody());
        }

        
    }
}
