using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MBox
{
    internal static class Serial
    {
        internal static bool Serialize<T>(string file, T content) where T : class
        {
            var bformatter = new BinaryFormatter();

            using (Stream stream = File.Open(file, FileMode.Create))
            {
                bformatter.Serialize(stream, content);
            }

            return true;
        }

        internal static T Deserialize<T>(string file) where T : class
        {
            var bformatter = new BinaryFormatter();
            using (Stream stream = File.Open(file, FileMode.Open))
            {
                var deserialised = bformatter.Deserialize(stream);
                if (deserialised is T)
                    return (deserialised as T);
                var message = string.Format("{0} (file) != {1} (T)", deserialised.GetType(), typeof(T));
                throw new ArgumentException(message, "file");
            }
        }
    }
}
