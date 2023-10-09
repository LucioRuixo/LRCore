using UnityEditor;
using UnityEngine;

namespace LRCore.Packaging.Editor
{
    using Utils;
    using Utils.Extensions;

    public class PackageManifestInfoWindow : ScriptableWindow
    {
        #region Constants
        private const string MenuTitle = "Package Manifest Info";
        private const string Shortcut_Open = "%#i";
        #endregion

        public override string Title => MenuTitle;

        [MenuItem(LRCore.Signature + "/" + MenuTitle + " " + Shortcut_Open)]
        public static void Open()
        {
            ScriptableObject asset = (ScriptableObject)Resources.Load(PackageManifestInfo.AssetName);
            Open(asset);
        }

        new public static void Open(ScriptableObject scriptableObject)
        {
            PackageManifestInfoWindow window = (PackageManifestInfoWindow)GetWindow(typeof(PackageManifestInfoWindow), false);
            if (!window) return;

            // TODO: que el título de la ventana sea Title (ahora no funciona)
            window.titleContent.text = window.Title;
            window.SetTargetObject(scriptableObject);
        }

        protected override void OnGUI()
        {
            base.OnGUI();

            EditorGUILayout.Space();

            if (GUILayout.Button($"Serialize manifest"))
            {
                PackageManifestInfo manifestAsset = (PackageManifestInfo)Resources.Load(PackageManifestInfo.AssetName);
                string manifestPath = $"{Paths.packagesFolder}/{manifestAsset.PackageName}/{PackagingUtils.ManifestFileName}";

                ((SerializableExtension)Extension.ValidExts[ExtTypes.JSON]).Serialize(manifestPath, manifestAsset);
            }
        }
    }
}