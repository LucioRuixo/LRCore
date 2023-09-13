using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LRCore.Packaging
{
    public class ReleaseHistory : ScriptableObject
    {
        #region Constants
        public const string AssetName = "ReleaseHistory";
        public const string AssetPath = AssetName;
        #endregion

        public SortedDictionary<VersionNumber, Release> History { get; private set; } = new();

        public bool IsEmpty => History.Count == 0;

        public VersionNumber LatestVersion => History != null && !IsEmpty ? History.Last().Key : null;
        public Release LatestRelease => History != null && !IsEmpty ? History.Last().Value : null;

        public bool AddNewRelease(VersionNumber versionNumber, Release release)
        {
            if (versionNumber == VersionNumber.Zero)
            {
                Logger.LogError(typeof(ReleaseHistory), $"Can not add new release: version number must be higher than 0.0.0.");
                return false;
            }
            else if (!IsEmpty && versionNumber <= LatestVersion)
            {
                Logger.LogError(typeof(ReleaseHistory), $"Can not add new release: version number {versionNumber} is not higher than last release's.");
                return false;
            }

            History.Add(versionNumber, release);
            return true;
        }

        public void Clear() => History.Clear();
    }
}