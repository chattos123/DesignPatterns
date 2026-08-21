// ============================================================================
// File:        Iterator.cs
// Path:        Patterns.Behavioral.Iterator.Generic.Implementation/Iterator.cs
// Author:      soumyajit
// Date:        2026-08-21
// Description: Concrete implementation of the IIterator interface providing
//              step-based sequential traversal over ConcreteAggregateCollection.
// ============================================================================

using Patterns.Behavioral.Iterator.Generic.Interface;

namespace Patterns.Behavioral.Iterator.Generic.Implementation;

/// <summary>
/// Represents the Concrete Iterator in the classic Gang of Four (GoF) Iterator pattern.
/// Maintains the current traversal state and provides forward-stepping iteration over
/// an instance of <see cref="ConcreteAggregateCollection"/>.
/// </summary>
internal class Iterator : IIterator
{
    private int _currentIndex = 0;
    private int _step = 1;
    private readonly ConcreteAggregateCollection _collection;

    /// <summary>
    /// Initializes a new instance of the <see cref="Iterator"/> class targeting the specified collection.
    /// </summary>
    /// <param name="collection">The <see cref="ConcreteAggregateCollection"/> instance to iterate over.</param>
    public Iterator(ConcreteAggregateCollection collection)
    {
        _collection = collection;
    }

    /// <summary>
    /// Gets or sets the step increment for traversing elements in the collection.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> indicating how many positions the iterator advances on each <see cref="Next"/> call.
    /// Default is 1.
    /// </value>
    public int Step
    {
        get
        {
            return _step;
        }
        set
        {
            _step = value;
        }
    }

    /// <summary>
    /// Determines whether the iterator has reached or passed the end of the collection.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the current index is greater than or equal to the total item count; otherwise, <c>false</c>.
    /// </returns>
    public bool IsCompleted()
    {
        if (_currentIndex >= _collection.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Gets the item located at the current iterator position without advancing the index.
    /// </summary>
    /// <returns>
    /// The <see cref="IItem"/> at the current cursor position, or <c>null</c> if the collection is empty or invalid.
    /// </returns>
    public IItem? CurrentItem()
    {
        if (_collection != null && _collection.Count > 0)
        {
            return _collection[_currentIndex] as IItem;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Resets the iterator cursor to index 0 and returns the first element in the collection.
    /// </summary>
    /// <returns>
    /// The first <see cref="IItem"/> in the collection, or <c>null</c> if the collection is empty.
    /// </returns>
    public IItem? First()
    {
        if (_collection != null && _collection.Count > 0)
        {
            _currentIndex = 0;
            return _collection[_currentIndex] as IItem;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Advances the cursor forward by the configured <see cref="Step"/> value and retrieves the item at the new position.
    /// </summary>
    /// <returns>
    /// The <see cref="IItem"/> at the newly advanced position, or <c>null</c> if the traversal is completed.
    /// </returns>
    public IItem? Next()
    {
        _currentIndex += _step;

        if (!IsCompleted())
        {
            return _collection[_currentIndex] as IItem;
        }
        else
        {
            return null;
        }
    }
}