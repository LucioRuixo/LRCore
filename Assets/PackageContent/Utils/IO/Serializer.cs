namespace LRCore.Utils.IO
{
    using Extensions;

    public class Serializer
    {
        public static void Serialize(string path, object value)
        {
            ExtTypes extType = Extension.GetExtension(path);

            if (extType == ExtTypes.Invalid || !Extension.ValidExts.ContainsKey(extType))
            {
                Logger.LogError(typeof(FileWriter), $"Could not serialize file to \"{path}\": extension is invalid.");
                return;
            }

            SerializableExtension ext = Extension.ValidExts[extType] as SerializableExtension;
            if (ext == null)
            {
                Logger.LogError(typeof(FileWriter), $"Could not serialize file to \"{path}\": extension is not serializable.");
                return;
            }

            ext.Serialize(path, value);
        }

        public static T Deserialize<T>(string path) where T : new()
        {
            ExtTypes extType = Extension.GetExtension(path);

            if (extType == ExtTypes.Invalid || !Extension.ValidExts.ContainsKey(extType))
            {
                Logger.LogError(typeof(FileReader), $"Could not deserialize file from \"{path}\": extension is invalid.");
                return new();
            }

            SerializableExtension ext = Extension.ValidExts[extType] as SerializableExtension;
            if (ext == null)
            {
                Logger.LogError(typeof(FileReader), $"Could not deserialize file from \"{path}\": extension is not serializable.");
                return new();
            }

            return ext.Deserialize<T>(path);
        }
    }
}