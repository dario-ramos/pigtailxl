using NJCourts.Models;
using NJCourts.Views;
using System.Collections.Generic;

namespace NJCourts.Presenters
{
    class CourtsPresenter
    {
        private ICourtsView _view;
        private CourtsModel _model;

        public CourtsPresenter(ICourtsView view)
        {
            _view = view;
            _model = new CourtsModel();
            _model.CourtsDataRead += OnCourtsDataRead;
        }

        public string Filter
        {
            get
            {
                return _model.Filter;
            }
        }

        public void Export(string exportedFilePath)
        {
            _model.Export(exportedFilePath);
        }

        public void Init()
        {
            _model.Init();
        }

        public void SetFilterParameters(string fieldName, Constants.Comparison comparison, string value1, string value2)
        {
            _model.SetFilterParemeters(fieldName, comparison, value1, value2);
        }

        public void SetFilterParameters(string fieldName, List<string> fieldValues)
        {
            _model.SetFilterParemeters(fieldName, fieldValues);
        }

        public void SetFilterParameters(string fieldName, string fieldValue)
        {
            _model.SetFilterParemeters(fieldName, fieldValue);
        }

        /**
         * When data is read, send it to view 
         */
        private void OnCourtsDataRead()
        {
            _view.UpdateCourtsData(_model.CourtsData);
            _view.LoadVenueFilter(_model.Venues);
        }
    }
}
