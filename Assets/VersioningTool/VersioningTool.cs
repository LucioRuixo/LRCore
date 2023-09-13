using System.IO;

namespace LRCore.Packaging
{
    public class VersioningTool
    {
		public static bool CreateNewRelease(ReleaseHistory releaseHistory, VersionNumber versionNumber)
        {
            Release release = new($"v{versionNumber}");

            if (!Directory.Exists(release.BuildPath))
            {
                try
                {
                    Directory.CreateDirectory(release.BuildPath);

                    if (releaseHistory.AddNewRelease(versionNumber, release))
                    {
                        Logger.Log(typeof(VersioningTool), $"New version {versionNumber} release successfully created in path \"{release.BuildPath}\"!");
                        return true;
                    }
                    else
                    {
                        Directory.Delete(release.BuildPath);

                        Logger.LogError(typeof(VersioningTool), "Can not create new release: release could not be added to release history.");
                        return false;
                    }
                }
                catch (IOException exception)
                {
                    throw new IOException(exception.Message);
                }
            }
            else
            {
                Logger.LogError(typeof(VersioningTool), $"Can not create new release: directory with path \"{release.BuildPath}\" already exists.");
                return false;
            }
        }
    }
}