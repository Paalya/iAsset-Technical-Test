using System.IO;
using System.Linq;
using System.Reflection;

namespace WeatherApp.BusinessLogic.Helper
{
    internal class JsonHelper
    {
        /// <summary>
        /// Reads the json that is embedded as a resource
        /// </summary>
        /// <param name="name">file name</param>
        /// <returns>returns the file contents</returns>
        internal static string ReadDataFromResource(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();
            var resourceName = resources.Single(r => r.Contains(name));
            string result = string.Empty;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
