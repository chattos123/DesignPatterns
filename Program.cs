using System;

namespace DesignPatternsPrinciples
{
    /// <summary>
    /// Traditional console application entry point replacing top-level statements.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Application entry point.
        /// Writes a greeting to the console and returns exit code 0.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>Exit code.</returns>
        public static int Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            if (args is not null && args.Length > 0)
            {
                Console.WriteLine("Arguments:");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"  [{i}] {args[i]}");
                }
            }

            // Replace or extend this method with actual application startup logic.
            return 0;
        }
    }
}
