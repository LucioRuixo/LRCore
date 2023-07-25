using System.Collections.Generic;

namespace LRCore.Utils
{
    public static class Extensions
    {
        #region Enumerators
        public enum Exts
        {
            Asset,
            Data,
            JSON,
            Text,
            XML
        }
        #endregion

        public static Dictionary<Exts, string> exts = new Dictionary<Exts, string>
        {
            [Exts.Asset, ".asset"],
        }
    }

    public static class Asset
    {
		public const string Extension = ".asset";
        public static bool HasExtension(string path) => path.EndsWith(Extension);
    }

    public static class Data
    {
        public const string Extension = ".dat";
        public static bool HasExtension(string path) => path.EndsWith(Extension);
    }

    public static class JSON
    {
        public const string Extension = ".json";
        public static bool HasExtension(string path) => path.EndsWith(Extension);
    }

    public static class Text
    {
        public const string Extension = ".txt";
        public static bool HasExtension(string path) => path.EndsWith(Extension);
    }

    public static class XML
    {
        public const string Extension = ".xml";¿
        public static bool HasExtension(string path) => path.EndsWith(Extension);
    }
}