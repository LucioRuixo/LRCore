using UnityEditor;
using UnityEngine;

namespace LRCore.Editor.Packaging
{
    using global::LRCore.Packaging;
    using Utils;

    public class PackageManifestInfoWindow : ScriptableWindow
    {
        #region Constants
        private const string Title = "Package Manifest Info";
        private const string MenuTitle = Title;
        private const string Shortcut_Open = "%#i";
        #endregion

        [MenuItem(LRCore.Signature + "/" + MenuTitle + " " + Shortcut_Open)]
        public static void Open()
        {
            ScriptableObject asset = (ScriptableObject)Resources.Load(PackageManifestInfo.AssetName);
            Open(asset);
        }

        new public static void Open(ScriptableObject scriptableObject)
        {
            PackageManifestInfoWindow window = GetWindow<PackageManifestInfoWindow>(Title);

            if (!window) return;

            window.SetTargetObject(scriptableObject);
        }
    }
}