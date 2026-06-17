using System;
using Patterns.Structural.Adapter.Interface;


namespace Patterns.Structural.Adapter.Implementation
{
    // 2. THE EXISTING CONCRETE JSON PARSER
    // This is your system's native, modern way of handling JSON.
    internal class ModernJsonParser: ICurrentParser
    {
        public void ParseJson(string jsonAndMetadata)
        {
            // Implementation for parsing JSON
            Console.WriteLine("ModernJsonParser: Directly parsing JSON data using System.Text.Json...");
            Console.WriteLine($"[Native JSON Output]: Processing lookups for {jsonAndMetadata}");
        }
    }
}
