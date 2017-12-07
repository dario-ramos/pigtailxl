using System.Collections.Generic;
using System.Data;

namespace NJCourts.Views
{
    public interface ICourtsView
    {
        void LoadVenueFilter(List<string> venues);

        void UpdateCourtsData(DataTable data);
    }
}
