using System;

namespace LRCore.Packaging
{
    [Serializable]
    public class VersionNumber
    {
        private uint major;
        private uint minor;
        private uint patch;

        public VersionNumber(uint major, uint minor, uint patch)
        {
            this.major = major;
            this.minor = minor;
            this.patch = patch;
        }

        public void IncreasePatch() => patch++;

        public void IncreaseMinor()
        {
            minor++;
            patch = 0;
        }

        public void IncreaseMajor()
        {
            major++;
            minor = patch = 0;
        }

        #region Overrides
        public override string ToString() => $"{major}.{minor}.{patch}";
        #endregion
    }

    [Serializable]
    public class ReleaseData
    {
        private VersionNumber version;

        public ReleaseData(VersionNumber version) => this.version = version;
    }
}