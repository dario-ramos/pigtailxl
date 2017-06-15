using NJCourts.Models;
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
            _model.DateFilterRead += OnDateFilterRead;
            _model.Error += OnError;
            _model.ProcessStopped += OnProcessStopped;
            _model.StoppingProcess += OnStoppingProcess;
            _model.Warning += OnWarning;
            _model.ZipCodeFiltersRead += OnZipCodesRead;
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
        public void StartProcess()
        {
            _model.StartProcess();
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
         * When the model is done reading the date filter, show it in the view
         */
        private void OnDateFilterRead()
        {
            _view.SetDateFilter(_model.DateFiledFrom, _model.DateFiledTo);
        }

        /**
         * When the model reports an error, show it in the view
         */
        private void OnError(string errorMsg)
        {
            _view.ShowErrorMessage(errorMsg);
        }

        /**
         * Re-enable filters 
         */
        private void OnProcessStopped()
        {
            _view.FiltersEnabled = true;
        }

        /**
         * Disable filters until process is stoppped
         */
        private void OnStoppingProcess()
        {
            _view.FiltersEnabled = false;
        }

        /**
         * When the model reports a warning, show it in the view
         */
        private void OnWarning(string msg)
        {
            _view.ShowWarningMessage(msg);
        }

        /**
         * When the model is done reading all zip code filters, show them in the view
         */
        private void OnZipCodesRead()
        {
            _view.SetZipCodeFilters(_model.ZipCodeFilters);
        }
    }
}
