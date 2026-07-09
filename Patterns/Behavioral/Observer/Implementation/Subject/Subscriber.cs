using System;

namespace Patterns.Behavioral.Observer.Implementation.Subject
{
    internal class Subscriber
    {
        private string _name;

        public Subscriber(string name)
        {
            _name = name;
        }

        // Event handler method
        public void OnNewsPublished(string news)
        {
            Console.WriteLine($"{_name} received news update: {news}");
        }
    }
}
