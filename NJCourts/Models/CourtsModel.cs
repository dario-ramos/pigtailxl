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

        public CourtsModel()
        {
            _databaseDataHandler = new DatabaseDataHandler();
            _databaseDataHandler.DataLoaded += OnDatabaseDataLoaded;
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
        /// Export courts data to an external source
        /// </summary>
        public void Export()
        {
            _databaseDataHandler.Export();
        }

        /// <summary>
        /// Read courts data
        /// </summary>
        public void Init()
        {
            _databaseDataHandler.ReadData();
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

        private void OnDatabaseDataLoaded()
        {
            CourtsDataRead?.Invoke();
        }
    }
}
