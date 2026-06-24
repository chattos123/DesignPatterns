using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural.Composite.Interfaces
{
    internal interface IComposite: IComponent
    {
        void Add(IComponent c); 
        void Remove(IComponent c);
    }
}
