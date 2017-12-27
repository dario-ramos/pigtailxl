using System.Configuration;

namespace NJCourts
{
    public static class Configuration
    {
        public const string CONNECTION_STRING = "ConnectionString";
        public const string DATE_FILTERS_FILE = "DateFiltersFile";
        public const string DATE_FILTERS_FORMAT = "DateFiltersFormat";
        public const string DATE_FILTERS_STATE_FILE = "DateFiltersStateFile";
        public const string DOCKET_YEAR_FILE = "DocketYearFile";
        public const string EXCEL_EXPORT_DIR = "ExcelExportDir";
        public const string INPUT_DIRECTORY = "InputDirectory";
        public const string PROCESS_NAME = "ProcessName";
        public const string PROCESS_PATH = "ProcessPath";
        public const string SELECTED_COUNTIES_FILE = "SelectedCountiesFile";
        public const string STOP_FILE_PATH = "StopFilePath";
        public const string ZIP_CODE_FILTER_STATE_FILE = "ZipCodeFilterStateFile";
        public const string ZIP_CODE_FILTERS_FILE = "ZipCodeFiltersFile";

        public static string GetSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }
    }
}
