using CountExpander.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountExpander.Compressor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check file exists.
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Could not read input file.");
                return;
            }

            // Count up lines.
            var lines = FileUtils.ReadFileAsLines(args[0]);
            var counts = new Dictionary<string, int>();
            foreach (var line in lines)
            {
                if (!counts.ContainsKey(line))
                {
                    counts.Add(line, 0);
                }
                counts[line]++;
            }

            // Output lines.
            foreach (var entry in counts)
            {
                Console.WriteLine($"{entry.Value} {entry.Key}");
            }
        }
    }
}
