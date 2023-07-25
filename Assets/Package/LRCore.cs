namespace LRCore
{
    using Utils.Extensions;

    public static class LRCore
    {
        #region Constants
        public const string Signature = "LRCore";
        #endregion

        #region Structures
        public struct Extensions
        {
            public Asset Asset { get; }
            public Data Data { get; }
            public JSON JSON { get; }
            public Text Text { get; }
            public XML XML { get; }
        }
        #endregion

        #region Static Properties
        public static Extensions Exts { get; }
        #endregion

        static LRCore()
        {
            Exts = new Extensions();
        }
    }
}