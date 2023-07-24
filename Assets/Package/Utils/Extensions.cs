namespace LRCore.Utils
{
    public static class Extensions
    {
        public Asset Asset = new Asset();
    }

    #region Extensions
    public abstract class Extension
    {
        public abstract override string ToString();

        public bool HasExtension(string path) => path.EndsWith(ToString());
    }

    public class Asset : Extension
    {
        public override string ToString() => ".asset";
    }

    public class Text : Extension
    {
        public override string ToString() => ".txt";
    }
    #endregion
}