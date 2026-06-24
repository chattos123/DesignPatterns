using System;
using System.Collections.Generic;


namespace Patterns.Structural.Composite.Interface
{
    internal interface IComposite: IComponent
    {
        void Add(IComponent c); 
        void Remove(IComponent c);
        IReadOnlyList<IComponent> GetChildren();
    }
}
