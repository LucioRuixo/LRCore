using System;

namespace LRCore.Packaging
{
    using Utils;

    [Serializable]
    public class VersionNumber : IComparable
    {
        private uint major;
        private uint minor;
        private uint patch;

        public uint Major => major;
        public uint Minor => minor;
        public uint Patch => patch;

        public static VersionNumber Zero => new();

        public VersionNumber()
        {
            major = 0;
            minor = 0;
            patch = 0;
        }

        public VersionNumber(uint major, uint minor, uint patch)
        {
            this.major = major;
            this.minor = minor;
            this.patch = patch;
        }

        #region IComparable
        public int CompareTo(object other)
        {
            if (other == null) return 1;

            VersionNumber otherNumber = other as VersionNumber;

            if (otherNumber != null)
            {
                if (otherNumber.major < major) return 1;
                else if (otherNumber.major > major) return -1;
                else
                {
                    if (otherNumber.minor < minor) return 1;
                    else if (otherNumber.minor > minor) return -1;
                    else
                    {
                        if (otherNumber.patch < patch) return 1;
                        else if (otherNumber.patch > patch) return -1;

                        return 0;
                    }
                }
            }
            else throw new ArgumentException("Object is not a version number.");
        }
        #endregion

        public VersionNumber IncreasePatch()
        {
            patch++;
            return this;
        }

        public VersionNumber IncreaseMinor()
        {
            minor++;
            patch = 0;

            return this;
        }

        public VersionNumber IncreaseMajor()
        {
            major++;
            minor = patch = 0;

            return this;
        }

        public VersionNumber DecreasePatch()
        {
            patch--;
            return this;
        }

        public VersionNumber DecreaseMinor()
        {
            minor--;
            patch = 0;

            return this;
        }

        public VersionNumber DecreaseMajor()
        {
            major--;
            minor = patch = 0;

            return this;
        }

        #region Overrides
        public override string ToString() => $"{major}.{minor}.{patch}";

        public override bool Equals(object other)
        {
            VersionNumber otherNumber = other as VersionNumber;

            if (otherNumber != null) return this == otherNumber;
            else throw new ArgumentException("Object is not a version number.");
        }

        public override int GetHashCode() => base.GetHashCode();
        #endregion

        #region Operators
        #region Implicit
        public static implicit operator string(VersionNumber versionNumber) => versionNumber.ToString();
        #endregion

        #region Explicit
        public static explicit operator int(VersionNumber versionNumber) => (int)versionNumber.Patch;

        public static explicit operator uint(VersionNumber versionNumber) => versionNumber.Patch;

        public static explicit operator VersionNumber(int value) => new(0, 0, (uint)value);

        public static explicit operator VersionNumber(uint value) => new(0, 0, value);
        #endregion

        #region Arithmetic
        public static VersionNumber operator +(VersionNumber a, VersionNumber b) => new(a.Major, a.Minor, a.Patch + b.Patch);

        public static VersionNumber operator +(VersionNumber a, uint b) => new(a.Major, a.Minor, a.Patch + b);

        public static VersionNumber operator -(VersionNumber a, VersionNumber b) => new(a.Major, a.Minor, a.Patch - b.Patch);

        public static VersionNumber operator -(VersionNumber a, uint b) => new(a.Major, a.Minor, a.Patch - b);

        public static VersionNumber operator ++(VersionNumber versionNumber) => versionNumber + 1;

        public static VersionNumber operator --(VersionNumber versionNumber) => versionNumber - 1;
        #endregion

        #region Comparison
        public static bool operator ==(VersionNumber a, VersionNumber b)
        {
            object aObject = a;
            object bObject = b;

            if (aObject == null && bObject == null) return true;
            else if (aObject == null || bObject == null) return false;

            return a.major == b.major && a.minor == b.minor && a.patch == b.patch;
        }

        public static bool operator !=(VersionNumber a, VersionNumber b) => !(a == b);

        public static bool operator <(VersionNumber a, VersionNumber b)
        {
            if (a.major < b.major) return true;
            else if (a.major > b.major) return false;
            else
            {
                if (a.minor < b.minor) return true;
                else if (a.minor > b.minor) return false;
                else
                {
                    if (a.patch < b.patch) return true;

                    return false;
                }
            }
        }

        public static bool operator >(VersionNumber a, VersionNumber b)
        {
            if (a.major > b.major) return true;
            else if (a.major < b.major) return false;
            else
            {
                if (a.minor > b.minor) return true;
                else if (a.minor < b.minor) return false;
                else
                {
                    if (a.patch > b.patch) return true;

                    return false;
                }
            }
        }

        public static bool operator <=(VersionNumber a, VersionNumber b) => a == b || a < b;

        public static bool operator >=(VersionNumber a, VersionNumber b) => a == b || a > b;
        #endregion
        #endregion
    }

    [Serializable]
    public class Release
    {
        public string BuildPath { get; private set; }

        /// <summary>
        /// <param name="buildPath">Path inside Builds/ that leads to the contents of the release.</param>
        /// </summary>
        public Release(string buildPath) => BuildPath = $"{Paths.buildsFolder}/{buildPath}";
    }
}