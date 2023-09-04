using AssetManagement.Data;
using AssetManagement.DTO;
using AssetManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        private readonly IRepository<MeetingRoom> _repository;
        private readonly IRepository<CityLookup> _cityLookupRepository;
        private readonly IRepository<BuildingLookup> _buildingRepository;
        private readonly IRepository<Facility> _facilityRepository;

        
        public MeetingRoomController(IRepository<MeetingRoom> repository, IRepository<CityLookup> cityLookupRepository, IRepository<BuildingLookup> buildingRepository, IRepository<Facility> facilityRepository) { 
            _repository = repository;
            _cityLookupRepository = cityLookupRepository;
            _buildingRepository = buildingRepository;
            _facilityRepository = facilityRepository;
        }

        [HttpGet]
        [Route("Getall")]
        public IActionResult GetAll() { 
            var allMeetingRoom =  _repository.GetAll();
            return Ok(allMeetingRoom);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(MeetingRoomDto meetingRoomDto) {

            // getting max of the id from MeetingRoom
            var newMeetingRoomId = _repository.GetAll().Max(s => s.RoomID) + 1;

            var result = _facilityRepository.GetAll()
                        .Where(f => f.FacilityId == meetingRoomDto.FacilityId) // Filter by FacilityId
                        .Join(
                            _cityLookupRepository.GetAll(),
                            facility => facility.CityId,
                            city => city.CityId,
                            (facility, city) => new
                            {
                                Facility = facility,
                                CityAbbreviation = city.CityAbbreviation
                            }
                        )
                        .Join(
                            _buildingRepository.GetAll(),
                            data => data.Facility.BuildingId,
                            building => building.BuildingId,
                            (data, building) => new
                            {
                                FacilityName = data.Facility.FacilityName,
                                CityAbbreviation = data.CityAbbreviation,
                                BuildingAbbreviation = building.BuildingAbbreviation,
                                Floors = data.Facility.Floor
                            }
                        )
                        .FirstOrDefault();

            if (result != null)
            {
                // Access the abbreviations as needed
                var facilityName = result.FacilityName;
                var cityAbbreviation = result.CityAbbreviation;
                var buildingAbbreviation = result.BuildingAbbreviation;
                var floors = result.Floors.ToString();
                // Do something with the abbreviations
                string newRoomName = cityAbbreviation + '-' + buildingAbbreviation + '-' + floors + '-' + facilityName + '-' + 'M' + newMeetingRoomId.ToString();
                var newMeetingRoom = new MeetingRoom { Chairs = meetingRoomDto.Chairs, RoomName = newRoomName, FacilityId = meetingRoomDto.FacilityId };
                _repository.Add(newMeetingRoom);
                return Ok(newMeetingRoom);
            }
            else
            {
                // Facility with the specified ID was not found
                return NotFound("facility not found");
            }

        }

        

    }
}
