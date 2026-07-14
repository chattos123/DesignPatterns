using System;

namespace Patterns.Behavioral.Command.Interface
{
    internal interface ITextEditorReceiver
    {
        string Content { get; set; }
        void Print();
    }
}
