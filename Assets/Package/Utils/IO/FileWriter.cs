using System.IO;

namespace LRCore.Utils.IO
{
    public static class FileWriter
    {
        public static void Write(string path, object value)
        {
            try
            {
                using (StreamWriter streamWriter = new(path))
                {
                    streamWriter.Write(value);
                    streamWriter.Close();
                }
            }
            catch (System.Exception exception)
            {
                Logger.LogError(typeof(FileWriter), $"Could not write file: {exception.Message}.");
                throw;
            }
        }
    }
}