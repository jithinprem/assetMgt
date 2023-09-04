using AssetManagement.Data;
using AssetManagement.DTO;
using AssetManagement.Model;
using AssetManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinController : ControllerBase
    {
        private readonly IRepository<Cabin> _repository;
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<CityLookup> _cityLookupRepository;
        private readonly IRepository<BuildingLookup> _buildingRepository;
        private readonly IRepository<Allocation> _allocationRepository;

        
        public CabinController(IRepository<Cabin> repository, IRepository<Facility> facilityRepository, IRepository<CityLookup> cityLookupRepository, IRepository<BuildingLookup> buildingLookupRepository, IRepository<Allocation> allocationRepository)
        {
            _repository = repository;
            _cityLookupRepository = cityLookupRepository;
            _buildingRepository = buildingLookupRepository;
            _facilityRepository = facilityRepository;
            _allocationRepository = allocationRepository;

        }

        [HttpGet]
        [Route("AllCabin")]
        public IActionResult GetAllFacility()
        {
            var listOfCabin = _repository.GetAll();
            return Ok(listOfCabin);
        }



        [HttpPost]
        [Route("Add")]
        public IActionResult Add(CabinDto cabinDto)
        {


            CabinService cabinService = new CabinService(_repository, _facilityRepository, _cityLookupRepository, _buildingRepository);
            int newCabinNameId = cabinService.NextIdValue();

            var result = cabinService.GetFacilityInfo(cabinDto);

            if (result != null)
            {
                cabinService.AddCabin(result, cabinDto, newCabinNameId);
                return Ok();
            }
            else
            {
                return NotFound("Facility dosen't exist!");
            }
        }



        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var deleteCabin = _repository.GetById(id);
            if (deleteCabin == null)
            {
                return NotFound();
            }
            _repository.Delete(deleteCabin.CabinId);
            return Ok();
        }



        [HttpGet]
        [Route("FreeCabins")]
        public IActionResult GetFreeCabins()
        {
            var unallocatedCabins = _repository.GetAll()
                                    .Where(cabin => !_allocationRepository.GetAll().Any(allocation =>
                                        allocation.AssetId == cabin.CabinId && allocation.AssetLookupId == 1));

            return Ok(unallocatedCabins);
        }



        [HttpGet]
        [Route("FreeCabinsByFacility")]
        public IActionResult GetFreeCabinsByFacility(string facilityId)
        {
            int givenFacilityId = Convert.ToInt32(facilityId);
            var unallocatedCabins = _repository.GetAll()
                                    .Where(cabin => !_allocationRepository.GetAll().Any(allocation =>
                                        allocation.AssetId == cabin.CabinId && allocation.AssetLookupId == 1) && cabin.FacilityId == givenFacilityId);

            return Ok(unallocatedCabins);
        }
    }

}





//var result = _context.Facilities
//.Where(f => f.FacilityId == cabinDto.FacilityId) // Filter by FacilityId
//.Join(
//    _context.CityLookups,
//    facility => facility.CityId,
//    city => city.CityId,
//    (facility, city) => new
//    {
//        Facility = facility,
//        CityAbbreviation = city.CityAbbreviation
//    }
//)
//.Join(
//    _context.BuildingLookups,
//    data => data.Facility.BuildingId,
//    building => building.BuildingId,
//    (data, building) => new
//    {
//        FacilityName = data.Facility.FacilityName,
//        CityAbbreviation = data.CityAbbreviation,
//        BuildingAbbreviation = building.BuildingAbbreviation,
//        Floors = data.Facility.Floor
//    }
//)
//.FirstOrDefault();