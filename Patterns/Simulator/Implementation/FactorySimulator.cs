using System;
using Patterns.Creational.FactoryMethod.Interfaces;
using Patterns.Creational.FactoryMethod.Implementation.WatchFactory;
using Patterns.Simulator.Interface;

namespace Patterns.Simulator.Implementation
{
    internal class FactorySimulator : ISimulator
    {
        public void Simulate()
        {
            IWatchFactory MechWatch = new MechanicalWatch();
            MechWatch.CreateWatch();
            MechWatch.DisplayWatch();
            IWatchFactory QrtzWatch = new QuartzWatch();
            QrtzWatch.CreateWatch();
            QrtzWatch.DisplayWatch();
        }
    }
}
