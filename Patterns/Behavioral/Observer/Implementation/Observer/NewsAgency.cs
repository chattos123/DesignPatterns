using System;

namespace Patterns.Behavioral.Observer.Implementation.Observer
{
    // Subject (Publisher)
    internal class NewsAgency
    {
        // Declare the delegate (event handler signature)
        public delegate void NewsEventHandler(string news);

        // Declare the event
        public event NewsEventHandler? NewsPublished;

        // Method to publish news
        public void AddNews(string news)
        {
            Console.WriteLine($"NewsAgency published: {news}");
            // Raise the event
            NewsPublished?.Invoke(news);
        }

        public void ExamineInvokationList()
        {
            if (NewsPublished == null)
            {
                Console.WriteLine("No subscribers.");
                return;
            }

            foreach (var d in NewsPublished.GetInvocationList())
            {
                Console.WriteLine("Class = {0}, Method = {1}",
                    d.Method.DeclaringType?.Name,
                    d.Method.Name);
            }

            Console.WriteLine("End of invocation list.");

        }
    }
}
