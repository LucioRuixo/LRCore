namespace LRCore.Utils.Extensions
{
    public abstract class Extension
    {
        public abstract string Ext { get; }

        public abstract bool HasExtension(string path);
    }

    #region Extensions
    public class Asset : Extension
    {
		public override string Ext { get; } = ".asset";

        public override bool HasExtension(string path) => path.EndsWith(Ext);
    }

    public class Data : Extension
    {
        public override string Ext { get; } = ".dat";

        public override bool HasExtension(string path) => path.EndsWith(Ext);
    }

    public class JSON : Extension
    {
        public override string Ext { get; } = ".json";

        public override bool HasExtension(string path) => path.EndsWith(Ext);
    }

    public class Text : Extension
    {
        public override string Ext { get; } = ".txt";

        public override bool HasExtension(string path) => path.EndsWith(Ext);
    }

    public class XML : Extension
    {
        public override string Ext { get; } = ".xml";

        public override bool HasExtension(string path) => path.EndsWith(Ext);
    }
    #endregion
}