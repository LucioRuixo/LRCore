using UnityEditor;
using UnityEngine;

namespace LRCore
{
    public class VersioningToolWindow : EditorWindow
    {
        private const string Title = "Versioning Tool";
        private const string Shortcut_Open = "#&v";

        [MenuItem(LRCore.Signature + "/" + Title + " " + Shortcut_Open)]
        public static void Open() => GetWindow<VersioningToolWindow>(Title);

        private void OnGUI()
        {
            string version = "1.0.0";
            // TODO: auto-detectar versi�n

            GUILayout.Label($"Creating new version: {version}", EditorStyles.boldLabel);
        }
    }
}