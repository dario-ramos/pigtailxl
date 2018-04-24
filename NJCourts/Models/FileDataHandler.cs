using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace NJCourts.Models
{
    public class FileDataHandler
    {
        public event Action CountiesRead;
        public event Action DateFiltersRead;
        public event Action DocketYearRead;
        public event Action<bool> DateFilterStateRead;
        public event Action<bool> ZipCodeFilterStateRead;
        public event Action<County> CountyUpdated;
        public event Action<string> Error;
        public event Action<string> Warning;

        private const string ZIP_LISTS_SUBFOLDER = "ZipLists";
        private DateTime _lastRead;
        private Dictionary<string, List<string>> _zipCodeLists;
        private FileSystemWatcher _countiesWatcher;
        private string _currentZipListName;

        public FileDataHandler()
        {
            Counties = new List<County>();
            DateFiledFrom = null;
            DateFiledTo = null;
            _zipCodeLists = new Dictionary<string, List<string>>();
            _zipCodeLists[Constants.Placeholders.NEW_ZIP_LIST] = new List<string>();
            _lastRead = DateTime.MinValue;
            _countiesWatcher = new FileSystemWatcher();
        }

        public DateTime? DateFiledFrom
        {
            get;
            private set;
        }

        public DateTime? DateFiledTo
        {
            get;
            private set;
        }

        public int DocketYear
        {
            get;
            private set;
        }

        public List<County> Counties
        {
            get;
            private set;
        }

        public List<string> CurrentZipListValues
        {
            get
            {
                return _zipCodeLists[_currentZipListName];
            }
        }

        public List<string> ZipCodeFilters
        {
            get
            {
                return _zipCodeLists[_currentZipListName];
            }
        }

        public List<string> ZipListNames
        {
            get
            {
                return _zipCodeLists.Keys.ToList();
            }
        }

        public string CurrentZipList
        {
            get
            {
                return _currentZipListName;
            }
            set
            {
                _currentZipListName = value;
            }
        }

        public void ApplyFilters(List<County> selectedCounties)
        {
            SaveSelectedCounties(selectedCounties);
        }

        public void DeleteCurrentZipList()
        {
            if (CurrentZipList.Equals(Constants.Placeholders.NEW_ZIP_LIST))
            {
                return;
            }
            string fileToDelete = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), ZIP_LISTS_SUBFOLDER, CurrentZipList + ".txt");
            _zipCodeLists.Remove(CurrentZipList);
            File.Delete(fileToDelete);
            CurrentZipList = Constants.Placeholders.NEW_ZIP_LIST;
        }

        public void Init()
        {
            //Counties file watcher
            _countiesWatcher.Path = Configuration.GetSetting(Configuration.INPUT_DIRECTORY);
            _countiesWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                            | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            _countiesWatcher.Filter = "*.txt";
            _countiesWatcher.Changed += OnCountyFileChanged;
            _countiesWatcher.EnableRaisingEvents = true;
        }

        public void ReadData()
        {
            if (!Directory.Exists(Configuration.GetSetting(Configuration.INPUT_DIRECTORY)))
            {
                Error?.Invoke("Input directory " + Configuration.GetSetting(Configuration.INPUT_DIRECTORY) + " does not exist");
                return;
            }
            ReadZipCodeFilterState();
            ReadZipCodeFilters();
            ReadDateFilterState();
            ReadDateFilter();
            ReadDocketYear();
            ReadCounties();
        }

        public void SaveCurrentZipList()
        {
            string zipCodeFiltersFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), Configuration.GetSetting(Configuration.ZIP_CODE_FILTERS_FILE));
            File.WriteAllText(zipCodeFiltersFilePath, CurrentZipList);
        }

        public void SaveDateFilterState(bool enabled)
        {
            SaveBooleanSetting(Configuration.GetSetting(Configuration.DATE_FILTERS_STATE_FILE), enabled);
        }

        public void SaveDocketYear(int docketYear)
        {
            string settingFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), Configuration.GetSetting(Configuration.DOCKET_YEAR_FILE));
            using (StreamWriter file = new StreamWriter(settingFilePath, false))
            {
                file.WriteLine(docketYear);
            }
        }

        public void SaveZipCodeFilterState(bool enabled)
        {
            SaveBooleanSetting(Configuration.GetSetting(Configuration.ZIP_CODE_FILTER_STATE_FILE), enabled);
        }

        public void SaveZipCodeList(string listName, IEnumerable<string> zipCodes)
        {
            string listFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), ZIP_LISTS_SUBFOLDER, listName + ".txt");
            File.WriteAllText(listFilePath, string.Join(Constants.Placeholders.MULTIVALUE_FILTER_SEPARATOR.ToString(), zipCodes));
            _zipCodeLists[Path.GetFileNameWithoutExtension(listFilePath)] = zipCodes.ToList();
            CurrentZipList = listName;
        }

        private DateTime? ParseDate(string dateString, string dateVariableName)
        {
            DateTime date;
            if (DateTime.TryParseExact(dateString, Configuration.GetSetting(Configuration.DATE_FILTERS_FORMAT), CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            }
            else
            {
                Warning?.Invoke("Invalid " + dateVariableName + " date " + dateString);
                return null;
            }
        }

        /**
         * Event handler for when a county file's contents change
         * */
        private void OnCountyFileChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
                var selectedCounties = ReadSelectedCounties();
                lock (e)
                {
                    if (e.ChangeType == WatcherChangeTypes.Changed)
                    {
                        var now = DateTime.Now;
                        var lastWriteTime = File.GetLastWriteTime(e.FullPath);

                        string fileName = Path.GetFileNameWithoutExtension(e.FullPath);
                        if (!fileName.StartsWith("_"))
                        {
                            County toUpdate = ReadCounty(e.FullPath, selectedCounties);
                            if (toUpdate == null)
                            {
                                return;
                            }
                            foreach (var county in Counties)
                            {
                                if (county.Name == toUpdate.Name)
                                {
                                    county.Code = toUpdate.Code;
                                    county.Processed = toUpdate.Processed;
                                    CountyUpdated?.Invoke(county);
                                }
                            }
                        }
                        // do something...
                        _lastRead = lastWriteTime;
                    }
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke(ex.Message);
            }
        }

        private void ReadBooleanSetting(string settingFileName, Action<bool> callback)
        {
            string settingFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), settingFileName);
            if (!File.Exists(settingFilePath))
            {
                Warning?.Invoke("Setting file " + settingFilePath + " does not exist, will be created with false value");
                using (StreamWriter file = new StreamWriter(settingFilePath, false))
                {
                    file.WriteLine("false");
                }
                callback?.Invoke(false);
            }
            else
            {
                string state = File.ReadAllText(settingFilePath);
                callback?.Invoke(state.Trim() == "true");
            }
        }

        /**
         * Read county information from a specific file
         * Check file last write time to discard duplicate events
         */
        private County ReadCounty(string filePath, HashSet<string> selectedCounties)
        {
            const string DONE_SUFFIX = "|Done";
            string fileName = Path.GetFileName(filePath);
            if (fileName != Configuration.GetSetting(Configuration.ZIP_CODE_FILTERS_FILE) && fileName != Configuration.GetSetting(Configuration.DATE_FILTERS_FILE) && !fileName.StartsWith("_"))
            {
                string county = "";
                using (FileStream countyFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader countyFileReader = new StreamReader(countyFileStream))
                    {
                        county = countyFileReader.ReadToEnd();
                    }
                }
                if (string.IsNullOrWhiteSpace(county))
                {
                    return null;
                }
                county = county.Replace(Environment.NewLine, "");
                bool processed = county.EndsWith(DONE_SUFFIX);
                string countyName = Path.GetFileNameWithoutExtension(fileName);
                return new County
                {
                    Code = processed ? int.Parse(county.Replace(DONE_SUFFIX, "")) : int.Parse(county),
                    Name = countyName,
                    Processed = processed,
                    Selected = selectedCounties.Contains(countyName)
                };
            }
            return null;
        }

        /**
         * Read all county files
         */
        private void ReadCounties()
        {
            var selectedCounties = ReadSelectedCounties();
            //Read county files
            foreach (string filePath in Directory.EnumerateFiles(Configuration.GetSetting(Configuration.INPUT_DIRECTORY)))
            {
                County county = ReadCounty(filePath, selectedCounties);
                if (county != null)
                {
                    Counties.Add(county);
                }
            }
            CountiesRead?.Invoke();
        }

        /**
         * Read date filter from file. If file does not exist, create it empty.
         * If an invalid date is read, warn and continue. When two are read, notify
         */
        private void ReadDateFilter()
        {
            string dateFilterFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), Configuration.GetSetting(Configuration.DATE_FILTERS_FILE));
            if (!File.Exists(dateFilterFilePath))
            {
                Warning?.Invoke("Date filters file " + dateFilterFilePath + " does not exist, will be created empty");
                File.Create(dateFilterFilePath);
            }
            string s = File.ReadAllText(dateFilterFilePath);
            if (string.IsNullOrWhiteSpace(s))
            {
                DateFiltersRead?.Invoke();
                return;
            }
            string[] dateStrings = s.Split(',');
            if (dateStrings.Length >= 1 && DateFiledFrom == null)
            {
                DateFiledFrom = ParseDate(dateStrings[0], "from");
            }
            if (dateStrings.Length >= 2 && DateFiledTo == null)
            {
                DateFiledTo = ParseDate(dateStrings[1], "to");
            }
            DateFiltersRead?.Invoke();
        }

        private void ReadDateFilterState()
        {
            ReadBooleanSetting(Configuration.GetSetting(Configuration.DATE_FILTERS_STATE_FILE), DateFilterStateRead);
        }

        private void ReadDocketYear()
        {
            string docketYearFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), Configuration.GetSetting(Configuration.DOCKET_YEAR_FILE));
            if (!File.Exists(docketYearFilePath))
            {
                Warning?.Invoke("Docket year file " + docketYearFilePath + " does not exist, will be created empty");
                File.Create(docketYearFilePath).Close();
            }
            string s = File.ReadAllText(docketYearFilePath);
            if (string.IsNullOrWhiteSpace(s))
            {
                DocketYearRead?.Invoke();
                return;
            }
            DocketYear = int.Parse(s);
            DocketYearRead?.Invoke();
        }

        private HashSet<string> ReadSelectedCounties()
        {
            string selectedCountiesFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), Configuration.GetSetting(Configuration.SELECTED_COUNTIES_FILE));
            if (!File.Exists(selectedCountiesFilePath))
            {
                Warning?.Invoke("Selected counties file " + selectedCountiesFilePath + " does not exist, will be created empty");
                File.Create(selectedCountiesFilePath);
            }
            return new HashSet<string>(File.ReadAllLines(selectedCountiesFilePath));
        }

        ///<summary>
        /// Read zip code filters from file. If file does not exist, create it empty.
        /// If a non numeric zip is read, warn and continue
        ///</summary>
        private void ReadZipCodeFilters()
        {
            ReadZipCodeLists();
            string zipCodeFiltersFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), Configuration.GetSetting(Configuration.ZIP_CODE_FILTERS_FILE));
            if (!File.Exists(zipCodeFiltersFilePath))
            {
                Warning?.Invoke("Zip file " + zipCodeFiltersFilePath + " does not exist, will be created empty");
                File.Create(zipCodeFiltersFilePath);
            }
            string zipCodeFilters = File.ReadAllText(zipCodeFiltersFilePath);
            if (string.IsNullOrWhiteSpace(zipCodeFilters))
            {
                return;
            }
            _currentZipListName = zipCodeFilters.Trim();
        }

        private void ReadZipCodeFilterState()
        {
            ReadBooleanSetting(Configuration.GetSetting(Configuration.ZIP_CODE_FILTER_STATE_FILE), ZipCodeFilterStateRead);
        }

        private void ReadZipCodeLists()
        {
            string zipListDir = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), ZIP_LISTS_SUBFOLDER);
            IEnumerable<string> zipListFiles = Directory.EnumerateFiles(zipListDir, "*.txt");
            foreach(string zipListName in zipListFiles)
            {
                string zips = File.ReadAllText(zipListName);
                _zipCodeLists[Path.GetFileNameWithoutExtension(zipListName)] = zips.Split(Constants.Placeholders.MULTIVALUE_FILTER_SEPARATOR).ToList();
            }
        }

        private void SaveBooleanSetting(string settingFileName, bool enabled)
        {
            string settingFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), settingFileName);
            using (StreamWriter file = new StreamWriter(settingFilePath, false))
            {
                file.WriteLine(enabled ? "true" : "false");
            }
        }

        private void SaveDateFilter(Tuple<DateTime?, DateTime?> dateFilter)
        {
            string dateFrom = dateFilter.Item1.HasValue ? dateFilter.Item1.Value.ToString(Configuration.GetSetting(Configuration.DATE_FILTERS_FORMAT)) : "";
            string dateTo = dateFilter.Item2.HasValue ? dateFilter.Item2.Value.ToString(Configuration.GetSetting(Configuration.DATE_FILTERS_FORMAT)) : "";
            string toSave = dateFrom + "," + dateTo;
            string dateFilterFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), Configuration.GetSetting(Configuration.DATE_FILTERS_FILE));
            File.WriteAllText(dateFilterFilePath, toSave);
        }

        private void SaveSelectedCounties(List<County> selectedCounties)
        {
            string selectedCountiesFilePath = Path.Combine(Configuration.GetSetting(Configuration.INPUT_DIRECTORY), Configuration.GetSetting(Configuration.SELECTED_COUNTIES_FILE));
            File.WriteAllLines(selectedCountiesFilePath, selectedCounties.Select(county => county.Name).ToArray());
        }

    }
}
