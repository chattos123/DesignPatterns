using Patterns.Structural.Flyweight.implementation.ConcreteFlyweight;
using Patterns.Structural.Flyweight.Interface;
using System;
using System.Collections.Generic;

namespace Patterns.Structural.Flyweight.implementation.Factory
{
    /// <summary>
    /// Flyweight Factory <step 6>:
    /// - Manages a pool of existing flyweights.
    /// - Clients never create flyweights directly; they request them from the factory.
    /// - The factory checks for an existing flyweight with the given intrinsic state.
    /// - If found, it returns the existing instance; otherwise, it creates and stores a new one.
    /// - Ensures object reuse and reduces memory overhead.
    /// </summary>

    internal class CharacterFactory
    {
        private readonly Dictionary<string, ICharacterFlyweight> _pool = new Dictionary<string, ICharacterFlyweight>();

        public ICharacterFlyweight GetCharacterFormat(char symbol, string fontName, int fontSize, bool isBold)
        {
            string key = $"{symbol}_{fontName}_{fontSize}_{isBold}";

            //Laxy instantiation: Check if the ConcreteFlyweight already exists in the pool

            if (!_pool.ContainsKey(key))
            {
                // Instantiating the ConcreteFlyweight and storing it in the pool
                _pool[key] = new CharacterFormat(symbol, fontName, fontSize, isBold);
            }

            return _pool[key];
        }

        // Added to expose the internal pool for memory calculations
        public int GetUniquePoolCount() => _pool.Count;
    }
}
