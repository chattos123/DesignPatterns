// ============================================================================
// File:        Playlist.cs
// Path:        Patterns.Behavioral.Iterator.Typical.Implementation/Playlist.cs
// Author:      soumyajit
// Date:        2026-08-21
// Description: Concrete Aggregate implementation of the Iterator Pattern that
//              manages a collection of Song records and exposes an enumerator.
// ============================================================================

using System.Collections;
using System.Collections.Generic;
using Patterns.Behavioral.Iterator.Typical.Implementation.Model;

namespace Patterns.Behavioral.Iterator.Typical.Implementation
{

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
    internal class Playlist : IEnumerable<Song>
    {
        private readonly List<Song> _songs = new();

        /// <summary>
        /// Appends a new song to the end of the playlist.
        /// </summary>
        /// <param name="song">The song entity to add.</param>
        public void AddSong(Song song)
        {
            _songs.Add(song);
        }

        /// <summary>
        /// Gets the total number of songs currently in the playlist.
        /// </summary>
        /// <value>
        /// The number of elements contained in the internal songs collection.
        /// </value>
        public int Count
        {
            get
            {
                return _songs.Count;
            }
        }

        /// <summary>
        /// Gets the song at the specified zero-based index.
        /// </summary>
        /// <param name="index">The zero-based index of the song to retrieve.</param>
        /// <returns>The <see cref="Song"/> at the specified index.</returns>
        public Song this[int index]
        {
            get
            {
                return _songs[index];
            }
        }

        /// <summary>
        /// Returns a strongly-typed enumerator that iterates through the playlist.
        /// </summary>
        /// <returns>A new instance of <see cref="PlaylistIterator"/> pointing to this playlist.</returns>
        public IEnumerator<Song> GetEnumerator()
        {
            return new PlaylistIterator(this);
        }

        /// <summary>
        /// Explicit non-generic implementation required by <see cref="IEnumerable"/>.
        /// Delegates directly to the generic <see cref="GetEnumerator"/> method.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}