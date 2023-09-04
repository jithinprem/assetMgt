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
    public class RoomToAmenityMapController : ControllerBase
    {
        private readonly IRepository<RoomToAmenityMap> _repository;
        

        public RoomToAmenityMapController(IRepository<RoomToAmenityMap> repository)
        {
            _repository = repository;
       
        }


        [HttpPost]
        [Route("Add")]
        public IActionResult Add(RoomToAmenityDto roomAmenityDto)
        {
            var newRoomToAmenity = new RoomToAmenityMap { RoomId = roomAmenityDto.RoomId, AmenityId = roomAmenityDto.AmenityId };
            _repository.Add(newRoomToAmenity);
            return Ok();
            
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var deleteRoomToAmenity = _repository.GetById(id);
            if (deleteRoomToAmenity == null)
            {
                return NotFound();
            }
            _repository.Delete(deleteRoomToAmenity.RAMapId);
            return Ok();
        }
    }
}
