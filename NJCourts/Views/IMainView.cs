using NJCourts.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace NJCourts.Views
{
    public interface IMainView
    {
        bool FiltersEnabled { set; }

        bool ProcessRunning { set; }

        List<County> SelectedCounties { get; }

        void SetCounties(List<County> counties);

        void SetDocketYear(int docketYear);

        void ShowErrorMessage(string errorMsg);

        void ShowWarningMessage(string msg);

        void StoppingProcess();

        void UpdateCounty(County county);

    }
}
