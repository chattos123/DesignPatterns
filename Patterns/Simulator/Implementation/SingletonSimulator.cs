using System;
using Patterns.Simulator.Interface;
using Patterns.Creational.Singleton;




namespace Patterns.Simulator.Implementation
{
    internal class SingletonSimulator : ISimulator
    {
        /*
        PSEUDOCODE / PLAN (detailed):
        - Demonstrate singleton usage on the main thread as before:
            - Retrieve two references (logger1, logger2) from SLogger.Instance
            - Log two messages and check ReferenceEquals to show same instance
        - Simulate a multi-threaded scenario:
            - Create a thread-safe collection (ConcurrentBag<SLogger>) to collect references
            - Create N tasks (e.g., 10). Each task will:
                - Retrieve SLogger.Instance
                - Add the reference to the ConcurrentBag
                - Log a message identifying the task and thread id
            - Wait for all tasks to complete
            - Verify that all collected references point to the same instance:
                - Compare each collected reference with the first one using ReferenceEquals
            - Print the verification result to the console
        - Intentionally add small delays in tasks to increase concurrency and potential race windows
        - Keep the code compact, thread-safe, and compatible with .NET 8 / C# 12
        */

        private static List<SLogger> _collected = new List<SLogger>();
        // 2. Introduce a dedicated object used strictly for thread synchronization
        private static readonly object _listLock = new object();

        private const int TaskCount = 10;


        public void Simulate()
        {
            // Single-threaded demonstration
            SLogger logger1 = SLogger.Instance;
            logger1.Log("This is the first log message.");
            SLogger logger2 = SLogger.Instance;
            logger2.Log("This is the second log message.");

            if (ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("Both logger1 and logger2 reference the same instance.");
            }
            else
            {
                Console.WriteLine("logger1 and logger2 reference different instances.");
            }

            // Multiple threads can also access the singleton instance safely

            Task[] tasks = new Task[TaskCount];

            for (int i = 0; i < TaskCount; i++)
            {
                int taskId = i + 1;
                tasks[i] = Task.Run(new Action(() => ExecuteTask(taskId)));
            }

            Task.WaitAll(tasks);
            VerifySingleton();

        }

        private void ExecuteTask(int id)
        {
            Thread.Sleep(id * 10);

            SLogger logger = SLogger.Instance;

            // 3. Thread-safety barrier
            // Only one thread can enter this block at any given millisecond.
            // All other threads must wait in line outside until the current thread exits.
            lock (_listLock)
            {
                _collected.Add(logger);
            }

            logger.Log("Log from task " + id + " on thread " + Thread.CurrentThread.ManagedThreadId);
        }

        private static void VerifySingleton()
        {
            // Count check on traditional list
            if (_collected.Count == 0)
            {
                Console.WriteLine("No logger references were collected from tasks.");
                return;
            }

            // Grab the first element traditionally
            SLogger firstInstance = _collected[0];
            bool allSame = true;

            foreach (SLogger currentInstance in _collected)
            {
                if (!ReferenceEquals(currentInstance, firstInstance))
                {
                    allSame = false;
                    break;
                }
            }

            if (allSame)
            {
                Console.WriteLine("All task-obtained logger references point to the same singleton instance.");
            }
            else
            {
                Console.WriteLine("Different instances detected among task-obtained logger references.");
            }
        }
    }
}
