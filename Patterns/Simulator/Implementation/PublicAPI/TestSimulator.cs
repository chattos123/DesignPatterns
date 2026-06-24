using System;
using Patterns.Simulator.Interface;
using System.Collections.Generic;
using System.IO;

namespace Patterns.Simulator.Implementation.PublicAPI
{
    /// <summary>
    /// Factory + runner for pattern simulators.
    /// Call <see cref="Run(string?)"/> with a pattern name (case-insensitive) or "all".
    /// Reads pattern user guide text from a `userguide.txt` file copied to output.
    /// </summary>
    public static class TestSimulator
    {
        private const string GuideFileName = "PatternDoc.txt";
        private static readonly Dictionary<string, string> _guides = LoadUserGuides();

        public static void Run(string? patternName)
        {
            var key = string.IsNullOrWhiteSpace(patternName) ? "all" : patternName.Trim();

            if (string.Equals(key, "all", System.StringComparison.OrdinalIgnoreCase))
            {
                RunAll();
                return;
            }

            var simulator = CreateSimulator(key);
            ShowGuideForKey(key);
            simulator.Simulate();
        }

        private static void RunAll()
        {
            ISimulator[] sims = new ISimulator[]
            {
                new SingletonSimulator(),
                new AbstractFactorySimulator(),
                new BuilderSimulator(),
                new FactorySimulator(),
                new PrototypeSimulator(),
                new AdapterSimulator(),
                new BridgeSimulator()
            };

            foreach (var s in sims)
            {
                // attempt to infer name from type
                var name = s.GetType().Name.Replace("Simulator", "");
                ShowGuideForKey(name);
                s.Simulate();
            }
        }

        private static ISimulator CreateSimulator(string key)
        {
            return key.ToLowerInvariant() switch
            {
                "singleton" or "single" => new SingletonSimulator(),
                "abstractfactory" or "abstract" or "abstractfactory" => new AbstractFactorySimulator(),
                "builder" or "build" => new BuilderSimulator(),
                "factory" or "fact" or "factorypattern" => new FactorySimulator(),
                "prototype" or "proto" => new PrototypeSimulator(),
                "adapter" or "adp" or "adapterpattern" => new AdapterSimulator(),
                "bridge" => new BridgeSimulator(),
                "composite" or "comp" or "compositepattern" => new CompositeSimulator(),
                "decorator" or "deco" or "decoratorpattern" => new DecoratorSimulator(),
                _ => throw new System.ArgumentException($"Unknown simulator '{key}'. Valid: singleton, abstractfactory, builder, factory, prototype, adapter, composite, decorator, all.", nameof(key))
            };
        }

        private static void ShowGuideForKey(string key)
        {
            try
            {
                var normalized = NormalizeKey(key);
                if (_guides.TryGetValue(normalized, out var guide))
                {
                    System.Console.WriteLine("----- User Guide: " + normalized + " -----");
                    System.Console.WriteLine(guide);
                    System.Console.WriteLine();
                }
                else
                {
                    System.Console.WriteLine($"No user guide found for '{key}'. Available guides: {string.Join(", ", _guides.Keys)}");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Could not read user guide: " + ex.Message);
            }
        }

        private static string NormalizeKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return string.Empty;
            return key.Trim().ToLowerInvariant().Replace(" ", "");
        }

        private static Dictionary<string, string> LoadUserGuides()
        {
            var result = new Dictionary<string, string>();

            // Look for the userguide file in the app base directory
            var path = Path.Combine(System.AppContext.BaseDirectory,GuideFileName);

            if (!File.Exists(path))
            {
                return result;
            }

            var lines = File.ReadAllLines(path);
            string? currentKey = null;
            var buffer = new List<string>();

            foreach (var raw in lines)
            {
                var line = raw.TrimEnd();
                if (line.StartsWith("## "))
                {
                    if (currentKey is not null)
                    {
                        result[currentKey] = string.Join(System.Environment.NewLine, buffer).Trim();
                        buffer.Clear();
                    }

                    currentKey = NormalizeKey(line.Substring(3));
                    continue;
                }

                if (currentKey is null)
                {
                    // skip any top-of-file text until first heading
                    continue;
                }

                buffer.Add(line);
            }

            if (currentKey is not null)
            {
                result[currentKey] = string.Join(System.Environment.NewLine, buffer).Trim();
            }

            return result;
        }
    }
}
