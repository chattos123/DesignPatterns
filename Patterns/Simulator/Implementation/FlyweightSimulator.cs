using System;
using Patterns.Simulator.Interface;
using Patterns.Structural.Flyweight.implementation.Context;


namespace Patterns.Simulator.Implementation
{
    internal class FlyweightSimulator : ISimulator
    {
        public void Simulate()
        {
            Document doc = new Document();

            // 1. Type "Hello" in Arial 12pt Regular
            // Notice that 'l' appears twice. The factory will reuse the object for the second 'l'.
            string text1 = "Hello";
            foreach (char c in text1)
            {
                doc.InsertCharacter(c, "Arial", 12, false);
            }

            // 2. Type " World!" in Times New Roman 14pt Bold
            // This switches style configurations, generating a new set of flyweights.
            string text2 = " World!";
            foreach (char c in text2)
            {
                doc.InsertCharacter(c, "Times New Roman", 14, true);
            }

            string text3 = " She sells sea shells in the sea shore!";
            foreach (char c in text3)
            {
                doc.InsertCharacter(c, "Times New Roman", 14, true);
            }

            // 3. Render the document stream
            // The document loops through its list and passes the character indices (extrinsic state)
            // directly into the flyweights dynamically.
            Console.WriteLine("--- Document Render Output ---");
            doc.RenderDocument();

            // 4. Verification of Memory Allocation
            Console.WriteLine("\n--- Memory Performance Stats ---");
            Console.WriteLine($"Total characters stored in document: {text1.Length + text2.Length + text3.Length}");

            // Expected unique objects: 
            // 'H', 'e', 'l', 'o' (Arial 12) = 4 objects ('l' is shared!)
            // ' ', 'W', 'o', 'r', 'l', 'd', '!' (Times 14 Bold) = 7 objects
            // Total should be 11 unique ConcreteFlyweight objects in RAM instead of 12 individual allocations.

            // Print out the RAM calculations
            RunMemoryTest();
        }

        private void RunMemoryTest()
        {
            Document doc = new Document();
            Random rand = new Random();

            Console.WriteLine("Generating a massive document stream of 50,000 characters...");

            // Simulating typing 50,000 random alphabet characters 
            // across 3 structural font styles
            for (int i = 0; i < 50000; i++)
            {
                char randomChar = (char)rand.Next(65, 91); // A-Z

                if (i < 40000)
                {
                    // Body text style
                    doc.InsertCharacter(randomChar, "Calibri", 11, false);
                }
                else if (i < 48000)
                {
                    // Callout block style
                    doc.InsertCharacter(randomChar, "Courier New", 10, false);
                }
                else
                {
                    // Bold Header style
                    doc.InsertCharacter(randomChar, "Arial", 16, true);
                }
            }

            // Print out the RAM calculations
            doc.PrintRamSavingsReport();
        }
    }
}
