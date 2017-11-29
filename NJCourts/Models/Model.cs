using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NJCourts.Models
{
    /**
     * Contains all the business logic
     */
    public class Model
    {
        public event Action DatabaseDataRead;
        public event Action FileCountiesRead;
        public event Action FileDateFilterRead;
        public event Action FileZipCodeFiltersRead;
        public event Action ProcessStarted;
        public event Action ProcessStopped;
        public event Action StoppingProcess;
        public event Action<bool> FileDateFilterStateRead;
        public event Action<bool> FileZipCodeFilterStateRead;
        public event Action<County> CountyFileUpdated;
        public event Action<string> Error;
        public event Action<string> Warning;

        private bool _processRunning;
        private DatabaseDataHandler _databaseDataHandler;
        private FileDataHandler _fileDataHandler;

        /**
         * Constructor
         */
        public Model()
        {
            _fileDataHandler = new FileDataHandler();
            _fileDataHandler.CountyUpdated += OnCountyFileUpdated;
            _fileDataHandler.CountiesRead += OnFileCountiesRead;
            _fileDataHandler.DateFiltersRead += OnFileDateFilterRead;
            _fileDataHandler.DateFilterStateRead += OnFileDateFilterStateRead;
            _fileDataHandler.Error += OnFileHandlerError;
            _fileDataHandler.Warning += OnFileHandlerWarning;
            _fileDataHandler.ZipCodeFiltersRead += OnFileZipCodeFiltersRead;
            _fileDataHandler.ZipCodeFilterStateRead += OnFileZipCodeFilterStateRead;
            _databaseDataHandler = new DatabaseDataHandler();
            _databaseDataHandler.DataLoaded += OnDatabaseDataLoaded;
        }

        public DataTable DatabaseData
        {
            get
            {
                return _databaseDataHandler.Data;
            }
        }

        /**
         * Beginning of date filter range
         */
        public DateTime? DateFiledFrom
        {
            get
            {
                return _fileDataHandler.DateFiledFrom;
            }
        }

        /**
         * End date filter range
         */
        public DateTime? DateFiledTo
        {
            get
            {
                return _fileDataHandler.DateFiledTo;
            }
        }

        public List<County> CountiesFromFiles
        {
            get
            {
                return _fileDataHandler.Counties;
            }
        }

        public List<string> Venues
        {
            get
            {
                return _databaseDataHandler.Venues;
            }
        }

        /**
         * List of zip codes
         */
        public List<string> ZipCodeFiltersFromFile
        {
            get
            {
                return _fileDataHandler.ZipCodeFilters;
            }
        }

        public string Filter
        {
            get
            {
                return _databaseDataHandler.Filter;
            }
        }

        /**
         * Save filters to files
         */
        public void ApplyFiltersFromFiles(List<County> selectedCounties)
        {
            _fileDataHandler.ApplyFilters(selectedCounties);
        }

        public void Export()
        {
            _databaseDataHandler.Export();
        }

        /**
         * Check if input directory exists 
         * Then, read all files
         */
        public void Init()
        {
            _fileDataHandler.ReadData();
            _databaseDataHandler.ReadData();
            StopProcess();
        }

        public void SaveFileDateFilterState(bool enabled)
        {
            _fileDataHandler.SaveDateFilterState(enabled);
        }

        public void SaveFileZipCodeFilterState(bool enabled)
        {
            _fileDataHandler.SaveZipCodeFilterState(enabled);
        }

        /// <summary>
        /// Configuring a comparison-type filter without applying it
        /// </summary>
        /// <param name="fieldName">Database field to compare</param>
        /// <param name="comparison">Comparison to perform</param>
        /// <param name="value1">First value to compare</param>
        /// <param name="value2">Second value to compare; only used for RANGE comparisons</param>
        public void SetFilterParemeters(string fieldName, Constants.Comparison comparison, string value1, string value2)
        {
            _databaseDataHandler.SetFilterParameters(fieldName, comparison, value1, value2);
        }

        /// <summary>
        /// Configure a multivalue filter (fieldName in (value1, value2, ...valueN) sql claise)
        /// </summary>
        /// <param name="fieldName">Database field to filter on</param>
        /// <param name="fieldValues">List of values; a row will match the filter if it contains any of these</param>
        public void SetFilterParemeters(string fieldName, List<string> fieldValues)
        {
            _databaseDataHandler.SetFilterParameters(fieldName, fieldValues);
        }

        /// <summary>
        /// Configure a text search field
        /// </summary>
        /// <param name="fieldName">Database field to filter on</param>
        /// <param name="fieldValue">If the field contains this text, it will match the filter</param>
        public void SetFilterParemeters(string fieldName, string fieldValue)
        {
            _databaseDataHandler.SetFilterParameters(fieldName, fieldValue);
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
            Process[] processes = Process.GetProcessesByName(Configuration.GetSetting(Configuration.PROCESS_NAME));
            foreach (Process p in processes)
            {
                if (!File.Exists(Configuration.GetSetting(Configuration.STOP_FILE_PATH)))
                {
                    var stopFile = File.Create(Configuration.GetSetting(Configuration.STOP_FILE_PATH));
                    stopFile.Close();
                }
                p.WaitForExit();
            }
            _processRunning = false;
            ProcessStopped?.Invoke();
        }

        private void OnCountyFileUpdated(County county)
        {
            CountyFileUpdated?.Invoke(county);
        }

        private void OnDatabaseDataLoaded()
        {
            DatabaseDataRead?.Invoke();
        }

        private void OnFileCountiesRead()
        {
            FileCountiesRead?.Invoke();
        }

        private void OnFileDateFilterRead()
        {
            FileDateFilterRead?.Invoke();
        }

        private void OnFileDateFilterStateRead(bool enabled)
        {
            FileDateFilterStateRead?.Invoke(enabled);
        }

        private void OnFileHandlerError(string msg)
        {
            Error?.Invoke(msg);
        }

        private void OnFileHandlerWarning(string msg)
        {
            Warning?.Invoke(msg);
        }

        private void OnFileZipCodeFiltersRead()
        {
            FileZipCodeFiltersRead?.Invoke();
        }

        private void OnFileZipCodeFilterStateRead(bool enabled)
        {
            FileZipCodeFilterStateRead?.Invoke(enabled);
        }

        private void StartProcess()
        {
            Process.Start(Configuration.GetSetting(Configuration.PROCESS_PATH));
            ProcessStarted?.Invoke();
            _processRunning = true;
        }

    }
}
