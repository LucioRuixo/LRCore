using UnityEditor;
using UnityEngine;

namespace LRCore.Editor.Packaging
{
    using global::LRCore.Packaging;
    using global::LRCore.Utils;
    using global::LRCore.Utils.Extensions;
    using Utils;

    public class PackageManifestInfoWindow : ScriptableWindow
    {
        #region Constants
        private const string Title = "Package Manifest Info";
        private const string MenuTitle = Title;
        private const string Shortcut_Open = "%#i";
        #endregion

        protected override bool AddToHierarchy => false;

        private bool releaseHistoryIsEmpty;
        private string version;

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
            window.Refresh();
        }

        protected override void OnGUI()
        {
            base.OnGUI();

            EditorGUILayout.Space();

            if (GUILayout.Button($"Serialize manifest"))
            {
                PackageManifestInfo manifestAsset = (PackageManifestInfo)Resources.Load(PackageManifestInfo.AssetName);
                string manifestPath = $"{Paths.packagesFolder}/{manifestAsset.PackageName}/{PackagingUtils.PackageManifestFileName}";

                ((SerializableExtension)Extension.ValidExts[ExtTypes.JSON]).Serialize(manifestPath, manifestAsset);
            }
        }

        private void Refresh()
        {
            releaseHistoryIsEmpty = ReleaseHistory.IsEmpty;
            version = ReleaseHistory.LatestVersion;
        }
    }
}