using UnityEngine;

namespace LRCore.Packaging
{
    [CreateAssetMenu(fileName = "Package Info", menuName = "Package Info")]
    public class PackageInfo : ScriptableObject
    {
        [Header("Required properties")]
        [SerializeField] private string packageName;
        public string PackageName => packageName;


        [Header("Recommended properties")]
        [SerializeField] private string description;
        public string Description => description;

        [SerializeField] private string displayName;
        public string DisplayName => displayName;

        [SerializeField] private string unity;
        public string Unity => unity;


        [Header("Optional properties")]
        [SerializeField] private string author;
        public string Author => author;

        [SerializeField] private string changelogURL;
        public string ChangelogURL => changelogURL;

        [SerializeField] private string dependencies;
        public string Dependencies => dependencies;

        [SerializeField] private string documentationURL;
        public string DocumentationURL => documentationURL;

        [SerializeField] private string hideInEditor;
        public string HideInEditor => hideInEditor;

        [SerializeField] private string keywords;
        public string Keywords => keywords;

        [SerializeField] private string license;
        public string License => license;

        [SerializeField] private string licensesURL;
        public string LicensesURL => licensesURL;

        [SerializeField] private string samples;
        public string Samples => samples;

        [SerializeField] private string type;
        public string Type => type;

        [SerializeField] private string unityRelease;
        public string UnityRelease => unityRelease;
    }
}