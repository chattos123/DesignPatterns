using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural.Adapter.Implementation
{
    // 3. THE ADAPTEE (Legacy Component)
    internal class LegacyXmlParser
    {
        public void ParseOldXmlFormat(string xmlData, bool IsStrictValidation)
        {
            Console.WriteLine("LegacyXmlParser: Converting and parsing XML data safely...");
            Console.WriteLine($"[XML Data]: {xmlData}");
            Console.WriteLine($"[Strict Mode]: {IsStrictValidation}");
        }
    }
}
