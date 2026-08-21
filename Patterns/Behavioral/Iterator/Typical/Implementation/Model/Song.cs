// ============================================================================
// File:        Song.cs
// Path:        Patterns.Behavioral.Iterator.Typical.Implementation.Model/Song.cs
// Author:      soumyajit
// Date:        2026-08-21
// Description: Represents an immutable song entity used as the data model
//              in the typical Iterator Design Pattern implementation.
// ============================================================================

namespace Patterns.Behavioral.Iterator.Typical.Implementation.Model;

/// <summary>
/// Represents a song data model holding track information.
/// </summary>
/// <param name="Title">The name/title of the song track.</param>
/// <param name="Artist">The name of the artist or band who performed the song.</param>
public record Song(string Title, string Artist);