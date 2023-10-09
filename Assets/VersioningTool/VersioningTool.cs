using System.IO;

namespace LRCore.Packaging
{
    using Utils;

    public class VersioningTool
    {
        #region Constants
        private const string PackageContentFolder = "package";
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

                    Directory.CreateDirectory(buildContentPath);

                    string[] packageDirectories = Directory.GetDirectories(packageContentPath, "*", SearchOption.AllDirectories);
                    foreach (string directory in packageDirectories) Directory.CreateDirectory(directory.Replace(packageContentPath, buildContentPath));

                    string[] packageFiles = Directory.GetFiles(packageContentPath, "*", SearchOption.AllDirectories);
                    foreach (string file in packageFiles) File.Copy(file, file.Replace(packageContentPath, buildContentPath), true);

                    if (ReleaseHistory.AddNewRelease(versionNumber, release))
                    {
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
    }
}