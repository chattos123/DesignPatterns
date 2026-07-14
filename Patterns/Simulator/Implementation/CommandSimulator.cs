using Patterns.Behavioral.Command.Implementation.Commands;
using Patterns.Behavioral.Command.Implementation.Invoker;
using Patterns.Behavioral.Command.Implementation.Recievers;
using Patterns.Behavioral.Command.Interface;
using Patterns.Simulator.Interface;
using System;

namespace Patterns.Simulator.Implementation
{
    internal class CommandSimulator : ISimulator
    {
        public void Simulate()
        {
            // create a text editor as reciever
            ITextEditorReceiver myEditor = new TextEditor();
            // create a history manager as invoker
            HistoryManager history = new HistoryManager();
            // create a command to insert "Hello "
            ICommand insertHelloCommand = new InsertTextCommand(myEditor, "Hello ");

            // 1. Type "Hello "
            history.ExecuteCommand(insertHelloCommand);
            myEditor.Print(); // Output: "Hello "

            // 2. Type "World!"
            ICommand insertWorldCommand = new InsertTextCommand(myEditor, "World!");
            history.ExecuteCommand(insertWorldCommand);
            myEditor.Print(); // Output: "Hello World!"

            Console.WriteLine("\n--- Performing Undo ---");
            // 3. Undo "World!"
            history.Undo();
            myEditor.Print(); // Output: "Hello "

            // 4. Undo "Hello "
            history.Undo();
            myEditor.Print(); // Output: ""

            Console.WriteLine("\n--- Performing Redo ---");
            // 5. Redo "Hello "
            history.Redo();
            myEditor.Print(); // Output: "Hello "

            // 6. Redo "World!"
            history.Redo();
            myEditor.Print(); // Output: "Hello World!" 
        }
    }
}
