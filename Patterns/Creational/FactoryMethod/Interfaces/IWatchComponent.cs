using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.FactoryMethod.Interfaces
{
    public interface IWatchComponent
    {
        string GetComponentType();
        int GetComponentPrice();
    }
}
