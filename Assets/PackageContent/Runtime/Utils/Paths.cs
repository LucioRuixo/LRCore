using UnityEngine;

namespace LRCore.Utils
{
    public static class Paths
    {
        public static readonly string assetsFolder = Application.dataPath;
        public static readonly string projectFolder = assetsFolder.Replace("/Assets", "");
        public static readonly string buildsFolder = $"{projectFolder}/Builds";
        public static readonly string packageFolder = $"{assetsFolder}/PackageContent";
        public static readonly string packagesFolder = $"{projectFolder}/Packages";
        public static readonly string projectSettingsFolder = $"{projectFolder}/ProjectSettings";

        public static readonly string editorSettings = $"{projectSettingsFolder}/EditorSettings.asset";
    }
}