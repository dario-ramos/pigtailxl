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
            _model.Error += OnError;
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
         * When the model reports an error, show it in the view
         */ 
        private void OnError(string errorMsg)
        {
            _view.ShowErrorMessage(errorMsg);
        }

        private void OnWarning(string msg)
        {
            _view.ShowWarningMessage(msg);
        }

        private void OnZipCodesRead()
        {
            _view.SetZipCodeFilters(_model.ZipCodeFilters);
        }
    }
}
