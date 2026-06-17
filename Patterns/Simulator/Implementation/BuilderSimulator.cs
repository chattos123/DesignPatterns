using Patterns.Creational.Builder;
using Patterns.Creational.Builder.Implementation;
using Patterns.Creational.Builder.Interface;
using Patterns.Simulator.Interface;
using System;

namespace Patterns.Simulator.Implementation
{
    internal class BuilderSimulator : ISimulator
    {
        public void Simulate()
        {
            IDocument xmldocument = new DocumentProduct();
            IDocumentBuilder xmlBuilder = new XMLBuilder(xmldocument);
            DocumentGenerator xmlGenerator = new DocumentGenerator();
            xmlGenerator.GenerateDocument(xmlBuilder);
            xmldocument.PrintDocument();


            IDocument pdfdocument = new DocumentProduct();
            IDocumentBuilder pdfBuilder = new PDFBuilder(pdfdocument);
            DocumentGenerator pdfGenerator = new DocumentGenerator();
            pdfGenerator.GenerateDocument(pdfBuilder);
            pdfdocument.PrintDocument();
        }
    }
}
