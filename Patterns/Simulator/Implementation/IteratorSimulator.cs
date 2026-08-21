using Patterns.Behavioral.Iterator.Generic.Implementation;
using Patterns.Behavioral.Iterator.Generic.Interface;
using Patterns.Behavioral.Iterator.Typical.Implementation;
using Patterns.Behavioral.Iterator.Typical.Implementation.Model;
using Patterns.Simulator.Interface;

namespace Patterns.Simulator.Implementation
{
    internal class IteratorSimulator : ISimulator
    {
        public void Simulate()
        {
            Console.WriteLine("Generic Iterator Pattern Simulation Started...");
            // Create a collection and add items to it
            ConcreteAggregateCollection collection = new ConcreteAggregateCollection();
            collection[0] = new Item("Item A");
            collection[1] = new Item("Item B");
            collection[2] = new Item("Item C");
            collection[3] = new Item("Item D");
            collection[4] = new Item("Item E");
            collection[5] = new Item("Item F");

            //create an iterator for the collection
            IIterator iterator = collection.CreateIterator();

            // Iterate through the collection using the iterator
            Console.WriteLine("Iterating through the collection:");
            
            for (IItem? item = iterator.First(); !iterator.IsCompleted(); item = iterator.Next())
            {
                Console.WriteLine(item?.Name);
            }

            Console.WriteLine("Generic Iterator Pattern Simulation Completed.");

            // Typical use case: Iterating through a collection of items without exposing the underlying representation.

            Console.WriteLine("\nTypical Iterator Pattern Simulation Started...");

            var playlist = new Playlist();
            playlist.AddSong(new Song("Bohemian Rhapsody", "Queen"));
            playlist.AddSong(new Song("Hotel California", "Eagles"));
            playlist.AddSong(new Song("Comfortably Numb", "Pink Floyd"));
            playlist.AddSong(new Song("Stairway to Heaven", "Led Zeppelin"));

            // foreach automatically uses GetEnumerator() and MoveNext()
            foreach (var song in playlist)
            {
                Console.WriteLine($"{song.Title} - {song.Artist}");
            }

            Console.WriteLine("Typical Iterator Pattern Simulation Completed.");
        }
    }
}
