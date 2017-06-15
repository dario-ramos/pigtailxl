using NJCourts.Models;
using System;
using System.Collections.Generic;

namespace NJCourts.Views
{
    public interface IView
    {
        void SetCounties(List<County> counties);

        void SetDateFilter(DateTime? dateFiledFrom, DateTime? dateFiledTo);

        void SetZipCodeFilters(List<int> zipCodeFilters);

        void ShowErrorMessage(string errorMsg);

        void ShowWarningMessage(string msg);
    }
}
