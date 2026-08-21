// ============================================================================
// File:        PlaylistIterator.cs
// Path:        Patterns.Behavioral.Iterator.Typical.Implementation/PlaylistIterator.cs
// Author:      soumyajit
// Date:        2026-08-21
// Description: Concrete Iterator implementation of the Iterator Pattern that
//              traverses the Playlist collection.
// ============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using Patterns.Behavioral.Iterator.Typical.Implementation.Model;

namespace Patterns.Behavioral.Iterator.Typical.Implementation
{
    // Concrete Iterator	
    /// <summary>
    /// The concrete collection class that implements <see cref="IEnumerable{T}"/> to allow iteration 
    /// over its elements. It acts as the Concrete Aggregate in the Iterator Design Pattern, holding 
    /// an internal collection of songs and providing a custom enumerator for traversal.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <b>Significance of IEnumerable:</b>
    /// <list type="bullet">
    /// <item>
    /// <description><b>Language Integration:</b> Serves as the foundational contract enabling standard <c>foreach</c> loop iteration across any data structure.</description>
    /// </item>
    /// <item>
    /// <description><b>LINQ Backbone:</b> Powers Language Integrated Query (LINQ) extension methods (<c>Where</c>, <c>Select</c>, <c>GroupBy</c>), enabling declarative, functional data pipelines.</description>
    /// </item>
    /// <item>
    /// <description><b>Deferred (Lazy) Execution:</b> Elements are evaluated on-demand during traversal rather than pre-allocated into memory all at once.</description>
    /// </item>
    /// <item>
    /// <description><b>Encapsulation &amp; Immutability:</b> Exposes a forward-only, read-only sequence without leaking internal storage structures (e.g., arrays, trees, hash maps) or mutation methods (<c>Add</c>, <c>Remove</c>).</description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// <b>Covariance Note:</b> The <c>out</c> keyword in <see cref="IEnumerable{T}"/> marks <c>T</c> 
    /// as covariant. Because <see cref="IEnumerable{T}"/> only produces/outputs data and never consumes it, 
    /// a derived type sequence can be safely assigned to a base type sequence (e.g., <c>IEnumerable&lt;Dog&gt;</c> 
    /// to <c>IEnumerable&lt;Animal&gt;</c>).
    /// </para>
    /// </remarks>
    internal class PlaylistIterator : IEnumerator<Song>
    {
        private readonly Playlist _playlist;
        private int _currentIndex = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistIterator"/> class targeting the specified playlist.
        /// </summary>
        /// <param name="playlist">The <see cref="Playlist"/> collection to iterate over.</param>
        public PlaylistIterator(Playlist playlist)
        {
            _playlist = playlist;
        }

        /// <summary>
        /// Gets the <see cref="Song"/> at the current position of the enumerator.
        /// </summary>
        /// <value>
        /// The <see cref="Song"/> element in the playlist at the current index.
        /// </value>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the cursor is outside the bounds of the playlist (e.g., before the first element or after the end).
        /// </exception>
        public Song Current
        {
            get
            {
                if (_currentIndex < 0 || _currentIndex >= _playlist.Count)
                {
                    throw new InvalidOperationException();
                }
                return _playlist[_currentIndex];
            }
        }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator (non-generic implementation).
        /// </summary>
        /// <value>
        /// An <see cref="object"/> representing the current element in the sequence.
        /// </value>
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        /// <summary>
        /// Advances the enumerator to the next element of the playlist.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the enumerator was successfully advanced to the next element; 
        /// <c>false</c> if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            if (_currentIndex < _playlist.Count - 1)
            {
                _currentIndex++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            _currentIndex = -1;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}