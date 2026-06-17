using Patterns.Creational.AbstractFactory.Implementation.Football;
using Patterns.Creational.AbstractFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.AbstractFactory.Implementation.Factories
{
    internal class Football: ISportsFactory
    {
        public IAttacker CreateAttacker()
        {
            return new Striker();
        }
        public IDefender CreateDefender()
        {
            return new GoalKeeper();
        }
    }
}
