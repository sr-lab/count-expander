using System;
using System.IO;

using CountExpander.Shared;

namespace CountExpander
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check number of arguments.
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: CountExpander.exe <in_file> [unique_only]");
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
            if (args.Length > 1 && args[1] == "-u")
            {
                uniqueOnly = true;
            }

            // For each line in the input file.
            var lines = FileUtils.ReadFileAsLines(args[0]);
            foreach (var line in lines)
            {
                // Trim leading space.
                var trimmed = line.TrimStart();

                // Buffer count and password.
                var countBuffer = "";
                var passBuffer = "";

                // Put count and password into buffers.
                var inCountBuffer = true;
                foreach (var chr in trimmed)
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
                var totalCount = 0;
                if (uniqueOnly)
                {
                    totalCount = 1;
                }
                else if (!int.TryParse(countBuffer, out totalCount))
                {
                    // If count could not be parsed, continue to next line.
                    continue;
                }

                // Print count against password.
                // Console.WriteLine($"{totalCount}:{passBuffer}");

                // Write password to output `count` times.
                for (int i = 0; i < totalCount; i++)
                {
                    Console.WriteLine(passBuffer);
                }
            }
        }
    }
}
