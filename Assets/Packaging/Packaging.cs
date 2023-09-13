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

        public static ReleaseHistory ReleaseHistory
        {
            get
            {
                string path = ReleaseHistory.AssetPath;
                ReleaseHistory releaseHistory = Resources.Load<ReleaseHistory>(path);

                if (!releaseHistory) Logger.LogError(typeof(Packaging), $"Release history load failed: could not load asset from path \"{path}\".");

                return releaseHistory;
            }
        }
    }
}