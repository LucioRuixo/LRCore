using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LRCore.Packaging
{
    using History = SortedDictionary<VersionNumber, Release>;

    using Utils;
    using Utils.Extensions;
    using Utils.IO;

    public static class ReleaseHistory
    {
        #region Constants
        public const string HistoryFileName = "ReleaseHistory";
        public const ExtTypes HistoryFileExt = ExtTypes.JSON;
        #endregion

        private static readonly string historyFilePath = $"{Paths.projectFolder}/{HistoryFileName}{Extension.ValidExts[HistoryFileExt].Ext}";

        private static History history;
        public static History History
        {
            get
            {
                LoadHistory();
                return history;
            }

            private set => history = value;
        }

        public static bool IsEmpty => History.Count == 0;

        public static VersionNumber LatestVersion => History != null && !IsEmpty ? history.Last().Key : null;
        public static Release LatestRelease => History != null && !IsEmpty ? history.Last().Value : null;

        public static bool AddNewRelease(VersionNumber versionNumber, Release release)
        {
            if (versionNumber == VersionNumber.Zero)
            {
                Logger.LogError(typeof(ReleaseHistory), "Could not add new release: version number must be higher than 0.0.0.");
                return false;
            }
            else if (history != null && history.Count > 0 && versionNumber <= history.Last().Key)
            {
                Logger.LogError(typeof(ReleaseHistory), $"Could Can not add new release: version number {versionNumber} is not higher than last release's.");
                return false;
            }

            history.Add(versionNumber, release);
            SaveHistory();

            return true;
        }

        public static void Clear()
        {
            history.Clear();
            SaveHistory();
        }

        private static void SaveHistory() => Serializer.Serialize(historyFilePath, history);

        private static void LoadHistory()
        {
            try
            {
                if (File.Exists(historyFilePath)) history = Serializer.Deserialize<History>(historyFilePath);
                else
                {
                    history = new();
                    SaveHistory();
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(typeof(ReleaseHistory), $"Could not load release history from \"{historyFilePath}\": {exception.Message}");
                throw;
            }
        }
    }
}