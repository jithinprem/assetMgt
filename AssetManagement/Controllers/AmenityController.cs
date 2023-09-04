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
    public class AmenityController : ControllerBase
    {
        private readonly IRepository<Amenity> _repository;


        public AmenityController(IRepository<Amenity> repository, SeatManagementDbContext context)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(AmenityDto amenityDto) {
           
            AmenityService amenityService = new AmenityService(_repository);
            try {
                amenityService.AddAmenity(amenityDto);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest($"Adding Aminity Failed");
            }
            
        }
    }
}
