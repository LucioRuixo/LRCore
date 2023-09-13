using System.Collections.Generic;
using System.IO;

namespace LRCore.Packaging
{
    using Utils;

    public static class PackagingUtils
    {
        public const string ReleaseHistoryFileName = "ReleaseHistory";

        public static bool GetLatestValidVersion(out VersionNumber version, out VersionNumber[] invalidVersions)
        {
            version = null;
            invalidVersions = null;

            if (!File.Exists($"{Paths.projectFolder}/{ReleaseHistoryFileName}.json"))
            {
                Logger.LogError(typeof(PackagingUtils), $"Failed to get latest valid package version: {ReleaseHistoryFileName}.json");
                return false;
            }

            List<VersionNumber> invalidVersionList = new List<VersionNumber>();

            try
            {


            }
            catch (System.Exception)
            {

                throw;
            }

            return false;
        }
    }
}