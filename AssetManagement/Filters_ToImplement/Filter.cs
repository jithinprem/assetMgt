using AssetManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.General
{
    public class Filter
    {

        Func<Facility, bool> lengthFourAndCityIdOne = f =>
        {
            // Include multiple conditions in the filter
            return f.CityId == 1 || f.FacilityName.Length == 4;
        };

    }
}
