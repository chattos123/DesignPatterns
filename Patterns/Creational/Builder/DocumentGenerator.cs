using Patterns.Creational.Builder.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Builder
{
    public class DocumentGenerator
    {
        public void GenerateDocument(IDocumentBuilder builder)
        {
            if (builder != null)
            {
                builder.BuildHeader();
                builder.BuildBody();
                builder.BuildFooter();
            }
            else
            {
                throw new ArgumentNullException(nameof(builder), "Document builder cannot be null.");
            }
        }
    }
}
