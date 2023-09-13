using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LRCore.Utils
{
    using Extensions;

    public static class FileParser
    {
        private static readonly HashSet<Extension> validExtensions = new HashSet<Extension>
        {
            LRCore.Exts.Asset,
            LRCore.Exts.Text
        };

        private static bool ValidateExtension(string extension) => validExtensions.Any((validExtension) => extension.EndsWith(validExtension));

	    public static string[] ParseFile(string path)
        {
            List<string> lines = new List<string>();

            try
            {
                if (!ValidateExtension(Path.GetExtension(path))) throw new IOException("File extension is not valid.");

                StreamReader reader = File.OpenText(path);

                string line;
                while ((line = reader.ReadLine()) != null) lines.Add(line);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return lines.ToArray();
        }
    }
}