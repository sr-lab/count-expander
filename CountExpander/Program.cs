using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountExpander
{
    class Program
    {
        /// <summary>
        /// Reads a file as lines, returning it as an array of strings.
        /// </summary>
        /// <param name="filename">The filename of the file to read.</param>
        /// <returns></returns>
        private static string[] ReadFileAsLines(string filename)
        {
            return File.ReadAllText(filename)
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .Select(x => x.TrimStart().TrimEnd(new[] { '\r', '\n' }))
                .ToArray();
        }

        static void Main(string[] args)
        {
            // Check number of arguments.
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: Guesser <in_db> <out_db>");
                return;
            }

            // Check file exists.
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Could not read input file.");
                return;
            }

            var output = new StreamWriter(args[1]);

            var lines = ReadFileAsLines(args[0]);
            foreach (var line in lines)
            {
                var countBuffer = "";
                var passBuffer = "";
                var inCountBuffer = true;
                foreach (var c in line)
                {
                    if (char.IsDigit(c) && inCountBuffer)
                    {
                        countBuffer += c;
                    }
                    else
                    {
                        if (inCountBuffer)
                        {
                            inCountBuffer = false;
                        }
                        else
                        {
                            passBuffer += c;
                        }
                    }
                }
                var g = int.Parse(countBuffer);
                Console.WriteLine($"{g}:{passBuffer}");
                for (int i = 0; i < g; i++)
                {
                    output.WriteLine(passBuffer);
                }
            }

            output.Flush();
            output.Close();
        }
    }
}
