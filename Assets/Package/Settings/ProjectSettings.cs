using System;
using System.Collections.Generic;
using System.IO;

namespace LRCore.Settings
{
    using Utils;

    public static class ProjectSettings
    {
        #region Classes
        public class Settings
        {
            protected const string assetFileExtension = ".asset";

            public bool SetProperty(string path, string propertyID, string value)
            {
                try
                {
                    if (!ValidateAssetExtension(path)) throw new IOException($"File extension is not valid (should be {assetFileExtension}).");

                    List<string> lines = new List<string>(File.ReadAllLines(path));

                    int lineIndex = lines.FindIndex(targetLine => targetLine.Contains(propertyID));
                    if (lineIndex == -1) throw new Exception("Target property line was not found.");
                    string line = lines[lineIndex];

                    int idIndex = line.IndexOf(propertyID);
                    int colonIndex = line.IndexOf(':');
                    string idAndValue = line.Substring(idIndex, line.Length - idIndex);
                    string id = line.Substring(idIndex, colonIndex - idIndex);
                    line = line.Replace(idAndValue, $"{id}: {value}");
                    lines[lineIndex] = line;

                    File.WriteAllLines(path, lines);
                }
                catch (Exception exception)
                {
                    throw exception;
                }

                return true;
            }

            private bool ValidateAssetExtension(string path) => Path.GetExtension(path) == assetFileExtension;
        }

        public class EditorSettings : Settings
        {
            private const string ProjectGenerationRootNamespacePropertyID = "m_ProjectGenerationRootNamespace";

            public string ProjectGenerationRootNamespace { set => SetProperty(Paths.editorSettings, ProjectGenerationRootNamespacePropertyID, value); }
        }
        #endregion

        public static EditorSettings _EditorSettings { get; } = new EditorSettings();
    }
}