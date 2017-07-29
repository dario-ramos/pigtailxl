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

        public static string ProcessName
        {
            get
            {
                return ConfigurationManager.AppSettings["ProcessName"];
            }
        }

        public static string ProcessPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ProcessPath"];
            }
        }

        public static string SelectedCountiesFile
        {
            get
            {
                return ConfigurationManager.AppSettings["SelectedCountiesFile"];
            }
        }

        public static string StopFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["StopFilePath"];
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
