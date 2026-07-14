using System;
using Patterns.Behavioral.Command.Interface;

namespace Patterns.Behavioral.Command.Implementation.Invoker
{
    internal class HistoryManager
    {
        private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        // Execute a new action
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);

            // Clearing the redo stack is CRITICAL when a new action is taken
            _redoStack.Clear();
        }

        // Undo the last action
        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                ICommand activeCommand = _undoStack.Pop();
                activeCommand.Undo();
                _redoStack.Push(activeCommand); // Move it to redo stack
            }
            else
            {
                Console.WriteLine("Nothing to undo!");
            }
        }

        // Redo the last undone action
        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                ICommand activeCommand = _redoStack.Pop();
                activeCommand.Execute();
                _undoStack.Push(activeCommand); // Move it back to undo stack
            }
            else
            {
                Console.WriteLine("Nothing to redo!");
            }
        }
    }
}

