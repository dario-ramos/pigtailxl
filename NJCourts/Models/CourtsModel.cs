using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJCourts.Models
{
    class CourtsModel
    {
        public event Action CourtsDataRead;

        private DatabaseDataHandler _databaseDataHandler;
        private FileDataHandler _fileDataHandler;

        public CourtsModel(FileDataHandler fileDataHandler)
        {
            _databaseDataHandler = new DatabaseDataHandler();
            _databaseDataHandler.DataLoaded += OnDatabaseDataLoaded;
            _fileDataHandler = fileDataHandler;
        }

        /// <summary>
        /// Courts data in DataTable format. May be lazily loaded.
        /// </summary>
        public DataTable CourtsData
        {
            get
            {
                return _databaseDataHandler.Data;
            }
        }

        /// <summary>
        /// Available venues.
        /// </summary>
        public List<string> Venues
        {
            get
            {
                return _databaseDataHandler.Venues;
            }
        }

        /// <summary>
        /// All zip list names
        /// </summary>
        public List<string> ZipListNames
        {
            get
            {
                return _fileDataHandler.ZipListNames;
            }
        }

        /// <summary>
        /// Set the current zip list by its name
        /// </summary>
        public string CurrentZipList
        {
            get
            {
                return _fileDataHandler.CurrentZipList;
            }
            set
            {
                _fileDataHandler.CurrentZipList = value;
            }
        }

        /// <summary>
        /// Contents of the current zip list
        /// </summary>
        public List<string> CurrentZipListValues
        {
            get
            {
                return _fileDataHandler.CurrentZipListValues;
            }
        }

        /// <summary>
        /// Current data filter (as a SQL where clause)
        /// </summary>
        public string Filter
        {
            get
            {
                return _databaseDataHandler.Filter;
            }
        }

        /// <summary>
        /// Including filesystem
        /// </summary>
        public void DeleteCurrentZipList()
        {
            _fileDataHandler.DeleteCurrentZipList();
        }

        /// <summary>
        /// Remove field from filter
        /// </summary>
        /// <param name="fieldName"></param>
        public void DisableComparisonFilter(string fieldName)
        {
            _databaseDataHandler.DisableComparisonFilter(fieldName);
        }

        /// <summary>
        /// Export courts data to an external source
        /// </summary>
        public void Export(string exportedFilePath)
        {
            _databaseDataHandler.Export(exportedFilePath);
        }

        /// <summary>
        /// Read courts data
        /// </summary>
        public void Init()
        {
            _databaseDataHandler.ReadData();
        }

        /// <summary>
        /// Without exception
        /// </summary>
        public void MarkRecordsAsOld(IEnumerable<int> recordIds)
        {
            _databaseDataHandler.MarkRecordsAsOld(recordIds);
        }

        /// <summary>
        /// Persists it across program executions
        /// </summary>
        public void SaveCurrentZipList()
        {
            _fileDataHandler.SaveCurrentZipList();
        }

        /// <summary>
        /// Create or update zip list
        /// </summary>
        /// <param name="listName">If list already exists, its values will be overwritten</param>
        /// <param name="zipCodes">The new zip code list values</param>
        public void SaveZipList(string listName, IEnumerable<string> zipCodes)
        {
            _fileDataHandler.SaveZipCodeList(listName, zipCodes);
        }

        /// <summary>
        /// Configure a yes/no filter without applying it
        /// </summary>
        /// <param name="fieldName">Database field to compare</param>
        /// <param name="fieldValue">Filter by field = true or false</param>
        public void SetFilterParameters(string fieldName, bool fieldValue)
        {
            _databaseDataHandler.SetFilterParameters(fieldName, fieldValue);
        }

        /// <summary>
        /// Configuring a comparison-type filter without applying it
        /// </summary>
        /// <param name="fieldName">Database field to compare</param>
        /// <param name="comparison">Comparison to perform</param>
        /// <param name="value1">First value to compare</param>
        /// <param name="value2">Second value to compare; only used for RANGE comparisons</param>
        public void SetFilterParameters(string fieldName, Constants.Comparison comparison, string value1, string value2)
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

        private void OnDatabaseDataLoaded()
        {
            DataTable data = _databaseDataHandler.Data;
            data.Columns[Constants.FieldNames.CASE_FILED_DATE].ColumnName = Constants.DisplayFieldNames.CASE_FILED_DATE;
            data.Columns[Constants.FieldNames.CASE_STATUS].ColumnName = Constants.DisplayFieldNames.CASE_STATUS;
            data.Columns[Constants.FieldNames.CASE_TYPE].ColumnName = Constants.DisplayFieldNames.CASE_TYPE;
            data.Columns[Constants.FieldNames.CASE_TITLE].ColumnName = Constants.DisplayFieldNames.CASE_TITLE;
            data.Columns[Constants.FieldNames.COURT].ColumnName = Constants.DisplayFieldNames.COURT;
            data.Columns[Constants.FieldNames.DATE_TIME_OF_CREATION].ColumnName = Constants.DisplayFieldNames.DATE_TIME_OF_CREATION;
            data.Columns[Constants.FieldNames.DEBTOR_CITY].ColumnName = Constants.DisplayFieldNames.DEBTOR_CITY;
            data.Columns[Constants.FieldNames.DEBTOR_FIRST_NAME].ColumnName = Constants.DisplayFieldNames.DEBTOR_FIRST_NAME;
            data.Columns[Constants.FieldNames.DEBTOR_LAST_NAME].ColumnName = Constants.DisplayFieldNames.DEBTOR_LAST_NAME;
            data.Columns[Constants.FieldNames.DEBTOR_STATE].ColumnName = Constants.DisplayFieldNames.DEBTOR_STATE;
            data.Columns[Constants.FieldNames.DEBTOR_STREET].ColumnName = Constants.DisplayFieldNames.DEBTOR_STREET;
            data.Columns[Constants.FieldNames.DEBTOR_ZIP].ColumnName = Constants.DisplayFieldNames.DEBTOR_ZIP;
            data.Columns[Constants.FieldNames.DEMAND_AMOUNT].ColumnName = Constants.DisplayFieldNames.DEMAND_AMOUNT;
            data.Columns[Constants.FieldNames.DOCKET_VALUE].ColumnName = Constants.DisplayFieldNames.DOCKET_VALUE;
            data.Columns[Constants.FieldNames.ID].ColumnName = Constants.DisplayFieldNames.ID;
            data.Columns[Constants.FieldNames.VENUE].ColumnName = Constants.DisplayFieldNames.VENUE;
            CourtsDataRead?.Invoke();
        }
    }
}
