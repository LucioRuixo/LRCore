using UnityEngine;

namespace LRCore.Packaging
{
    public static class Packaging
    {
		public static PackageManifestInfo PackageInfo
        {
            get
            {
                string path = PackageManifestInfo.AssetPath;
                PackageManifestInfo packageInfo = Resources.Load<PackageManifestInfo>(path);

                if (!packageInfo) Logger.LogError(typeof(Packaging), $"Package info load failed: could not load asset from path \"{path}\".");

                return packageInfo;
            }
        }
    }
}