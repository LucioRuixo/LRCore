using UnityEngine;

namespace LRCore.Packaging
{
    public static class Packaging
    {
		public static PackageInfo PackageInfo
        {
            get
            {
                string path = PackageInfo.AssetPath;
                PackageInfo packageInfo = Resources.Load<PackageInfo>(path);

                if (!packageInfo) Logger.LogError(typeof(Packaging), $"Package info load failed: could not load asset from path \"{path}\".");

                return packageInfo;
            }
        }
    }
}