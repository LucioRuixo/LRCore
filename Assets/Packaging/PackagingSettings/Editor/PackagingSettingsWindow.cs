using UnityEditor;
using UnityEngine;

namespace LRCore
{
    public class PackagingSettingsWindow : ScriptableWindow
    {
        #region Constants
        private const string MenuTitle = "Packaging Settings";
        private const string Shortcut_Open = "%#j";

        private const string AssetName = "PackagingSettings";
        #endregion

        public override string Title => MenuTitle;

        [MenuItem(LRCore.Signature + "/" + MenuTitle + " " + Shortcut_Open)]
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