﻿using NJCourts.Models;
using NJCourts.Views;
using System;

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
            _model.CountiesRead += OnCountiesRead;
            _model.CountyUpdated += OnCountyUpdated;
            _model.DateFilterRead += OnDateFilterRead;
            _model.DateFilterStateRead += OnDateFilterStateRead;
            _model.Error += OnError;
            _model.ProcessStarted += OnProcessStarted;
            _model.ProcessStopped += OnProcessStopped;
            _model.StoppingProcess += OnStoppingProcess;
            _model.Warning += OnWarning;
            _model.ZipCodeFiltersRead += OnZipCodesRead;
            _model.ZipCodeFilterStateRead += OnZipCodeFilterStateRead;
        }

        /**
         * Grab data from view and send to model
         */
        public void ApplyFilters()
        {
            _model.ApplyFilters(_view.ZipCodeFilters, _view.DateFilter, _view.SelectedCounties);
        }

        /**
         * Initialize model
         */
        public void Init()
        {
            _model.Init();
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
            _view.SetCounties(_model.Counties);
        }

        /**
         * When a county is updated, show it in the view
         */ 
        private void OnCountyUpdated(County county)
        {
            _view.UpdateCounty(county);
        }

        /**
         * When the model is done reading the date filter, show it in the view
         */
        private void OnDateFilterRead()
        {
            _view.DateFilter = new Tuple<DateTime?, DateTime?>(_model.DateFiledFrom, _model.DateFiledTo);
        }

        private void OnDateFilterStateRead(bool enabled)
        {
            _view.DateFilterEnabled = enabled;
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

        private void OnZipCodeFilterStateRead(bool enabled)
        {
            _view.ZipCodeFilterEnabled = enabled;
        }

        /**
         * When the model is done reading all zip code filters, show them in the view
         */
        private void OnZipCodesRead()
        {
            _view.ZipCodeFilters = _model.ZipCodeFilters;
        }

    }
}
