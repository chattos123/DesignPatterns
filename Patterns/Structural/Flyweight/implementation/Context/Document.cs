using Patterns.Structural.Flyweight.implementation.Factory;
using Patterns.Structural.Flyweight.Interface;
using System;
using System.Collections.Generic;

namespace Patterns.Structural.Flyweight.implementation.Context
{
    /// <summary>
    /// Context class <step 3 and 4> that contains the extrinsic state, 
    /// unique across all original objects.
    /// When a context is paired with one of the flyweight objects, 
    /// it represents the full state of the original object.
    /// </summary>
    internal class Document
    {
        // List holding references to the Flyweight interfaces
        private readonly List<ICharacterFlyweight> _characters = new List<ICharacterFlyweight>();
        private readonly CharacterFactory _factory = new CharacterFactory();

        public void InsertCharacter(char symbol, string fontName, int fontSize, bool isBold)
        {
            ICharacterFlyweight sharedFormat = _factory.GetCharacterFormat(symbol, fontName, fontSize, isBold);
            _characters.Add(sharedFormat);
        }

        public void RenderDocument()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                // Passing the loop variable 'i' (extrinsic state) to the flyweight
                _characters[i].Render(i);
            }
        }

        public int GetCharacterCount() => _characters.Count;

        // Calculates estimated RAM utilization in bytes
        public void PrintRamSavingsReport()
        {
            int totalChars = _characters.Count;
            int uniqueObjects = _factory.GetUniquePoolCount();

            // ESTIMATING OBJECT SIZE:
            // ConcreteFlyweight object fields: char (2B) + string reference (8B) + int (4B) + bool (1B) = 15 bytes.
            // Add 64-bit object header overhead (24 bytes) = 39 bytes.
            // Aligned to 8-byte boundary = 40 bytes per heavy format object.
            int sizeOfConcreteFlyweight = 40;

            // Pointer size on a 64-bit system = 8 bytes
            int sizeOfPointer = 8;

            // Scenario 1: WITHOUT FLYWEIGHT
            // Every character point has a standalone 40-byte allocation + an 8-byte pointer in the list
            long bytesWithoutFlyweight = (long)totalChars * (sizeOfConcreteFlyweight + sizeOfPointer);

            // Scenario 2: WITH FLYWEIGHT
            // Only 'uniqueObjects' quantity of 40-byte allocations exist. 
            // The document list holds 'totalChars' number of 8-byte pointers pointing to them.
            long bytesWithFlyweight = (uniqueObjects * sizeOfConcreteFlyweight) + (totalChars * sizeOfPointer);

            long bytesSaved = bytesWithoutFlyweight - bytesWithFlyweight;

            Console.WriteLine("\n================ RAM SAVINGS REPORT ================");
            Console.WriteLine($"Total Characters in Document : {totalChars:N0}");
            Console.WriteLine($"Unique Formatting Objects    : {uniqueObjects:N0}");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"RAM Cost WITHOUT Flyweight   : {bytesWithoutFlyweight:N0} bytes");
            Console.WriteLine($"RAM Cost WITH Flyweight      : {bytesWithFlyweight:N0} bytes");
            Console.WriteLine($"Total RAM Saved              : {bytesSaved:N0} bytes");

            if (bytesWithoutFlyweight > 0)
            {
                double percentSaved = ((double)bytesSaved / bytesWithoutFlyweight) * 100;
                Console.WriteLine($"Memory Reduction Efficiency  : {percentSaved:F2}%");
            }
            Console.WriteLine("====================================================");
        }
    }
}

