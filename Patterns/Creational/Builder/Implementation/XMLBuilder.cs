using Patterns.Creational.Builder.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Builder.Implementation
{
    internal class XMLBuilder : IDocumentBuilder
    {
        public XMLBuilder(IDocument document)
        {
            Document = document ?? throw new ArgumentNullException(nameof(document));
        }

        public IDocument Document { get; init; }

        public void BuildBody()
        {
            Console.WriteLine("Building XML body...");
            Document.AddContent("<body>XML Body Content</body>");
        }

        public void BuildFooter()
        {
            Console.WriteLine("Building XML footer...");
            Document.AddContent("<footer>XML Footer Content</footer>");
        }

        public void BuildHeader()
        {
            Console.WriteLine("Building XML header...");    
            Document.AddContent("<header>XML Header Content</header>");
        }
    }
}
