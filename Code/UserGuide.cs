using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignPatternsPrinciples.Code
{
    /// <summary>
    /// Simple user guide helper that reads a plain text `userguide.txt` file.
    /// Sections are denoted by markdown-style headers starting with "# " followed
    /// by the section name.
    /// </summary>
    public class UserGuide
    {
        private readonly string _path;

        public UserGuide()
        {
            _path = Path.Combine(AppContext.BaseDirectory, "userguide.txt");
        }

        public void EnsureUserGuideExists()
        {
            if (File.Exists(_path))
                return;

            var defaultContent = new StringBuilder();
            defaultContent.AppendLine("# build");
            defaultContent.AppendLine("Runs the simulator in build mode. Use this to build all patterns.");
            defaultContent.AppendLine();
            defaultContent.AppendLine("# singleton");
            defaultContent.AppendLine("Shows a demonstration of the Singleton pattern.");
            defaultContent.AppendLine();
            defaultContent.AppendLine("# factory");
            defaultContent.AppendLine("Shows a demonstration of the Factory pattern.");
            defaultContent.AppendLine();

            Directory.CreateDirectory(Path.GetDirectoryName(_path) ?? AppContext.BaseDirectory);
            File.WriteAllText(_path, defaultContent.ToString(), Encoding.UTF8);
        }

        public void PrintTableOfContents()
        {
         
            if (File.Exists(_path))
            {
                string content =  File.ReadAllText(_path);

                Console.WriteLine(content);
            }

        }
    }
}
                    