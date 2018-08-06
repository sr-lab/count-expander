using CountExpander.Shared;
using System;
using System.IO;
using System.Linq;

namespace CountExpander
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check number of arguments.
            if (args.Length < 2)
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
                    Console.WriteLine(passBuffer);
                }
            }
        }
    }
}
