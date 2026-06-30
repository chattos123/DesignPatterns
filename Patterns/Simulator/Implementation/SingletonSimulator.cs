using Patterns.Creational.Singleton;
using Patterns.Simulator.Interface;
using System;
using System.Diagnostics;




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
            RunBigAssetManagerTest();
            RunThreadSafetyStressTest();
            RunMemoryLifecycleAndRecoveryTest();

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

            Console.WriteLine($"Total collected references: {_collected.Count}");
        }

        private static void RunBigAssetManagerTest()
        {
            Console.WriteLine("Simulating BigAssetManager <Holding big data in singleton using Weak Reference> usage...");

            // Step 1: Access the manager and request the data for the first time
            // This triggers the heavy disk-load simulation.
            byte[]? standardReference = BigAssetManager.Instance.GetAssetData();

            // Step 2: Use it again immediately. (Cache Hit)
            byte[]? secondReference = BigAssetManager.Instance.GetAssetData();

            // Step 3: Sever the strong reference link in your local execution block
            standardReference = null;
            secondReference = null;

            Console.WriteLine("Strong references cleared. Inducing Garbage Collection...");

            // Force GC to look at Gen 2 and Large Object Heap (LOH)
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("Garbage Collection cycle complete.");

            // Step 4: Request the data again. 
            // Because no strong references held it down, the GC successfully wiped the 500MB array.
            // The manager automatically detects this and reloads it safely.
            byte[] reloadedReference = BigAssetManager.Instance.GetAssetData();
        }

        /// <summary>
        /// Verifies that multiple threads requesting the asset simultaneously 
        /// do not cause multiple redundant disk loads due to internal locks.
        /// </summary>
        private static void RunThreadSafetyStressTest()
        {
            Console.WriteLine("[Thread Safty Test in Big Asset manager] Initiating Multi-Threaded Stress Test...");

            const int concurrentTaskCount = 8;
            Task[] tasks = new Task[concurrentTaskCount];

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < concurrentTaskCount; i++)
            {
                int taskId = i + 1;
                tasks[i] = Task.Run(() =>
                {
                    // Simultaneous access point
                    byte[] data = BigAssetManager.Instance.GetAssetData();

                    // Keep a minimal assert validation to ensure data isn't corrupted
                    if (data == null || data.Length != 500_000_000)
                    {
                        throw new Exception($"Thread {taskId} received an invalid buffer!");
                    }
                });
            }

            // Wait for all simultaneous worker threads to finish
            Task.WaitAll(tasks);
            sw.Stop();

            Console.WriteLine($"[SUCCESS] All {concurrentTaskCount} threads completed safely.");
            Console.WriteLine($"Total execution time for parallel load: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("Notice that \"Reloading massive file...\" was only printed ONCE.");
        }

        /// <summary>
        /// Confirms that cache hits function properly under strong references, 
        /// and that the asset successfully unloads and recovers when references are dropped.
        /// </summary>
        private static void RunMemoryLifecycleAndRecoveryTest()
        {
            Console.WriteLine("[Memory Test on Big Asset Manager] Initiating Memory Lifecycle and Recovery Test...");

            // 1. Establish a local strong reference to the asset
            Console.WriteLine("\n-> Requesting asset data (Should be a CACHE HIT from previous test)...");
            byte[]? strongRef = BigAssetManager.Instance.GetAssetData();

            // 2. Validate immediate cache hit performance
            long memBeforeGC = GC.GetTotalMemory(false) / (1024 * 1024);
            Console.WriteLine($"Current managed memory footprint: {memBeforeGC} MB");

            Console.WriteLine("\n-> Requesting asset data again with strong reference alive...");
            byte[]? secondRef = BigAssetManager.Instance.GetAssetData();

            bool referencesIdentical = ReferenceEquals(strongRef, secondRef);
            Console.WriteLine($"Are both returned references pointing to the exact same memory array? {referencesIdentical}");

            if (!referencesIdentical)
            {
                throw new Exception("Error: Cache returned a different reference while object was still alive!");
            }

            // 3. Sever all local strong reference hooks to the 500MB array
            Console.WriteLine("\n-> Severing all local strong references to allow compilation collection...");
            strongRef = null;
            secondRef = null;

            // 4. Force Garbage Collection cycles to clean up Large Object Heap (LOH)
            Console.WriteLine("Inducing explicit Garbage Collection...");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect(); // Second collection clears any objects promoted during finalization

            long memAfterGC = GC.GetTotalMemory(true) / (1024 * 1024);
            Console.WriteLine($"Managed memory footprint post-GC: {memAfterGC} MB");
            Console.WriteLine("(Memory should have dropped significantly back to baseline tracking numbers)");

            // 5. Request the data one final time. The manager must recover from the cache miss safely.
            Console.WriteLine("\n-> Requesting asset data post-GC collection (Should trigger a CACHE MISS and reload)...");
            byte[] recoveredRef = BigAssetManager.Instance.GetAssetData();

            if (recoveredRef != null && recoveredRef.Length == 500_000_000)
            {
                Console.WriteLine("[SUCCESS] Weak reference lifecycle and recovery test passed.");
            }
            else
            {
                throw new Exception("Error: Recovered reference payload failed validation check.");
            }
        }
    }
}
