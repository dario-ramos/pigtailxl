using System.Collections.Generic;
using System.Data;

namespace NJCourts.Views
{
    public interface ICourtsView
    {
        string CurrentZipList { set; }

        void LoadVenueFilter(List<string> venues);

        void UpdateCourtsData(DataTable data);

        void UpdateZipFilter(List<string> zipValues);

        void UpdateZipLists(IEnumerable<string> zipListNames);
    }
}
