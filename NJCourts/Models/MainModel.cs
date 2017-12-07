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
    public class MainModel
    {
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
        private FileDataHandler _fileDataHandler;

        /**
         * Constructor
         */
        public MainModel()
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

        /**
         * Save filters to files
         */
        public void ApplyFiltersFromFiles(List<County> selectedCounties)
        {
            _fileDataHandler.ApplyFilters(selectedCounties);
        }

        /**
         * Check if input directory exists 
         * Then, read all files
         */
        public void Init()
        {
            _fileDataHandler.Init();
            _fileDataHandler.ReadData();
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
