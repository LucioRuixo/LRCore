using UnityEditor;
using UnityEngine;

namespace LRCore.Editor.Packaging
{
    using global::LRCore.Packaging;

    public class VersioningToolWindow : EditorWindow
    {
        #region Constants
        private const string Title = "Versioning Tool";
        private const string Shortcut_Open = "#&v";
        #endregion

        private static PackageManifestInfo packageInfo;

        private static bool releaseHistoryIsEmpty;

        private static VersionNumber latestVersion;
        private static VersionNumber nextVersion;

        [MenuItem(LRCore.Signature + "/" + Title + " " + Shortcut_Open)]
        public static void Open()
        {
            Refresh();
            GetWindow<VersioningToolWindow>(Title);
        }

        private static void Refresh()
        {
            packageInfo = Packaging.PackageInfo;

            releaseHistoryIsEmpty = ReleaseHistory.IsEmpty;

            latestVersion = !releaseHistoryIsEmpty ? ReleaseHistory.LatestVersion : new();
            nextVersion = latestVersion + 1;
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();

            string latestReleaseText = releaseHistoryIsEmpty ? "No releases available" : $"Latest release version: {latestVersion}";
            GUILayout.Label(latestReleaseText, EditorStyles.boldLabel);

            string nextReleaseText = $"Next release version: {nextVersion}";
            GUILayout.Label(nextReleaseText, EditorStyles.boldLabel);
            
            EditorGUILayout.Space();

            if (GUILayout.Button($"Create release v{nextVersion}"))
            {
                if (VersioningTool.CreateNewRelease(nextVersion)) Refresh();
            }
        }
    }
}