using System.IO;

namespace LRCore.Utils.IO
{
    public static class FileReader
    {
        public static string Read(string path)
        {
            string content = "";

            try
            {
                using (StreamReader streamReader = new(path))
                {
                    content = streamReader.ReadToEnd();
                    streamReader.Close();
                }

                return content;
            }
            catch (System.Exception exception)
            {
                Logger.LogError(typeof(FileReader), $"Could not read file: {exception.Message}.");
                throw;
            }
        }

        public static bool Read(string path, out string content)
        {
            content = "";

            try
            {
                using (StreamReader streamReader = new(path))
                {
                    content = streamReader.ReadToEnd();
                    streamReader.Close();
                }

                return true;
            }
            catch (System.Exception exception)
            {
                Logger.LogError(typeof(FileReader), $"Could not read file: {exception.Message}.");
                return false;
            }
        }

        public static bool Read(string path, out FileStream content)
        {
            try
            {
                content = new(path, FileMode.Open);
                return true;
            }
            catch (System.Exception exception)
            {
                Logger.LogError(typeof(FileReader), $"Could not read file: {exception.Message}.");

                content = null;
                return false;
            }
        }
    }
}