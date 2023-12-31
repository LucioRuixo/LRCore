using System;
using UnityEngine;

using Newtonsoft.Json;

namespace LRCore.Packaging
{
    public sealed class PackageManifestInfo : ScriptableObject
    {
        #region Constants
        public const string AssetName = "PackageManifestInfo";
        public const string AssetPath = AssetName;
        #endregion

        #region Structures
        [Serializable]
        public struct Author
        {
            [SerializeField] private string name;
            [JsonProperty("name")] public string Name => name;

            [SerializeField] private string email;
            [JsonProperty("email")] public string Email => email;

            [SerializeField] private string url;
            [JsonProperty("url")] public string URL => url;
        }

        [Serializable]
        public struct Dependencies
        {
            [SerializeField] private string newtonsoftJson;
            [JsonProperty("com.unity.nuget.newtonsoft-json")] public string NewtonsoftJson => newtonsoftJson;
        }
        #endregion

        [Header("Required properties")]
        [SerializeField] private string packageName;
        [JsonProperty("name")] public string PackageName => packageName;


        [Header("Recommended properties")]
        [SerializeField] private string description;
        [JsonProperty("description")] public string Description => description;

        [SerializeField] private string displayName;
        [JsonProperty("displayName")] public string DisplayName => displayName;

        [SerializeField] private string unity;
        [JsonProperty("unity")] public string Unity => unity;


        [Header("Optional properties")]
        [SerializeField] private Author author;
        [JsonProperty("author")] public Author _Author => author;

        [SerializeField] private string changelogURL;
        [JsonProperty("changelogUrl")] public string ChangelogURL => changelogURL;

        [SerializeField] private Dependencies dependencies;
        [JsonProperty("dependencies")] public Dependencies _Dependencies => dependencies;

        [SerializeField] private string documentationURL;
        [JsonProperty("documentationUrl")] public string DocumentationURL => documentationURL;

        [SerializeField] private bool hideInEditor;
        [JsonProperty("hideInEditor")] public bool HideInEditor => hideInEditor;

        [SerializeField] private string[] keywords;
        [JsonProperty("keywords")] public string[] Keywords => keywords;

        [SerializeField] private string license;
        [JsonProperty("license")] public string License => license;

        [SerializeField] private string licensesURL;
        [JsonProperty("licensesUrl")] public string LicensesURL => licensesURL;

        [SerializeField] private object[] samples;
        [JsonProperty("samples")] public object[] Samples => samples;

        [SerializeField] private string type;
        [JsonProperty("type")] public string Type => type;

        [SerializeField] private string unityRelease;
        [JsonProperty("unityRelease")] public string UnityRelease => unityRelease;

        [JsonProperty("version")] public string Version => ReleaseHistory.LatestVersion;

        public static PackageManifestInfo Get()
        {
            PackageManifestInfo manifestAsset = (PackageManifestInfo)Resources.Load(AssetName);

            if (!manifestAsset) Debug.LogError($"PACKAGE MANIFEST INFO | Could not load package manifest info from path \"{AssetName}\"");

            return manifestAsset;
        }
    }
}