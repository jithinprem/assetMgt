using AssetManagement.Data;
using AssetManagement.DTO;
using AssetManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IRepository<Facility> _repository;
        private readonly IRepository<CityLookup> _cityLookupRepository;
        private readonly IRepository<BuildingLookup> _buildingRepository;
        

        public FacilityController(IRepository<Facility> repository, IRepository<CityLookup> cityLookupRepository, IRepository<BuildingLookup> buildingRepository)
        {
            _repository = repository;
            _cityLookupRepository = cityLookupRepository;
            _buildingRepository = buildingRepository;
        }


        [HttpGet]
        [Route("AllFacility")]
        public IActionResult GetAllFacility()
        {
            var listOfFacility = _repository.GetAll();
            return Ok(listOfFacility);
        }

        [HttpGet]
        [Route("GetFacility")]
        public IActionResult GetFacility(int id)
        {
            var facility = _repository.GetById(id);
            return Ok(facility);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(FacilityDto facilityDto)
        {
            Facility facility = new Facility();

            facility.FacilityName = facilityDto.FacilityName;
            facility.Floor = facilityDto.Floor;

            var tempCity = _cityLookupRepository.GetAll().FirstOrDefault(f => f.CityName == facilityDto.CityName);
            if (tempCity != null)
            {
                facility.CityId = tempCity.CityId;
            }
            else
            {
                var newCity = new CityLookup { CityName = facilityDto.CityName, CityAbbreviation = facilityDto.CityName.Substring(0, 3).ToUpper() };
                _cityLookupRepository.Add(newCity);
                

                facility.CityId = newCity.CityId;

            }
            var tempBuild = _buildingRepository.GetAll().FirstOrDefault(f => f.BuildingName == facilityDto.BuildingName);
            if (tempBuild != null)
            {
                facility.BuildingId = tempBuild.BuildingId;
            }
            else
            {
                var newBuilding = new BuildingLookup { BuildingName = facilityDto.BuildingName, BuildingAbbreviation = facilityDto.BuildingName.Substring(0, 3).ToUpper() };
                _buildingRepository.Add(newBuilding);
                
                facility.BuildingId = newBuilding.BuildingId;
            }
            _repository.Add(facility);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var deleteFacility = _repository.GetById(id);
            if (deleteFacility == null)
            {
                return NotFound();
            }
            _repository.Delete(deleteFacility.FacilityId);
            return Ok();
        }

        
    }
}
