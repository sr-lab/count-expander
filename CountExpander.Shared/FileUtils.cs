﻿using System;
using System.IO;
using System.Linq;

namespace CountExpander.Shared
{
    /// <summary>
    /// Contains file I/O helper methods.
    /// </summary>
    public class FileUtils
    {
        /// <summary>
        /// Reads a file as lines, returning it as an array of strings.
        /// </summary>
        /// <param name="filename">The filename of the file to read.</param>
        /// <returns></returns>
        public static string[] ReadFileAsLines(string filename)
        {
            return File.ReadAllText(filename)
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .Select(x => x.TrimStart().TrimEnd(new[] { '\r', '\n' }))
                .ToArray();
        }
    }
}
