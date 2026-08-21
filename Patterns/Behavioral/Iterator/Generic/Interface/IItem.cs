// ============================================================================
// File:        IItem.cs
// Path:        Patterns.Behavioral.Iterator.Generic.Interface/IItem.cs
// Author:      soumyajit
// Date:        2026-08-21
// Description: Defines the base item contract representing an element
//              stored and traversed within an iterable collection.
// ============================================================================

namespace Patterns.Behavioral.Iterator.Generic.Interface;

/// <summary>
/// Defines the abstraction for an item held within an iterable aggregate collection.
/// </summary>
internal interface IItem
{
    /// <summary>
    /// Gets the display name or identifier of the item.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the name of the item.
    /// </value>
    string Name { get; }
}