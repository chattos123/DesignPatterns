using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Patterns.Simulator.Implementation.PublicAPI;


namespace DesignPatternsPrinciples.Code
{
    /// <summary>
    /// Traditional console application entry point replacing top-level statements.
    /// Enhanced to support reading and displaying pattern user guides from 'userguide.txt'.
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
            Console.WriteLine("Design Patterns Simulator");

            // Use first argument to choose a simulator, e.g. "singleton", "factory", or "all".
            // If no argument is provided, default to "build" to preserve existing behavior.
            string? selection = args is { Length: > 0 } ? args[0] : null;
            selection ??= "composite"; // Default selection.

            try
            {
                // Ensure the user guide file exists (create with defaults if not).
                var guide = new UserGuide();
                guide.EnsureUserGuideExists();

                // Recognize guide/help commands.
                string selLower = selection.Trim().ToLowerInvariant();

                if (selLower is "help" or "guide" or "userguide" or "docs")
                {
                    guide.PrintTableOfContents();
                }
                else
                {
                    TestSimulator.Run(selection);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return 1;
            }

            // TODO: Add simulator execution logic here if needed.

            return 0;
        }
    }
}
