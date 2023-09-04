using AssetManagement.Data;
using AssetManagement.DTO;
using AssetManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly IRepository<Seat> _repository;
        private readonly IRepository<CityLookup> _cityLookupRepository;
        private readonly IRepository<BuildingLookup> _buildingRepository;
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<Allocation> _allocationRepository;

        public SeatController(IRepository<Seat> repository, IRepository<CityLookup> cityLookupRepository, IRepository<BuildingLookup> buildingRepository, IRepository<Facility> facilityRepository, IRepository<Allocation> allocationRepository)
        {
            _repository = repository;
            _cityLookupRepository = cityLookupRepository;
            _buildingRepository = buildingRepository;
            _facilityRepository = facilityRepository;
            _allocationRepository = allocationRepository;
        }

        [HttpGet]
        [Route("GetAllSeat")]
        public IActionResult GetAll() {
            var listOfSeats = _repository.GetAll();
            return Ok(listOfSeats);
        }

        [HttpGet]
        [Route("GetSeat")]
        public IActionResult Get(int id) {
            var seat = _repository.GetById(id);
            return Ok(seat);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(SeatDto seatDto)
        {

            // getting max of the id from seats
            var newSeatId = _repository.GetAll().Max(s => s.SeatId) + 1;

            var result = _facilityRepository.GetAll()
            .Where(f => f.FacilityId == seatDto.FacilityId) // Filter by FacilityId
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

                string newSeatName = cityAbbreviation + '-' + buildingAbbreviation + '-' + floors + '-' + facilityName + '-' + 'S' + newSeatId.ToString();

                _repository.Add(new Seat { SeatName = newSeatName, FacilityId = seatDto.FacilityId });
                return Ok();

            }
            else
            {
                // Facility with the specified ID was not found
                return NotFound("facility does not exist");
            }

            
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var deleteSeat = _repository.GetById(id);
            if (deleteSeat == null)
            {
                return NotFound();
            }
            _repository.Delete(deleteSeat.FacilityId);
            return Ok();
        }


        [HttpGet]
        [Route("FreeSeats")]
        public IActionResult GetFreeSeats() {
            var unallocatedSeats = _repository.GetAll()
                                    .Where(seat => !_allocationRepository.GetAll().Any(allocation =>
                                        allocation.AssetId == seat.SeatId && allocation.AssetLookupId == 2)).ToList();
            return Ok(unallocatedSeats);
                                    
        }

        [HttpGet]
        [Route("FreeSeatsByFacility")]
        public IActionResult GetFreeSeats(string facilityId)
        {
            int givenFacilityId = Convert.ToInt32(facilityId);
            var unallocatedSeats = _repository.GetAll()
                                    .Where(seat => !_allocationRepository.GetAll().Any(allocation =>
                                        allocation.AssetId == seat.SeatId && allocation.AssetLookupId == 2) && seat.FacilityId == givenFacilityId);

            return Ok(unallocatedSeats);
        }


    }
}
