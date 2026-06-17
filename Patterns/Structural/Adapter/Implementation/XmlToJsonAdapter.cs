using Patterns.Structural.Adapter.Interface;
using System;


namespace Patterns.Structural.Adapter.Implementation
{
    internal class XmlToJsonAdapter: ICurrentParser
    {
        private readonly LegacyXmlParser _legacyXmlParser;
        public XmlToJsonAdapter(LegacyXmlParser legacyXmlParser)
        {
            _legacyXmlParser = legacyXmlParser;
        }
        public void ParseJson(string jsonAndMetadata)
        {
            // Convert JSON to XML format (simplified for demonstration)
            Console.WriteLine("Adapter: Translating JSON request to XML payload...");
            string xmlData = ConvertJsonToXml(jsonAndMetadata);
            bool isStrictValidation = true; // Example flag for strict validation
            // Use the legacy XML parser to handle the converted data
            _legacyXmlParser.ParseOldXmlFormat(xmlData, isStrictValidation);
        }
        private string ConvertJsonToXml(string json)
        {
            // Placeholder for actual conversion logic
            return $"<root><data>{json}</data></root>";
        }
    }
    
}
