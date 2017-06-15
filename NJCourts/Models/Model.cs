using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace NJCourts.Models
{
    /**
     * Contains all the business logic
     */
    public class Model
    {
        public event Action DateFilterRead;
        public event Action ZipCodeFiltersRead;
        public event Action<string> Error;
        public event Action<string> Warning;

        /**
         * Constructor
         */
        public Model()
        {
            ZipCodeFilters = new List<int>();
            DateFiledFrom = null;
            DateFiledTo = null;
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
