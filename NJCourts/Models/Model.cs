using System;
using System.Collections.Generic;
using System.IO;

namespace NJCourts.Models
{
    /**
     * Contains all the business logic
     */
    public class Model
    {
        public event Action ZipCodeFiltersRead;
        public event Action<string> Error;
        public event Action<string> Warning;

        /**
         * Constructor
         */
        public Model()
        {
            ZipCodeFilters = new List<int>();
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
        }

        /**
         * Read zip code filterss from file. If file does not exist, create it empty.
         * If a non numeric zip is read, warn and continue. When all are read, notify
         */
        private void ReadZipCodeFilters()
        {
            string zipFilePath = Path.Combine(Configuration.InputDirectory, Configuration.ZipCodeFile);
            if (!File.Exists(zipFilePath)){
                Warning?.Invoke("Zip file " + zipFilePath + " does not exist, will be created empty");
                File.Create(zipFilePath);
            }
            using (StreamReader sr = File.OpenText(zipFilePath))
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
