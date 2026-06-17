using Patterns.Creational.AbstractFactory.Implementation.Factories;
using Patterns.Creational.AbstractFactory.Interfaces;
using Patterns.Creational.AbstractFactory.Implementation;
using Patterns.Simulator.Interface;

namespace Patterns.Simulator.Implementation
{
    internal class AbstractFactorySimulator: ISimulator
    {
        public AbstractFactorySimulator() { }

        public void Simulate()
        {
            ISportsFactory footballFactory = new Football();
            SportsEvent footballEvent = new SportsEvent(footballFactory);
            footballEvent.ExecuteEvent();

            ISportsFactory criccketFactory = new Cricket();
            SportsEvent cricketEvent = new SportsEvent(criccketFactory);
            cricketEvent.ExecuteEvent();
        }
    }
}
