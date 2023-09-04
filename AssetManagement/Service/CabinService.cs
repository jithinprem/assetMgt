using AssetManagement.Data;
using AssetManagement.DTO;
using AssetManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Service
{
    public class CabinService
    {
        public class FacilityInfoDto
        {
            public string FacilityName { get; set; }
            public string CityAbbreviation { get; set; }
            public string BuildingAbbreviation { get; set; }
            public int Floors { get; set; }
        }



        public readonly IRepository<Cabin> _repository;
        public readonly IRepository<Facility> _facilityRepository;
        public readonly IRepository<CityLookup> _cityLookupRepository;
        public readonly IRepository<BuildingLookup> _buildingRepository;
        public CabinService(IRepository<Cabin> repository, IRepository<Facility> facilityRepository, IRepository<CityLookup> cityLookupRepository, IRepository<BuildingLookup> buildingLookupRepository) { 
            _repository = repository;
            _facilityRepository = facilityRepository;
            _cityLookupRepository = cityLookupRepository;
            _buildingRepository = buildingLookupRepository;
        }
        public int NextIdValue() {
            int nextId = 1;
            var maxId = _repository.GetEntitiesByFilter(e => true).Max(e => e.CabinId);
            if (maxId != null) { 
                nextId = maxId+1;
            }
            return nextId;
        }

        public FacilityInfoDto GetFacilityInfo(CabinDto cabinDto)
        {
            var facilityInfo1 = _facilityRepository.GetAll()
                .Where(f => f.FacilityId == cabinDto.FacilityId);

            var facilityInfo2 = facilityInfo1
            .Join(
                    _cityLookupRepository.GetAll(),
                    facility => facility.CityId,
                    city => city.CityId,
                    (facility, city) => new
                    {
                        Facility = facility,
                        CityAbbreviation = city.CityAbbreviation
                    }
            );
            var facilityInfo3 = facilityInfo2
            .Join(
                    _buildingRepository.GetAll(),
                    data => data.Facility.BuildingId,
                    building => building.BuildingId,
                    (data, building) => new FacilityInfoDto
                    {
                        FacilityName = data.Facility.FacilityName,
                        CityAbbreviation = data.CityAbbreviation,
                        BuildingAbbreviation = building.BuildingAbbreviation,
                        Floors = data.Facility.Floor
                    }
                )
                .FirstOrDefault();

            return facilityInfo3;
        }

        public void AddCabin(FacilityInfoDto result, CabinDto cabinDto, int newCabinNameId) {
            // Access the abbreviations as needed
            var facilityName = result.FacilityName;
            var cityAbbreviation = result.CityAbbreviation;
            var buildingAbbreviation = result.BuildingAbbreviation;
            var floors = result.Floors.ToString();

            string newCabinName = cityAbbreviation + '-' + buildingAbbreviation + '-' + floors + '-' + facilityName + '-' + 'C' + newCabinNameId.ToString();

            _repository.Add(new Cabin { CabinName = newCabinName, FacilityId = cabinDto.FacilityId });
        }
    }
}
