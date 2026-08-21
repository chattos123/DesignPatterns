// ============================================================================
// File:        IIterator.cs
// Path:        Patterns.Behavioral.Iterator.Generic.Interface/IIterator.cs
// Author:      soumyajit
// Date:        2026-08-21
// Description: Defines the classic GoF (Gang of Four) Iterator interface for
//              sequential access and traversal over custom collection elements.
// ============================================================================

namespace Patterns.Behavioral.Iterator.Generic.Interface;

/// <summary>
/// Defines the contract for an iterator in the classic Gang of Four (GoF) Iterator pattern.
/// Encapsulates the traversal mechanism across a collection of <see cref="IItem"/> elements
/// without exposing the underlying collection structure.
/// </summary>
internal interface IIterator
{
    /// <summary>
    /// Resets the iterator position and retrieves the first element in the collection.
    /// </summary>
    /// <returns>
    /// The first <see cref="IItem"/> in the sequence, or <c>null</c> if the collection is empty.
    /// </returns>
    IItem? First();

    /// <summary>
    /// Advances the cursor to the next position and retrieves that element.
    /// </summary>
    /// <returns>
    /// The next <see cref="IItem"/> in the sequence, or <c>null</c> if traversal has reached the end.
    /// </returns>
    IItem? Next();

    /// <summary>
    /// Checks whether the iterator has traversed all elements in the collection.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the iteration is complete (past the last element); otherwise, <c>false</c>.
    /// </returns>
    bool IsCompleted();

    /// <summary>
    /// Gets the element at the current cursor position without advancing the iterator.
    /// </summary>
    /// <returns>
    /// The current <see cref="IItem"/> in the sequence, or <c>null</c> if the cursor is in an invalid or uninitialized state.
    /// </returns>
    IItem? CurrentItem();
}