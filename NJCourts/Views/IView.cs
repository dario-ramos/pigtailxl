using NJCourts.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace NJCourts.Views
{
    public interface IView
    {
        bool FiltersEnabled { set; }

        bool ProcessRunning { set; }

        List<County> SelectedCounties { get; }

        void LoadVenueFilter(List<string> venues);

        void SetCounties(List<County> counties);

        void ShowErrorMessage(string errorMsg);

        void ShowWarningMessage(string msg);

        void StoppingProcess();

        void UpdateCounty(County county);

        void UpdateDatabaseData(DataTable data);
    }
}
