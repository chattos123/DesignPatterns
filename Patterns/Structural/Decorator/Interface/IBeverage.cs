using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural.Decorator.Interface
{
    internal interface IBeverage
    {
        string GetDescription();
        double GetCost();
    }
}
