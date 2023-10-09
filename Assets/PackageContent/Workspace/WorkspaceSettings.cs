using UnityEngine;
using EditorCools;

namespace LRCore
{
    using Settings;

    [CreateAssetMenu(fileName = "New Workspace Settings", menuName = "Workspace Settings")]
    public class WorkspaceSettings : ScriptableObject
    {
        private const string RootNamespace = LRCore.Signature;

        [Button]
        private void SetUpWorkspace()
        {
            ProjectSettings._EditorSettings.ProjectGenerationRootNamespace = RootNamespace;
        }
    }
}