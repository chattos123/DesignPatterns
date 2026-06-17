using Patterns.Creational.Builder.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Builder.Implementation
{
    internal class DocumentProduct : IDocument
    {
        List<string> _content = new List<string>();
        public void AddContent(string content)
        {
            _content.Add(content);
        }

        public void PrintDocument()
        {
            foreach (var line in _content)
            {
                Console.WriteLine(line);
            }
        }
    }
}
