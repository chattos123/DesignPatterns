// ============================================================================
// File:        IAggregateCollection.cs
// Path:        Patterns.Behavioral.Iterator.Generic.Interface/IAggregateCollection.cs
// Author:      soumyajit
// Date:        2026-08-21
// Description: Defines the classic GoF Aggregate interface declaring the factory
//              method to create an iterator for collection traversal.
// ============================================================================

namespace Patterns.Behavioral.Iterator.Generic.Interface;

/// <summary>
/// Defines the contract for an aggregate collection in the classic Gang of Four (GoF) Iterator pattern.
/// Declares the factory method responsible for instantiating an appropriate <see cref="IIterator"/>.
/// </summary>
internal interface IAggregateCollection
{
    /// <summary>
    /// Creates and returns a new iterator instance configured to traverse this aggregate collection.
    /// </summary>
    /// <returns>
    /// An <see cref="IIterator"/> instance positioned to traverse the collection.
    /// </returns>
    IIterator CreateIterator();
}