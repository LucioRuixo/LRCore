using UnityEngine;

namespace LRCore
{
    [CreateAssetMenu(fileName = "New Workspace Settings", menuName = "Workspace Settings")]
    public class WorkspaceSettings : ScriptableObject
    {
        #region Constants
        public const string AssetName = "WorkspaceSettings";
        #endregion

        [SerializeField] private string rootNamespace;
        public string RootNamespace => rootNamespace;
    }
}