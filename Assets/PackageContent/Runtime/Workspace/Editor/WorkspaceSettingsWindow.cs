using UnityEditor;
using UnityEngine;

namespace LRCore.Editor
{
    using global::LRCore;
    using global::LRCore.Settings;

    public class WorkspaceSettingsWindow : ScriptableWindow
    {
        #region Constants
        private const string MenuTitle = "Workspace Settings";
        private const string Shortcut_Open = "%#w";
        #endregion

        public override string Title => MenuTitle;

        private static WorkspaceSettings workspaceSettings;

        [MenuItem(LRCore.Signature + "/" + MenuTitle + " " + Shortcut_Open)]
        public static void Open()
        {
            Refresh();
            Open(workspaceSettings);
        }

        new public static void Open(ScriptableObject scriptableObject)
        {
            WorkspaceSettingsWindow window = (WorkspaceSettingsWindow)GetWindow(typeof(WorkspaceSettingsWindow), false);
            if (!window) return;

            // TODO: que el título de la ventana sea Title (ahora no funciona)
            window.titleContent.text = window.Title;
            window.SetTargetObject(scriptableObject);
        }

        public static void Refresh() => workspaceSettings = (WorkspaceSettings)Resources.Load(WorkspaceSettings.AssetName);

        protected override void OnGUI()
        {
            base.OnGUI();

            EditorGUILayout.Space();

            if (GUILayout.Button($"Set up workspace")) SetUpWorkspace();
        }

        private void SetUpWorkspace() => ProjectSettings._EditorSettings.ProjectGenerationRootNamespace = workspaceSettings.RootNamespace;
    }
}