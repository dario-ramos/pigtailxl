using System.Configuration;

namespace NJCourts
{
    public static class Configuration
    {
        public static string InputDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["InputDirectory"];
            }
        }
    }
}
