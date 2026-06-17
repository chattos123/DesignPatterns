using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Builder.Interface
{
    public interface IDocumentBuilder
    {
       IDocument Document { get; init; }

        void BuildHeader();
        void BuildBody();
        void BuildFooter();
    }
}
