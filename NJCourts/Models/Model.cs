using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace NJCourts.Models
{
    /**
     * Contains all the business logic
     */
    public class Model
    {
        public event Action CountiesRead;
        public event Action DateFilterRead;
        public event Action ProcessStarted;
        public event Action ProcessStopped;
        public event Action StoppingProcess;
        public event Action ZipCodeFiltersRead;
        public event Action<County> CountyUpdated;
        public event Action<string> Error;
        public event Action<string> Warning;

        private bool _processRunning;
        private DateTime _lastRead = DateTime.MinValue;
        private FileSystemWatcher _countiesWatcher;

        /**
         * Constructor
         */
        public Model()
        {
            Counties = new List<County>();
            DateFiledFrom = null;
            DateFiledTo = null;
            ZipCodeFilters = new List<int>();
            _countiesWatcher = new FileSystemWatcher();
            _countiesWatcher.Path = Configuration.InputDirectory;
            _countiesWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                            | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            _countiesWatcher.Filter = "*.txt";
            _countiesWatcher.Changed += OnCountyFileChanged;
            _countiesWatcher.EnableRaisingEvents = true;
            _lastRead = DateTime.MinValue;
        }

        /**
         * Beginning of date filter range
         */
        public DateTime? DateFiledFrom
        {
            get; private set;
        }

        /**
         * End date filter range
         */
        public DateTime? DateFiledTo
        {
            get; private set;
        }

        public List<County> Counties
        {
            get; private set;
        }

        /**
         * List of zip codes
         */
        public List<int> ZipCodeFilters
        {
            get; private set;
        }

        /**
         * Save filters to files
         */
        public void ApplyFilters(List<int> zipCodeFilters, Tuple<DateTime?, DateTime?> dateFilter)
        {
            SaveZipCodeFilters(zipCodeFilters);
            SaveDateFilter(dateFilter);
        }

        /**
         * Check if input directory exists 
         * Then, read all files
         */
        public void Init()
        {
            if (!Directory.Exists(Configuration.InputDirectory))
            {
                Error?.Invoke("Input directory " + Configuration.InputDirectory + " does not exist");
                return;
            }
            ReadZipCodeFilters();
            ReadDateFilter();
            ReadCounties();
            StopProcess();
        }

        /**
         * Start or stop process according to current state
         */
        public void StartStopProcess()
        {
            if (_processRunning)
            {
                StopProcess();
            }
            else
            {
                StartProcess();
            }
        }

        /**
         * Create file in control dir, disable filters and wait for process to end
         */
        public void StopProcess()
        {
            StoppingProcess?.Invoke();
            Process[] allProcesses = Process.GetProcesses();
            Process[] processes = Process.GetProcessesByName(Configuration.ProcessName);
            foreach (Process p in processes)
            {
                if (!File.Exists(Configuration.StopFilePath))
                {
                    var stopFile = File.Create(Configuration.StopFilePath);
                    stopFile.Close();
                }
                p.WaitForExit();
            }
            _processRunning = false;
            ProcessStopped?.Invoke();
        }

        /**
         * Event handler for when a file's contents change
         * */
        private void OnCountyFileChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
                lock (e)
                {
                    if (e.ChangeType == WatcherChangeTypes.Changed)
                    {
                        var now = DateTime.Now;
                        var lastWriteTime = File.GetLastWriteTime(e.FullPath);

                        string fileName = Path.GetFileNameWithoutExtension(e.FullPath);
                        if (!fileName.StartsWith("_"))
                        {
                            County toUpdate = ReadCounty(e.FullPath);
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

        private void StartProcess()
        {
            Process.Start(Configuration.ProcessPath);
            ProcessStarted?.Invoke();
            _processRunning = true;
        }

        /**
         * Read all county files
         */
        private void ReadCounties()
        {

            foreach (string filePath in Directory.EnumerateFiles(Configuration.InputDirectory))
            {
                County county = ReadCounty(filePath);
                if (county != null)
                {
                    Counties.Add(county);
                }
            }
            CountiesRead?.Invoke();
        }

        /**
         * Read county information from a specific file
         * Check file last write time to discard duplicate events
         */
        private County ReadCounty(string filePath)
        {
            const string DONE_SUFFIX = "|Done";
            string fileName = Path.GetFileName(filePath);
            if (fileName != Configuration.ZipCodeFiltersFile && fileName != Configuration.DateFiltersFile)
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
                return new County
                {
                    Code = processed ? int.Parse(county.Replace(DONE_SUFFIX, "")) : int.Parse(county),
                    Name = Path.GetFileNameWithoutExtension(fileName),
                    Processed = processed
                };
            }
            return null;
        }

        /**
         * Read date filter from file. If file does not exist, create it empty.
         * If an invalid date is read, warn and continue. When two are read, notify
         */
        private void ReadDateFilter()
        {
            string dateFilterFilePath = Path.Combine(Configuration.InputDirectory, Configuration.DateFiltersFile);
            if (!File.Exists(dateFilterFilePath))
            {
                Warning?.Invoke("Date filters file " + dateFilterFilePath + " does not exist, will be created empty");
                File.Create(dateFilterFilePath);
            }
            string s = File.ReadAllText(dateFilterFilePath);
            if (string.IsNullOrWhiteSpace(s))
            {
                DateFilterRead?.Invoke();
                return;
            }
            string[] dateStrings = s.Split(',');
            if (dateStrings.Length >= 1)
            {
                DateTime date;
                if (DateTime.TryParseExact(dateStrings[0], "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    if (DateFiledFrom == null)
                    {
                        DateFiledFrom = date;
                    }
                }
                else
                {
                    Warning?.Invoke("Invalid from date " + dateStrings[0]);
                }
            }
            if (dateStrings.Length >= 2)
            {
                DateTime date;
                if (DateTime.TryParseExact(dateStrings[1], "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    if (DateFiledTo == null)
                    {
                        DateFiledTo = date;
                    }
                }
                else
                {
                    Warning?.Invoke("Invalid to date " + dateStrings[1]);
                }
            }
            DateFilterRead?.Invoke();
        }

        /**
         * Read zip code filters from file. If file does not exist, create it empty.
         * If a non numeric zip is read, warn and continue. When all are read, notify
         */
        private void ReadZipCodeFilters()
        {
            string zipCodeFiltersFilePath = Path.Combine(Configuration.InputDirectory, Configuration.ZipCodeFiltersFile);
            if (!File.Exists(zipCodeFiltersFilePath))
            {
                Warning?.Invoke("Zip file " + zipCodeFiltersFilePath + " does not exist, will be created empty");
                File.Create(zipCodeFiltersFilePath);
            }
            string zipCodeFilters = File.ReadAllText(zipCodeFiltersFilePath);
            if (string.IsNullOrWhiteSpace(zipCodeFilters))
            {
                ZipCodeFiltersRead?.Invoke();
                return;
            }
            ZipCodeFilters = zipCodeFilters.Split(',').Select(Int32.Parse).ToList();
            ZipCodeFiltersRead?.Invoke();
        }

        private void SaveDateFilter(Tuple<DateTime?, DateTime?> dateFilter)
        {
            string dateFrom = dateFilter.Item1.HasValue ? dateFilter.Item1.Value.ToString("dd/mm/yyyy") : "";
            string dateTo = dateFilter.Item2.HasValue ? dateFilter.Item2.Value.ToString("dd/mm/yyyy") : "";
            string toSave = dateFrom + "," + dateTo;
            string dateFilterFilePath = Path.Combine(Configuration.InputDirectory, Configuration.DateFiltersFile);
            File.WriteAllText(dateFilterFilePath, toSave);
        }

        private void SaveZipCodeFilters(List<int> zipCodeFilters)
        {
            string toSave = string.Join(",", zipCodeFilters);
            string zipCodeFiltersFilePath = Path.Combine(Configuration.InputDirectory, Configuration.ZipCodeFiltersFile);
            File.WriteAllText(zipCodeFiltersFilePath, toSave);
        }
    }
}
