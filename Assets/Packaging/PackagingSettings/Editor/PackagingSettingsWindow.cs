using UnityEditor;
using UnityEngine;

namespace LRCore
{
    public class PackagingSettingsWindow : ScriptableWindow
    {
        #region Constants
        private const string Title = "Packaging Settings";
        private const string Shortcut_Open = "%#j";

        private const string AssetName = "PackagingSettings";
        #endregion

        [MenuItem(LRCore.Signature + "/" + Title + " " + Shortcut_Open)]
        public static void Open()
        {
            ScriptableObject asset = (ScriptableObject)Resources.Load(AssetName);
            Open(asset);
        }

        private void OnGUI()
        {
            // TODO
        }
    }
}