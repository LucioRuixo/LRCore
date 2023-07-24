using UnityEditor;
using UnityEngine;

namespace LRCore
{
    public class PackageInfoWindow : EditorWindow
    {
        private const string Title = "Package Info";
        private const string Shortcut_Open = "%#i";

        private const string AssetName = "Package Info";

        [MenuItem(LRCore.Signature + "/" + Title + " " + Shortcut_Open)]
        public static void Open()
        {
            ScriptableObject asset = (ScriptableObject)Resources.Load(AssetName);
            ScriptableWindow.OpenWindow(asset);
        }

        private void OnGUI()
        {
            string version = "1.0.0";
            // TODO: auto-detectar versión

            GUILayout.Label($"Creating new version: {version}", EditorStyles.boldLabel);
        }
    }
}