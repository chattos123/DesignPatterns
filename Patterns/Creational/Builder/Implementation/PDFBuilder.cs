using Patterns.Creational.Builder.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Builder.Implementation
{
    internal class PDFBuilder: IDocumentBuilder 
    {
        public PDFBuilder(IDocument document)
        {
            Document = document ?? throw new ArgumentNullException(nameof(document));
        }

        public IDocument Document { get; init; }

        public void BuildBody()
        {
            Console.WriteLine("Building PDF body...");
            Document.AddContent("<body>PDF Body Content</body>");
        }

        public void BuildFooter()
        {
            Console.WriteLine("Building PDF  footer...");
            Document.AddContent("<footer>PDF Footer Content</footer>");
        }

        public void BuildHeader()
        {
            Console.WriteLine("Building PDF header...");
            Document.AddContent("<header>PDF Header Content</header>");
        }
    }
}
