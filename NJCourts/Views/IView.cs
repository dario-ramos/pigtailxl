﻿using NJCourts.Models;
using System;
using System.Collections.Generic;

namespace NJCourts.Views
{
    public interface IView
    {
        bool DateFilterEnabled { set; }

        bool FiltersEnabled { set; }

        bool ProcessRunning { set; }

        bool ZipCodeFilterEnabled { set;  }

        List<County> SelectedCounties { get; }

        List<string> ZipCodeFilters { get; set; }

        Tuple<DateTime?, DateTime?> DateFilter{ get; set; }

        void SetCounties(List<County> counties);

        void ShowErrorMessage(string errorMsg);

        void ShowWarningMessage(string msg);

        void StoppingProcess();

        void UpdateCounty(County county);
    }
}
