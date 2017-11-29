using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
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
            Data = new DataTable();
            _filterTemplate = Constants.FieldNames.VENUE + " like '%" + Constants.FieldNames.VENUE + "%' and " + 
                              Constants.FieldNames.CASE_STATUS + " like '%" + Constants.FieldNames.CASE_STATUS + "%' and " +
                              Constants.FieldNames.CITY + " like '%" + Constants.FieldNames.CITY + "%' and " +
                              Constants.FieldNames.DOCKET_VALUE + " like '%" + Constants.FieldNames.DOCKET_VALUE + "%' and " +
                              Constants.FieldNames.STATE + " like '%" + Constants.FieldNames.STATE + "%' and " +
                              Constants.Placeholders.DEMAND_AMOUNT_COMPARISON + " and " + 
                              Constants.Placeholders.CASE_FILED_DATE_COMPARISON + " and " +
                              Constants.Placeholders.ZIP_COMPARISON;
            _textFilterValues = new Dictionary<string, string>();
            _textFilterValues[Constants.FieldNames.CASE_STATUS] = "";
            _textFilterValues[Constants.FieldNames.CITY] = "";
            _textFilterValues[Constants.FieldNames.DOCKET_VALUE] = "";
            _textFilterValues[Constants.FieldNames.STATE] = "";
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
            _multivalueFilterValues = new Dictionary<string, ComparisonFilter>();
            _multivalueFilterValues[Constants.FieldNames.ZIP] = new ComparisonFilter
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
            get
            {
                return Data.AsEnumerable()
                    .GroupBy( row => row[Constants.FieldNames.VENUE] )
                    .Select( group => group.First() )
                    .Select( row => (string) row[Constants.FieldNames.VENUE] )
                    .OrderBy(row => row).ToList();
            }
        }

        public string Filter
        {
            get
            {
                return UpdateFilter();
            }
        }

        public void Export()
        {
            string timeStamp = DateTime.Now.ToString("MMddyyyyHHmmss");
            DataView filteredData = new DataView(Data);
            filteredData.RowFilter = UpdateFilter();
            filteredData.ToTable().ExportToExcel(Path.Combine(Configuration.GetSetting(Configuration.EXCEL_EXPORT_DIR), timeStamp + "_Exported.xlsx"));
        }

        public void SetFilterParameters(string fieldName, string fieldValue)
        {
            _textFilterValues[fieldName] = fieldValue;
        }

        public void SetFilterParameters(string fieldName, Constants.Comparison comparison, string value1, string value2)
        {
            if (string.IsNullOrWhiteSpace(value1) || (comparison == Constants.Comparison.RANGE && string.IsNullOrWhiteSpace(value2)))
            {
                ComparisonFilter comparisonFilter = _comparisonFilterValues[fieldName];
                comparisonFilter.Value = "true";
                _comparisonFilterValues[fieldName] = comparisonFilter;
            }
            else if(comparison != Constants.Comparison.RANGE)
            {
                ComparisonFilter comparisonFilter = _comparisonFilterValues[fieldName];
                comparisonFilter.Value = fieldName + " " + comparison.ComparisonToString() + " '" + value1 + "'";
                _comparisonFilterValues[fieldName] = comparisonFilter;
            }else
            {
                ComparisonFilter comparisonFilter = _comparisonFilterValues[fieldName];
                comparisonFilter.Value = "(" + fieldName + " " + Constants.Comparison.GREATER.ComparisonToString() + " '" + value1 + "' and " +
                                         fieldName + " " + Constants.Comparison.LOWER.ComparisonToString() + " '" + value2 + "')";
                _comparisonFilterValues[fieldName] = comparisonFilter;
            }
        }

        public void SetFilterParameters(string fieldName, List<string> fieldValues)
        {
            ComparisonFilter comparisonFilter = _multivalueFilterValues[fieldName];
            if (fieldValues.Count > 0 && !string.IsNullOrWhiteSpace(fieldValues[0]))
            {
                comparisonFilter.Value = "(" + fieldName + " in (";
                foreach(string value in fieldValues)
                {
                    comparisonFilter.Value += "'" + value + "'" + Constants.Placeholders.MULTIVALUE_FILTER_SEPARATOR;
                }
                comparisonFilter.Value.TrimEnd(Constants.Placeholders.MULTIVALUE_FILTER_SEPARATOR);
                comparisonFilter.Value += "))";
            }else
            {
                comparisonFilter.Value = "true";
            }
            _multivalueFilterValues[fieldName] = comparisonFilter;
        }

        public void ReadData()
        {
            using (OleDbConnection connection = new OleDbConnection(Configuration.GetSetting(Configuration.CONNECTION_STRING)))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from NJCourts_Data;", connection);
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
