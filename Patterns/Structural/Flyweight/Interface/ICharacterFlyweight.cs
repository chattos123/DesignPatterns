using System;

/// <summary>
/// Flyweight Pattern Considerations:
/// 1. The Flyweight pattern is primarily an optimization technique.
/// 2. Apply it only when your program faces high RAM usage due to
///    a massive number of similar objects in memory simultaneously.
/// 3. Confirm that this memory issue cannot be solved in any other
///    meaningful or simpler way before introducing Flyweight.
/// </summary>


namespace Patterns.Structural.Flyweight.Interface
{
    // The Flyweight Interface
    internal interface ICharacterFlyweight
    {
        // Extrinsic state (position) is passed in as a parameter
        void Render(int position);
    }
}
