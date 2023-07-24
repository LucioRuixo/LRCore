using System;
using System.Collections.Generic;
using System.IO;

namespace LRCore.Utils
{
    public static class FileParser
    {
        private static readonly HashSet<Type> where Type : Extension validExtensions = new string[]
        {
            ".txt",
            ".asset"
        };

        private static bool ValidateExtension(string extension)
        {
            foreach (string validExtension in validExtensions)
            {
                if (extension.EndsWith(validExtension)) return true;
            }

            return false;
        }

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