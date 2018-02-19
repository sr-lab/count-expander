using System;
using System.IO;
using System.Linq;

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
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: Guesser <in_db> <out_db> [unique_only]");
                return;
            }

            // Check file exists.
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Could not read input file.");
                return;
            }

            // Check for unique only flag.
            var uniqueOnly = false;
            if (args.Length > 2 && args[2] == "-u")
            {
                uniqueOnly = true;
            }

            // Open output stream.
            var output = new StreamWriter(args[1]);

            // For each line in the input file.
            var lines = ReadFileAsLines(args[0]);
            foreach (var line in lines)
            {
                // Buffer count and password.
                var countBuffer = "";
                var passBuffer = "";

                // Put count and password into buffers.
                var inCountBuffer = true;
                foreach (var chr in line)
                {
                    if (char.IsDigit(chr) && inCountBuffer)
                    {
                        countBuffer += chr;
                    }
                    else
                    {
                        if (inCountBuffer)
                        {
                            inCountBuffer = false;
                        }
                        else
                        {
                            passBuffer += chr;
                        }
                    }
                }
                
                // If unique only flag passed, keep count to 1.
                var totalCount = uniqueOnly ? 1 : int.Parse(countBuffer);

                // Print count against password.
                Console.WriteLine($"{totalCount}:{passBuffer}");

                // Write password to output `count` times.
                for (int i = 0; i < totalCount; i++)
                {
                    output.WriteLine(passBuffer);
                }
            }

            // Flush and close output stream.
            output.Flush();
            output.Close();
        }
    }
}
