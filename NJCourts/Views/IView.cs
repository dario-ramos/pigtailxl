using System.Collections.Generic;

namespace NJCourts.Views
{
    public interface IView
    {
        void SetZipCodeFilters(List<int> zipCodeFilters);

        void ShowErrorMessage(string errorMsg);

        void ShowWarningMessage(string msg);
    }
}
