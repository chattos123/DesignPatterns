using Patterns.Creational.FactoryMethod.Implementation.WatchComponent.Mechanical;
using Patterns.Creational.FactoryMethod.Implementation.WatchComponent.Quartz;
using Patterns.Creational.FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.FactoryMethod.Implementation.WatchFactory
{
    internal class QuartzWatch : AbstractWatchFactory
    {
        public override void CreateWatch()
        {
            _components.Add(new QuarzMovement());
            _components.Add(new QuartzBody());
            _components.Add(new Battery());
        }

    }
}
