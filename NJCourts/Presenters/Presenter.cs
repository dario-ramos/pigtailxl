using NJCourts.Models;
using NJCourts.Views;
using System;
using System.Collections.Generic;

namespace NJCourts.Presenters
{
    /**
     * The presenter called by the view, changes the model, and when those changes are complete, 
     * the presenter is notified via events so it can update the view
     */
    public class Presenter
    {
        private IView _view;
        private Model _model;

        /**
         * Create model and set all event handlers
         */ 
        public Presenter(IView view)
        {
            _model = new Model();
            _view = view;
            _model.CountyFileUpdated += OnCountyUpdated;
            _model.DatabaseDataRead += OnDatabaseDataRead;
            _model.Error += OnError;
            _model.FileCountiesRead += OnCountiesRead;
            _model.ProcessStarted += OnProcessStarted;
            _model.ProcessStopped += OnProcessStopped;
            _model.StoppingProcess += OnStoppingProcess;
            _model.Warning += OnWarning;
        }

        public string Filter
        {
            get
            {
                return _model.Filter;
            }
        }

        /**
         * Grab data from view and send to model
         */
        public void ApplyFilters()
        {
            _model.ApplyFiltersFromFiles(_view.SelectedCounties);
        }

        public void Export()
        {
            _model.Export();
        }

        /**
         * Initialize model
         */
        public void Init()
        {
            _model.Init();
        }

        public void SaveDateFilterState(bool enabled)
        {
            _model.SaveFileDateFilterState(enabled);
        }

        public void SaveZipCodeFilterState(bool enabled)
        {
            _model.SaveFileZipCodeFilterState(enabled);
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
         * Delegate to model
         */
        public void StartStopProcess()
        {
            _model.StartStopProcess();
        }

        /**
         * Delegate to model
         */
        public void StopProcess()
        {
            _model.StopProcess();
        }

        /**
         * When the model is done reading counties, show them in the view
         */
        private void OnCountiesRead()
        {
            _view.SetCounties(_model.CountiesFromFiles);
        }

        /**
         * When a county is updated, show it in the view
         */ 
        private void OnCountyUpdated(County county)
        {
            _view.UpdateCounty(county);
        }

        /**
         * When data is read, send it to view 
         */
        private void OnDatabaseDataRead()
        {
            _view.UpdateDatabaseData(_model.DatabaseData);
            _view.LoadVenueFilter(_model.Venues);
        }

        /**
         * When the model reports an error, show it in the view
         */
        private void OnError(string errorMsg)
        {
            _view.ShowErrorMessage(errorMsg);
        }

        /**
         * Notify view
         */
        private void OnProcessStarted()
        {
            _view.ProcessRunning = true;
        }

        /**
         * Re-enable filters 
         */
        private void OnProcessStopped()
        {
            _view.FiltersEnabled = true;
            _view.ProcessRunning = false;
        }

        /**
         * Disable filters until process is stoppped
         */
        private void OnStoppingProcess()
        {
            _view.FiltersEnabled = false;
            _view.StoppingProcess();
        }

        /**
         * When the model reports a warning, show it in the view
         */
        private void OnWarning(string msg)
        {
            _view.ShowWarningMessage(msg);
        }

    }
}
