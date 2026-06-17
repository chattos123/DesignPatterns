using Patterns.Creational.AbstractFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.AbstractFactory.Implementation.Cricket
{
    internal class Bowler: IAttacker    
    {
        public Bowler() { }

        public void Attack(IDefender defender)
        {
            Console.WriteLine("{0} is attacking the defender.{1}", this.GetType().ToString(), defender.GetType().ToString());
        }
    }
}
