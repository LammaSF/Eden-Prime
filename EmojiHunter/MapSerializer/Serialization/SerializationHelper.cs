namespace MapSerializer.Serialization
{
    using System.IO;
    using System.Runtime.Serialization;

    public class SerializationHelper
    {
        public static void Serialize<T>(T instance, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                var xmlSerializer = new DataContractSerializer(typeof(T));
                xmlSerializer.WriteObject(fileStream, instance);
            }
        }

        public static T Deserialize<T>(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var xmlSerializer = new DataContractSerializer(typeof(T));
                return (T)xmlSerializer.ReadObject(fileStream);
            }
        }
    }
}
