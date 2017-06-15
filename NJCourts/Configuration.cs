using System.Configuration;

namespace NJCourts
{
    public static class Configuration
    {
        public static string DateFiltersFile
        {
            get
            {
                return ConfigurationManager.AppSettings["DateFiltersFile"];
            }
        }

        public static string InputDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["InputDirectory"];
            }
        }

        public static string ZipCodeFiltersFile
        {
            get
            {
                return ConfigurationManager.AppSettings["ZipCodeFiltersFile"];
            }
        }
    }
}
