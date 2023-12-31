using System.IO;

namespace LRCore.Packaging
{
    using Utils;
    using Utils.Extensions;

    public class VersioningTool
    {
        #region Constants
        public const string PackageContentFolder = "package";
        #endregion

        public static bool CreateNewRelease(VersionNumber versionNumber)
        {
            Release release = new($"v{versionNumber}");

            if (!Directory.Exists(release.BuildPath))
            {
                string buildContentPath = $"{release.BuildPath}/{PackageContentFolder}";

                try
                {
                    string packageContentPath = Paths.packageFolder;

                    CopyPackageContent(packageContentPath, buildContentPath);

                    if (ReleaseHistory.AddNewRelease(versionNumber, release))
                    {
                        CreatePackageManifest(ReleaseHistory.LatestVersion);

                        Logger.Log(typeof(VersioningTool), $"New version {versionNumber} release successfully created in path \"{release.BuildPath}\"!");
                        return true;
                    }
                    else
                    {
                        Directory.Delete(release.BuildPath);

                        Logger.LogError(typeof(VersioningTool), "Could not create new release: release could not be added to release history.");
                        return false;
                    }
                }
                catch (IOException exception)
                {
                    if (Directory.Exists(release.BuildPath)) Directory.Delete(release.BuildPath, true);
                    throw new IOException(exception.Message);
                }
            }
            else
            {
                Logger.LogError(typeof(VersioningTool), $"Could not create new release: directory with path \"{release.BuildPath}\" already exists.");
                return false;
            }
        }

        private static void CopyPackageContent(string packageContentPath, string buildContentPath)
        {
            Directory.CreateDirectory(buildContentPath);

            string[] packageDirectories = Directory.GetDirectories(packageContentPath, "*", SearchOption.AllDirectories);
            foreach (string directory in packageDirectories) Directory.CreateDirectory(directory.Replace(packageContentPath, buildContentPath));

            string[] packageFiles = Directory.GetFiles(packageContentPath, "*", SearchOption.AllDirectories);
            foreach (string file in packageFiles) File.Copy(file, file.Replace(packageContentPath, buildContentPath), true);
        }

        private static void CreatePackageManifest(string latestVersion)
        {
            PackageManifestInfo packageManifestInfo = PackageManifestInfo.Get();

            if (!packageManifestInfo) return;

            string manifestPath = $"{Paths.buildsFolder}/v{latestVersion}/package/package.json";
            ((SerializableExtension)Extension.ValidExts[ExtTypes.JSON]).Serialize(manifestPath, packageManifestInfo);
        }
    }
}