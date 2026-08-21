// ============================================================================
// File:        ConcreteAggregateCollection.cs
// Path:        Patterns.Behavioral.Iterator.Generic.Implementation/ConcreteAggregateCollection.cs
// Author:      soumyajit
// Date:        2026-08-21
// Description: Concrete implementation of the IAggregateCollection interface
//              managing an internal list of Item objects in the GoF Iterator pattern.
// ============================================================================

using System.Collections.Generic;
using Patterns.Behavioral.Iterator.Generic.Interface;

namespace Patterns.Behavioral.Iterator.Generic.Implementation;

/// <summary>
/// Represents the Concrete Aggregate in the classic Gang of Four (GoF) Iterator pattern.
/// Maintains an internal collection of <see cref="Item"/> instances and instantiates
/// a concrete <see cref="Iterator"/> to traverse the elements.
/// </summary>
internal class ConcreteAggregateCollection : IAggregateCollection
{
    private readonly List<Item> _items = new List<Item>();

    /// <summary>
    /// Creates and returns a new <see cref="Iterator"/> instance bound to this collection.
    /// </summary>
    /// <returns>
    /// An <see cref="IIterator"/> configured to iterate over this aggregate.
    /// </returns>
    public IIterator CreateIterator()
    {
        return new Iterator(this);
    }

    /// <summary>
    /// Gets the total number of items currently stored in the collection.
    /// </summary>
    /// <value>
    /// The count of <see cref="Item"/> elements in the collection.
    /// </value>
    public int Count
    {
        get
        {
            return _items.Count;
        }
    }

    /// <summary>
    /// Gets or adds an <see cref="Item"/> at or to the collection.
    /// </summary>
    /// <param name="index">The zero-based index of the item to retrieve.</param>
    /// <value>
    /// The <see cref="Item"/> at the specified index.
    /// </value>
    /// <returns>
    /// The <see cref="Item"/> stored at the given index.
    /// </returns>
    public Item this[int index]
    {
        get
        {
            return _items[index];
        }
        set
        {
            _items.Add(value);
        }
    }
}