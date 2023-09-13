namespace LRCore.Utils.Extensions
{
    public abstract class Extension
    {
        public abstract string Ext { get; }

        public abstract bool HasExtension(string path);

        public static implicit operator string(Extension extension) => extension.Ext;
    }

    #region Extensions
    public class Asset : Extension
    {
		public override string Ext => ".asset";

        public override bool HasExtension(string path) => path.EndsWith(Ext);
    }

    public class Data : Extension
    {
        public override string Ext => ".dat";

        public override bool HasExtension(string path) => path.EndsWith(Ext);
    }

    public class JSON : Extension
    {
        public override string Ext => ".json";

        public override bool HasExtension(string path) => path.EndsWith(Ext);
    }

    public class Text : Extension
    {
        public override string Ext => ".txt";

        public override bool HasExtension(string path) => path.EndsWith(Ext);
    }

    public class XML : Extension
    {
        public override string Ext => ".xml";

        public override bool HasExtension(string path) => path.EndsWith(Ext);
    }
    #endregion
}