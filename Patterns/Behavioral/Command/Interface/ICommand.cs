using System;

namespace Patterns.Behavioral.Command.Interface
{
    internal interface ICommand
    {
        void Execute();
        void Undo();
    }
}
