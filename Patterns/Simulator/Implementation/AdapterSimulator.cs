using Patterns.Simulator.Interface;
using Patterns.Structural.Adapter.Implementation;
using Patterns.Structural.Adapter.Interface;
using System;

namespace Patterns.Simulator.Implementation
{
    internal class AdapterSimulator : ISimulator
    {
        public void Simulate()
        {
            string mockJson = "{ 'user': 'Chatterjee', 'status': 'Active' }";

            // Both parsers are treated exactly the same thanks to the interface polymorphism
            ICurrentParser nativeParser = new ModernJsonParser();
            ICurrentParser adaptedLegacyParser = new XmlToJsonAdapter(new LegacyXmlParser());

            Console.WriteLine("=== Scenario 1: Using the Existing Modern JSON Parser ===");
            ExecuteParsingPipeline(nativeParser, mockJson);

            Console.WriteLine("\n=== Scenario 2: Using the Legacy XML Parser via the Adapter ===");
            ExecuteParsingPipeline(adaptedLegacyParser, mockJson);
        }

        private void ExecuteParsingPipeline(ICurrentParser parser, string json)
        {
            parser.ParseJson(json);
        }
    }
}
