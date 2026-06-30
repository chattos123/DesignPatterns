using System;

namespace Patterns.Creational.Singleton
{
    internal sealed class BigAssetManager
    {
        // 1. Thread-safe, lazy initialization of the Singleton Manager instance
        private static readonly Lazy<BigAssetManager> _instance =
            new Lazy<BigAssetManager>(() => new BigAssetManager());

        public static BigAssetManager Instance => _instance.Value;

        // 2. A synchronization lock for when we need to re-allocate the asset data
        private readonly object _dataLock = new object();

        // 3. The WeakReference holds onto the huge payload without preventing GC collection
        private WeakReference<byte[]>? _weakAssetBuffer = null; 

        // Private constructor prevents external instantiation
        private BigAssetManager()
        {            
            Console.WriteLine("BigAssetManager Singleton Initialized.");
        }

        /// <summary>
        /// Retrieves the large asset buffer. If the GC collected it, 
        /// it seamlessly reloads it from the source.
        /// </summary>
        public byte[] GetAssetData()
        {
            // Declare the variable upfront so it is visible to both scopes
            byte[]? existingBuffer = null;

            // 1. Check if the wrapper itself exists, and if it holds the target
            if (_weakAssetBuffer != null && _weakAssetBuffer.TryGetTarget(out existingBuffer))
            {
                Console.WriteLine("Cache Hit: Serving asset directly from memory.");
                return existingBuffer;
            }

            lock (_dataLock)
            {
                // 2. Double-check after entering the lock
                if (_weakAssetBuffer != null && _weakAssetBuffer.TryGetTarget(out existingBuffer))
                {
                    return existingBuffer;
                }

                Console.WriteLine("Cache Miss: Reloading massive file...");
                byte[] freshlyLoadedBuffer = LoadMassiveFileFromDisk();

                // 3. Create the WeakReference container here if it's the first run, 
                // otherwise just update its target.
                if (_weakAssetBuffer == null)
                {
                    _weakAssetBuffer = new WeakReference<byte[]>(freshlyLoadedBuffer);
                }
                else
                {
                    _weakAssetBuffer.SetTarget(freshlyLoadedBuffer);
                }

                return freshlyLoadedBuffer;
            }
        }


        private byte[] LoadMassiveFileFromDisk()
        {
            // Simulating a 500 MB allocation (approx. 500,000,000 bytes)
            return new byte[500_000_000];
        }
    }
}
