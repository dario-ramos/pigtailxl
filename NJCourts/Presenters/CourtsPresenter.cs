using NJCourts.Models;
using NJCourts.Views;
using System.Collections.Generic;

namespace NJCourts.Presenters
{
    class CourtsPresenter
    {
        private ICourtsView _view;
        private CourtsModel _model;

        public CourtsPresenter(ICourtsView view, FileDataHandler fileDataHandler)
        {
            _view = view;
            _model = new CourtsModel(fileDataHandler);
            _model.CourtsDataRead += OnCourtsDataRead;
        }

        /// <summary>
        /// Select current zip code list by its name
        /// </summary>
        public string CurrentZipList
        {
            get
            {
                return _model.CurrentZipList;
            }
            set
            {
                _model.CurrentZipList = value;
                _view.UpdateZipFilter(_model.CurrentZipListValues);
                _model.SaveCurrentZipList();
            }
        }

        /// <summary>
        /// Current filter expression (can be a combination of filters)
        /// </summary>
        public string Filter
        {
            get
            {
                return _model.Filter;
            }
        }

        /// <summary>
        /// Delete file, remove from zip lists and update current zip list
        /// </summary>
        public void DeleteCurrentZipList()
        {
            _model.DeleteCurrentZipList();
            UpdateZipLists();
            _view.CurrentZipList = _model.CurrentZipList;
        }

        /// <summary>
        /// Stop applying a specific filter
        /// </summary>
        /// <param name="fieldName">Field on which to disable filter</param>
        public void DisableComparisonFilter(string fieldName)
        {
            _model.DisableComparisonFilter(fieldName);
        }

        /// <summary>
        /// Export current data (with filters applied) to an Excel file
        /// </summary>
        /// <param name="exportedFilePath">Exported file destination</param>
        public void Export(string exportedFilePath)
        {
            _model.Export(exportedFilePath);
        }

        /// <summary>
        /// Initialize model
        /// </summary>
        public void Init()
        {
            _model.Init();
            CurrentZipList = Constants.Placeholders.NEW_ZIP_LIST;
            UpdateZipLists();
        }

        /// <summary>
        /// Without exception
        /// </summary>
        public void MarkRecordsAsOld(IEnumerable<int> recordIds)
        {
            _model.MarkRecordsAsOld(recordIds);
        }

        /// <summary>
        /// Save zip list for later selection
        /// </summary>
        /// <param name="listName">Selected list name; if empty, new list will be created</param>
        /// <param name="zipList">Comma separated list of zip codes</param>
        public void SaveZipList(string listName, string zipList)
        {
            string[] zipCodes = zipList.Split(Constants.Placeholders.MULTIVALUE_FILTER_SEPARATOR);
            _model.SaveZipList(listName, zipCodes);
            UpdateZipLists();
            _model.SaveCurrentZipList();
        }

        /// <summary>
        /// Configure filter for a Yes/No field
        /// </summary>
        /// <param name="fieldName">The field name; see Constants.FieldNames for allowed values</param>
        /// <param name="fieldValue">Tells whether to filter by fieldName == true or false</param>
        public void SetFilterParameters(string fieldName, bool fieldValue)
        {
            _model.SetFilterParameters(fieldName, fieldValue);
        }

        /// <summary>
        /// Configure range comparison filter for a given field
        /// </summary>
        /// <param name="fieldName">The field name; see Constants.FieldNames for allowed values</param>
        /// <param name="comparison">Comparison operator; see Constants.Comparison</param>
        /// <param name="value1">The filter expression will be: value1 comparison value2</param>
        /// <param name="value2">The filter expression will be: value1 comparison value2</param>
        public void SetFilterParameters(string fieldName, Constants.Comparison comparison, string value1, string value2)
        {
            _model.SetFilterParameters(fieldName, comparison, value1, value2);
        }

        /// <summary>
        /// Configure multivalue comparison filter for a given field; a row will match the filter
        /// if the field's value matches one of the multiple values supplied
        /// </summary>
        /// <param name="fieldName">The field name; see Constants.FieldNames for allowed values</param>
        /// <param name="fieldValues">A list of possible values for this field</param>
        public void SetFilterParameters(string fieldName, List<string> fieldValues)
        {
            _model.SetFilterParemeters(fieldName, fieldValues);
        }

        /// <summary>
        /// Configure a simple value filter for a given field; a row will only
        /// match the filter if the field's value matches the given field value
        /// </summary>
        /// <param name="fieldName">Field name</param>
        /// <param name="fieldValue">Field value to match</param>
        public void SetFilterParameters(string fieldName, string fieldValue)
        {
            _model.SetFilterParemeters(fieldName, fieldValue);
        }

        public void UpdateZipLists()
        {
            _view.UpdateZipLists(_model.ZipListNames);
            _view.CurrentZipList = _model.CurrentZipList;
        }

        private void OnCourtsDataRead()
        {
            //When data is read, send it to the view for display
            _view.UpdateCourtsData(_model.CourtsData);
            _view.LoadVenueFilter(_model.Venues);
        }
    }
}
