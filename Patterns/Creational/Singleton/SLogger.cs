using System;
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Singleton
{
    public sealed class SLogger
    {
        private static SLogger? _instance;
        private static readonly object _lock = new object();
        private readonly string _prefix = "[LOG]";
        private readonly bool _includeTimestamp = true;
        private readonly string? _outputFile;
        private readonly object _fileLock = new object();
        // Private constructor to prevent external instantiation
        private SLogger()
        {
            try
            {
                // Look for configuration in the application's base directory
                string basePath = AppContext.BaseDirectory ?? Environment.CurrentDirectory;
                basePath = basePath + "\\Creational\\Singleton\\Settings\\";
                string configPath = Path.Combine(basePath, "loggerSettings.json");

                if (!File.Exists(configPath))
                {
                    // Also check current directory as a fallback
                    string fallback = Path.Combine(Environment.CurrentDirectory, "loggerSettings.json");
                    if (File.Exists(fallback))
                        configPath = fallback;
                }

                if (File.Exists(configPath))
                {
                    var json = File.ReadAllText(configPath);
                    var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var settings = JsonSerializer.Deserialize<LoggerSettings>(json, opts);
                    if (settings != null)
                    {
                        _prefix = string.IsNullOrEmpty(settings.Prefix) ? _prefix : settings.Prefix;
                        _includeTimestamp = settings.IncludeTimestamp;
                        _outputFile = string.IsNullOrWhiteSpace(settings.OutputFile) ? null : settings.OutputFile;
                    }
                }
            }
            catch
            {
                // Swallow exceptions and use defaults
            }
        }
        // Public method to provide access to the single instance
        public static SLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SLogger();
                        }
                    }
                }
                return _instance;
            }
        }
        public void Log(string message)
        {
            var timePart = _includeTimestamp ? $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] " : string.Empty;
            var text = $"{timePart}{_prefix} {message}";
            Console.WriteLine(text);

            if (!string.IsNullOrEmpty(_outputFile))
            {
                try
                {
                    lock (_fileLock)
                    {
                        File.AppendAllText(_outputFile!, text + Environment.NewLine);
                    }
                }
                catch
                {
                    // Ignore file write errors
                }
            }
        }

        private class LoggerSettings
        {
            public string? Prefix { get; set; }
            public bool IncludeTimestamp { get; set; } = true;
            public string? OutputFile { get; set; }
        }
    }
}
