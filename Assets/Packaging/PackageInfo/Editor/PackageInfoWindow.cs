using UnityEditor;
using UnityEngine;

namespace LRCore
{
    using PackageInfo = Packaging.PackageInfo;

    public class PackageInfoWindow : ScriptableWindow
    {
        #region Constants
        private const string MenuTitle = "Package Info";
        private const string Shortcut_Open = "%#i";
        #endregion

        public override string Title => MenuTitle;

        [MenuItem(LRCore.Signature + "/" + MenuTitle + " " + Shortcut_Open)]
        public static void Open()
        {
            ScriptableObject asset = (ScriptableObject)Resources.Load(PackageInfo.AssetName);
            Open(asset);
        }

        private void OnGUI()
        {
            // TODO
        }
    }
}