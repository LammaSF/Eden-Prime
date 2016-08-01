namespace MapSerializer.Serialization
{
    using System.IO;
    using System.Reflection;

    public static class PathHelper
    {
        public static string GetDataFilePath(string relativeFilePath)
        {
            string dataFilePath;
            var assemblyFilePath = Assembly.GetEntryAssembly().Location;
            var assemblyFolder = Path.GetDirectoryName(assemblyFilePath);
            dataFilePath = Path.Combine(assemblyFolder, relativeFilePath);

            return dataFilePath;
        }
    }
}
