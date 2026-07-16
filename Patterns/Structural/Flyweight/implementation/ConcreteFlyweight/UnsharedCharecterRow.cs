using System;
using Patterns.Structural.Flyweight.Interface;

namespace Patterns.Structural.Flyweight.implementation.ConcreteFlyweight
{
    // Unshared Concrete Flyweight
    /// <summary>
    /// UnsharedConcreteFlyweight:
    /// - Exists because the Flyweight interface enables sharing but does not enforce it.
    /// - Used in two main scenarios:
    ///   1. **Uniformity with Composite Pattern:**  
    ///      In hierarchical structures, leaf nodes (shared flyweights) coexist with container nodes 
    ///      (paragraphs, lines, columns) that are unique and stateful. By implementing the same interface, 
    ///      both can be treated uniformly by the client.
    ///   2. **Dynamic State Management:**  
    ///      Sometimes a group of shared flyweights must be treated as a single cohesive unit 
    ///      with its own unique, non-shareable state (e.g., a text selection block in an editor).
    /// </summary>

    internal class UnsharedCharecterRow: ICharacterFlyweight
    {
        private List<ICharacterFlyweight> _characters = new List<ICharacterFlyweight>();

        public void AddCharacter(ICharacterFlyweight character)
        {
            _characters.Add(character);
        }

        public void Render(int position)
        {
            foreach (var character in _characters)
            {
                character.Render(position);
                position += 5; // Move to the next position for the next character
            }
        }
    }
}
