using NJCourts.Models;
using NJCourts.Views;
using System;

namespace NJCourts.Presenters
{
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
        }

        public void Init()
        {
            _model.Init();
        }

        private void OnError(string errorMsg)
        {
            _view.ShowErrorMessage(errorMsg);
        }
    }
}
