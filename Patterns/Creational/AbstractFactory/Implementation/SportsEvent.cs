using Patterns.Creational.AbstractFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.AbstractFactory.Implementation
{
    public class SportsEvent
    {
        IAttacker? attacker;
        IDefender? defender;
        public SportsEvent(ISportsFactory factory) 
        {
            attacker = factory.CreateAttacker();
            defender = factory.CreateDefender();
        }

        public void ExecuteEvent()
        {
            Console.WriteLine("The sports event has started!");
            attacker?.Attack(defender!);
        }

    }
}
