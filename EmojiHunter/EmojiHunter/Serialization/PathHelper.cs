using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace GameShadow.Serialization
{
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
