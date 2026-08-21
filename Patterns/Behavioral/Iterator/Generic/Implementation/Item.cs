// ============================================================================
// File:        Item.cs
// Path:        Patterns.Behavioral.Iterator.Generic.Implementation/Item.cs
// Author:      soumyajit
// Date:        2026-08-21
// Description: Concrete implementation of the IItem interface representing an
//              individual element within the iterable collection.
// ============================================================================

using Patterns.Behavioral.Iterator.Generic.Interface;

namespace Patterns.Behavioral.Iterator.Generic.Implementation;

/// <summary>
/// Represents a concrete element stored within <see cref="ConcreteAggregateCollection"/>.
/// Implements the <see cref="IItem"/> abstraction to provide uniform access to item details.
/// </summary>
internal class Item : IItem
{
    private readonly string _name;

    /// <summary>
    /// Initializes a new instance of the <see cref="Item"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name or description of the item.</param>
    public Item(string name)
    {
        _name = name;
    }

    /// <summary>
    /// Gets the name of the item.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the name of the item.
    /// </value>
    public string Name
    {
        get
        {
            return _name;
        }
    }
}