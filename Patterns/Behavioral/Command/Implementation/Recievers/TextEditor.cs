using System;
using Patterns.Behavioral.Command.Interface;

namespace Patterns.Behavioral.Command.Implementation.Recievers
{
    internal class TextEditor: ITextEditorReceiver
    {
        // contains the editor content
        private string _content;

        // constructor to initialize default values
        public TextEditor()
        {
            _content = "";
        }

        // Explicit get and set blocks
        public string Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }

        // standard block bodies and string formatting
        public void Print()
        {
            Console.WriteLine("Current Text: \"{0}\"", _content);
        }
    }
}
