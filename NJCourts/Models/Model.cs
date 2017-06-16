using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

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
            StopProcess();
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
            var stopFile = File.Create(Configuration.StopFilePath);
            stopFile.Close();
            StoppingProcess?.Invoke();
            Process[] processes = Process.GetProcessesByName(Configuration.ProcessName);
            foreach(Process p in processes)
            {
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
            using (StreamReader sr = File.OpenText(dateFilterFilePath))
            {
                string line = string.Empty;
                int iLine = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    DateTime date;
                    if (DateTime.TryParseExact(line, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        if(DateFiledFrom == null)
                        {
                            DateFiledFrom = date;
                        }else if(DateFiledTo == null)
                        {
                            DateFiledTo = date;
                            break;
                        }
                    }
                    else
                    {
                        Warning?.Invoke("Invalid date " + line + " in line " + iLine);
                    }
                    iLine++;
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
            using (StreamReader sr = File.OpenText(zipCodeFiltersFilePath))
            {
                string line = string.Empty;
                int iLine = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    int zipCodeFilter = -1;
                    if( int.TryParse(line, out zipCodeFilter))
                    {
                        ZipCodeFilters.Add(zipCodeFilter);
                    }else
                    {
                        Warning?.Invoke("Non numeric zip code " + line + " in line " + iLine);
                    }
                    iLine++;
                }
            }
            ZipCodeFiltersRead?.Invoke();
        }
    }
}
