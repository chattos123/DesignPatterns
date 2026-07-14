using Patterns.Behavioral.Command.Implementation.Recievers;
using Patterns.Behavioral.Command.Interface;
using System;

namespace Patterns.Behavioral.Command.Implementation.Commands
{
    internal class InsertTextCommand: ICommand
    {
        // Field to hold the receiver (text editor) and the text to insert
        private readonly ITextEditorReceiver _editor;
        private readonly string _textToInsert;

        public InsertTextCommand(ITextEditorReceiver editor, string textToInsert)
        {
            _editor = editor;
            _textToInsert = textToInsert;
        }

        public void Execute()
        {
            if(_editor == null)
            {
                throw new InvalidOperationException("Receiver (TextEditor) is not set.");
            }
            else
            {
                Console.WriteLine($"Executing InsertTextCommand: Inserting \"{_textToInsert}\"");
                _editor.Content += _textToInsert;
            }
            
        }

        public void Undo()
        {
            if (_editor == null)
            {
                throw new InvalidOperationException("Receiver (TextEditor) is not set.");
            }
            else
            {
                // Remove the exact length of the text we appended
                if (_editor.Content.EndsWith(_textToInsert))
                {
                    int startIndex = _editor.Content.Length - _textToInsert.Length;
                    _editor.Content = _editor.Content.Remove(startIndex);
                }
            }
        }
    }
}
