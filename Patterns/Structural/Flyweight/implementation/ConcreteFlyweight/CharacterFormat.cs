using System;
using Patterns.Structural.Flyweight.Interface;


/// <summary>
/// Concrete Flyweight:
/// - Contains the portion of the original object's state that can be shared
///   across multiple contexts (intrinsic state).
/// - The same flyweight instance can be reused in different situations.
/// - Intrinsic state: stored inside the flyweight and shared.
/// - Extrinsic state: passed into flyweight methods at runtime, unique per use.
/// </summary>


namespace Patterns.Structural.Flyweight.implementation.ConcreteFlyweight
{
    // The ConcreteFlyweight: Stores ONLY intrinsic state
    internal class CharacterFormat: ICharacterFlyweight
    {
        // Intrinsic State (Shared & Immutable)
        public char Symbol { get; private set; }
        public string FontName { get; private set; }
        public int FontSize { get; private set; }
        public bool IsBold { get; private set; }

        public CharacterFormat(char symbol, string fontName, int fontSize, bool isBold)
        {
            Symbol = symbol;
            FontName = fontName;
            FontSize = fontSize;
            IsBold = isBold;
        }

        // Implements the interface method using the passed-in extrinsic state
        public void Render(int position)
        {
            string style = IsBold ? "Bold" : "Regular";
            Console.WriteLine($"Char '{Symbol}' at index [{position}] using format: {FontName}, {FontSize}pt, {style}");
        }
    }
}
