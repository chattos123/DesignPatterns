using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.FactoryMethod.Interfaces
{
    public interface IWatchFactory
    {
        // Factory Method
        void CreateWatch();
        void DisplayWatch();
    }
}
