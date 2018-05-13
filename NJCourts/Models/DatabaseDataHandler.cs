using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace NJCourts.Models
{
    internal class DatabaseDataHandler
    {
        internal struct ComparisonFilter
        {
            public string Placeholder;
            public string Value;
        }

        public Action DataLoaded;
        private string _filterTemplate;
        private Dictionary<string, ComparisonFilter> _comparisonFilterValues;
        private Dictionary<string, ComparisonFilter> _multivalueFilterValues;
        private Dictionary<string, string> _textFilterValues;

        public DatabaseDataHandler()
        {
            _filterTemplate = "[" + Constants.FieldNames.VENUE + "] like '%" + Constants.FieldNames.VENUE + "%' and " +
                              "[" + Constants.FieldNames.CASE_STATUS + "] like '%" + Constants.FieldNames.CASE_STATUS + "%' and " +
                              "[" + Constants.FieldNames.DEBTOR_CITY + "] like '%" + Constants.FieldNames.DEBTOR_CITY + "%' and " +
                              "[" + Constants.FieldNames.DOCKET_VALUE + "] like '%" + Constants.FieldNames.DOCKET_VALUE + "%' and " +
                              "[" + Constants.FieldNames.DEBTOR_STATE + "] like '%" + Constants.FieldNames.DEBTOR_STATE + "%' and " +
                              Constants.Placeholders.NEW_RECORD_FLAG_COMPARISON + " and " +
                              Constants.Placeholders.DEMAND_AMOUNT_COMPARISON + " and " +
                              Constants.Placeholders.CASE_FILED_DATE_COMPARISON + " and " +
                              Constants.Placeholders.ZIP_COMPARISON;
            _textFilterValues = new Dictionary<string, string>();
            _textFilterValues[Constants.FieldNames.CASE_STATUS] = "";
            _textFilterValues[Constants.FieldNames.DEBTOR_CITY] = "";
            _textFilterValues[Constants.FieldNames.DOCKET_VALUE] = "";
            _textFilterValues[Constants.FieldNames.DEBTOR_STATE] = "";
            _textFilterValues[Constants.FieldNames.VENUE] = "";
            _comparisonFilterValues = new Dictionary<string, ComparisonFilter>();
            _comparisonFilterValues[Constants.FieldNames.DEMAND_AMOUNT] = new ComparisonFilter
            {
                Placeholder = Constants.Placeholders.DEMAND_AMOUNT_COMPARISON,
                Value = "true"
            };
            _comparisonFilterValues[Constants.FieldNames.CASE_FILED_DATE] = new ComparisonFilter
            {
                Placeholder = Constants.Placeholders.CASE_FILED_DATE_COMPARISON,
                Value = "true"
            };
            _comparisonFilterValues[Constants.FieldNames.NEW_RECORD_FLAG] = new ComparisonFilter
            {
                Placeholder = Constants.Placeholders.NEW_RECORD_FLAG_COMPARISON,
                Value = Constants.FieldNames.NEW_RECORD_FLAG + " = True" //We only want new records on startup
            };
            _multivalueFilterValues = new Dictionary<string, ComparisonFilter>();
            _multivalueFilterValues[Constants.FieldNames.DEBTOR_ZIP] = new ComparisonFilter
            {
                Placeholder = Constants.Placeholders.ZIP_COMPARISON,
                Value = "true"
            };
        }

        public DataTable Data
        {
            get;
            private set;
        }

        public List<string> Venues
        {
            get;
            private set;
        }

        public string Filter
        {
            get
            {
                return UpdateFilter();
            }
        }

        public void DisableComparisonFilter(string fieldName)
        {
            ComparisonFilter comparisonFilter = _comparisonFilterValues[fieldName];
            comparisonFilter.Value = "true";
            _comparisonFilterValues[fieldName] = comparisonFilter;
        }

        public void Export(string exportedFilePath)
        {
            DataView filteredData = new DataView(Data);
            filteredData.ToTable().ExportToExcel(exportedFilePath);
        }

        public void Init()
        {
            var venues = new DataTable();
            using (OleDbConnection connection = new OleDbConnection(Configuration.GetSetting(Configuration.CONNECTION_STRING)))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT distinct njcVenue from NJCourts_Data order by njcVenue;", connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                adapter.Fill(venues);
            }
            Venues = venues.AsEnumerable().Select(row => (string)row[Constants.FieldNames.VENUE]).ToList();
        }

        public void MarkRecordsAsOld(IEnumerable<int> recordIds)
        {
            using (OleDbConnection connection = new OleDbConnection(Configuration.GetSetting(Configuration.CONNECTION_STRING)))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                OleDbCommand command = new OleDbCommand("select * from NJCourts_Data;", connection);
                string inClause = "(" + string.Join(",", recordIds) + ")";
                cmd.CommandText = "UPDATE NJCourts_Data SET " + Constants.FieldNames.NEW_RECORD_FLAG + " = False WHERE " + Constants.FieldNames.ID + " IN " + inClause;
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            ReadData();
        }

        public void SetFilterParameters(string fieldName, bool fieldValue)
        {
            ComparisonFilter comparisonFilter = _comparisonFilterValues[fieldName];
            string condition = fieldValue ? "True" : "False";
            comparisonFilter.Value = fieldName + " = " + condition;
            _comparisonFilterValues[fieldName] = comparisonFilter;
        }

        public void SetFilterParameters(string fieldName, string fieldValue)
        {
            _textFilterValues[fieldName] = fieldValue;
        }

        public void SetFilterParameters(string fieldName, Constants.Comparison comparison, string value1, string value2)
        {
            if (string.IsNullOrWhiteSpace(value1) || comparison == Constants.Comparison.NONE || (comparison == Constants.Comparison.RANGE && string.IsNullOrWhiteSpace(value2)))
            {
                ComparisonFilter comparisonFilter = _comparisonFilterValues[fieldName];
                comparisonFilter.Value = "true";
                _comparisonFilterValues[fieldName] = comparisonFilter;
            }
            else if(comparison != Constants.Comparison.RANGE)
            {
                ComparisonFilter comparisonFilter = _comparisonFilterValues[fieldName];
                comparisonFilter.Value = "[" + fieldName + "] " + comparison.ComparisonToString() + " " + value1 + " ";
                _comparisonFilterValues[fieldName] = comparisonFilter;
            }
            else
            {
                ComparisonFilter comparisonFilter = _comparisonFilterValues[fieldName];
                comparisonFilter.Value = "([" + fieldName + "] " + Constants.Comparison.GREATER.ComparisonToString() + " " + value1 + " and [" +
                                         fieldName + "] " + Constants.Comparison.LOWER.ComparisonToString() + " " + value2 + ")";
                _comparisonFilterValues[fieldName] = comparisonFilter;
            }
        }

        public void SetFilterParameters(string fieldName, List<string> fieldValues)
        {
            ComparisonFilter comparisonFilter = _multivalueFilterValues[fieldName];
            if (fieldValues.Count > 0 && !string.IsNullOrWhiteSpace(fieldValues[0]))
            {
                comparisonFilter.Value = "(";
                foreach (string value in fieldValues)
                {
                    comparisonFilter.Value += "[" + fieldName + "] like '" + value + "%' or";
                }
                comparisonFilter.Value = comparisonFilter.Value.Substring(0, comparisonFilter.Value.Length - 3); //Remove last 'or'
                comparisonFilter.Value += ")";
            }
            else
            {
                comparisonFilter.Value = "true";
            }
            _multivalueFilterValues[fieldName] = comparisonFilter;
        }

        public void ReadData()
        {
            Data = new DataTable();
            using (OleDbConnection connection = new OleDbConnection(Configuration.GetSetting(Configuration.CONNECTION_STRING)))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from NJCourts_Data where " + Filter + "; ", connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                adapter.Fill(Data);
            }
            DataLoaded?.Invoke();
        }

        private string UpdateFilter()
        {
            string filter = (string)_filterTemplate.Clone();
            foreach (KeyValuePair<string, string> kvp in _textFilterValues)
            {
                filter = filter.Replace("'%" + kvp.Key + "%'", "'%" + kvp.Value + "%'");
            }
            foreach (KeyValuePair<string, ComparisonFilter> kvp in _comparisonFilterValues)
            {
                filter = filter.Replace(kvp.Value.Placeholder, kvp.Value.Value);
            }
            foreach (KeyValuePair<string, ComparisonFilter> kvp in _multivalueFilterValues)
            {
                filter = filter.Replace(kvp.Value.Placeholder, kvp.Value.Value);
            }
            return filter;
        }
    }
}
