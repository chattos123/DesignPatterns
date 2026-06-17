using Patterns.Creational.AbstractFactory.Implementation.Cricket;
using Patterns.Creational.AbstractFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.AbstractFactory.Implementation.Factories
{
    internal class Cricket: ISportsFactory
    {
        public IAttacker CreateAttacker()
        {
            return new Bowler();
        }
        public IDefender CreateDefender()
        {
            return new Batter();
        }
    }
}
