using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace LRCore.Utils.Extensions
{
    using IO;

    public enum ExtTypes
    {
        Invalid,
        Asset,
        Data,
        JSON,
        Text,
        XML
    }

    public abstract class Extension
    {
        public abstract ExtTypes ExtType { get; }
        public abstract string Ext { get; }

        public static Dictionary<ExtTypes, Extension> ValidExts { get; } = new Dictionary<ExtTypes, Extension>()
        {
            { ExtTypes.Data, new Data() },
            { ExtTypes.JSON, new JSON() },
            { ExtTypes.Text, new Text() },
            { ExtTypes.XML, new XML() }
        };

        public bool HasExtension(string path) => path.EndsWith(Ext);

        public static ExtTypes GetExtension(string path)
        {
            string extensionString = Path.GetExtension(path);

            if (string.IsNullOrEmpty(extensionString))
            {
                Logger.LogError(typeof(Extension), $"Could not get extension: path \"{path}\" does not have extension information.");
                return ExtTypes.Invalid;
            }

            return ValidExts.Values.FirstOrDefault(extension => extension.Ext == extensionString).ExtType;
        }

        #region Operators
        public static implicit operator string(Extension extension) => extension.Ext;
        #endregion
    }

    public abstract class SerializableExtension : Extension
    {
        public abstract void Serialize<T>(string path, T value);

        public abstract T Deserialize<T>(string path) where T : new();
    }

    #region Extensions
    public class Data : SerializableExtension
    {
        public override ExtTypes ExtType => ExtTypes.Data;
        public override string Ext => ".dat";

        public override void Serialize<T>(string path, T value)
        {
            try
            {
                using (FileStream fileStream = new(path, FileMode.OpenOrCreate))
                {
                    new BinaryFormatter().Serialize(fileStream, value);
                    fileStream.Close();
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(this, $"Could not serialize data: {exception.Message}");
                throw;
            }
        }

        public override T Deserialize<T>(string path)
        {
            if (FileReader.Read(path, out FileStream fileStream))
            {
                T value = (T)new BinaryFormatter().Deserialize(fileStream);
                fileStream.Close();

                return value;
            }
            else return new();
        }
    }

    public class JSON : SerializableExtension
    {
        public override ExtTypes ExtType => ExtTypes.JSON;
        public override string Ext => ".json";

        public override void Serialize<T>(string path, T value) => FileWriter.Write(path, JsonConvert.SerializeObject(value, Formatting.Indented));

        public override T Deserialize<T>(string path)
        {
            if (FileReader.Read(path, out string content)) return JsonConvert.DeserializeObject<T>(content);
            else return new();
        }
    }

    public class Text : Extension
    {
        public override ExtTypes ExtType => ExtTypes.Text;
        public override string Ext => ".txt";
    }

    public class XML : SerializableExtension
    {
        public override ExtTypes ExtType => ExtTypes.XML;
        public override string Ext => ".xml";

        public override void Serialize<T>(string path, T value)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            new XmlSerializer(typeof(T)).Serialize(fileStream, value);
            fileStream.Close();
        }

        public override T Deserialize<T>(string path)
        {
            FileReader.Read(path, out FileStream fileStream);
            T value = (T)new XmlSerializer(typeof(T)).Deserialize(fileStream);
            fileStream.Close();

            return value;
        }
    }
    #endregion
}