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
        public event Action<string> Error;
        public event Action<string> Warning;

        private bool _processRunning;

        /**
         * Constructor
         */
        public Model()
        {
            Counties = new List<County>();
            DateFiledFrom = null;
            DateFiledTo = null;
            ZipCodeFilters = new List<int>();
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
            }else
            {
                StartProcess();
            }
        }

        private void StartProcess()
        {
            Process.Start(Configuration.ProcessPath);
            ProcessStarted?.Invoke();
            _processRunning = true;
        }

        /**
         * Create file in control dir, disable filters and wait for process to end
         */
        private void StopProcess()
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
         * Read all county files
         */
        private void ReadCounties()
        {
            const string DONE_SUFFIX = "|Done";
            foreach (string filePath in Directory.EnumerateFiles(Configuration.InputDirectory))
            {
                string fileName = Path.GetFileName(filePath);
                if (fileName != Configuration.ZipCodeFiltersFile && fileName != Configuration.DateFiltersFile)
                {
                    string county = File.ReadAllText(filePath);
                    county = county.Replace(Environment.NewLine, "");
                    bool processed = county.EndsWith(DONE_SUFFIX);
                    Counties.Add(new County
                    {
                        Code = processed ? int.Parse(county.Replace(DONE_SUFFIX, "")) : int.Parse(county),
                        Name = Path.GetFileNameWithoutExtension(fileName),
                        Processed = processed
                    });
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
            if(dateStrings.Length >= 1)
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
            if (!File.Exists(zipCodeFiltersFilePath)){
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

        private void SaveDateFilter(Tuple<DateTime?,DateTime?> dateFilter)
        {
            string dateFrom = dateFilter.Item1.HasValue ? dateFilter.Item1.Value.ToString("dd/mm/yyyy") : "";
            string dateTo = dateFilter.Item2.HasValue ? dateFilter.Item2.Value.ToString("dd/mm/yyyy") : "";
            string toSave = dateFrom + ","  + dateTo;
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
