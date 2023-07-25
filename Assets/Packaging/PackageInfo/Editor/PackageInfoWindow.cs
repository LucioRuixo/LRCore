using UnityEditor;
using UnityEngine;

namespace LRCore
{
    public class PackageInfoWindow : ScriptableWindow
    {
        #region Constants
        private const string Title = "Package Info";
        private const string Shortcut_Open = "%#i";

        private const string AssetName = "PackageInfo";
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