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
    public class AllocationController : ControllerBase
    {
        private readonly IRepository<Allocation> _repository;
        private readonly IRepository<Cabin> _cabinRepository;
        private readonly IRepository<Seat> _seatRepository;

        public AllocationController(IRepository<Allocation> repository, IRepository<Cabin> cabinRepository, IRepository<Seat> seatRepository)
        {
            _repository = repository;
            _cabinRepository = cabinRepository;
            _seatRepository = seatRepository;

        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(AllocationDto allocationDto)
        {
            AllocationService allocationService = new AllocationService(_repository);
            bool employeeExistsInAllocations = allocationService.IsEmployeeAlloted(allocationDto);
            bool assetAllocated = allocationService.IsAssetAllocated(allocationDto);


            var cabinWithAssetId = _cabinRepository.GetById(allocationDto.AssetId);
            bool cabinExists = cabinWithAssetId != null;

            var seatWithAssetId = _seatRepository.GetById(allocationDto.AssetId);
            bool seatExist = seatWithAssetId != null;

            if (employeeExistsInAllocations)
            {
                return BadRequest("Employee already alloted");
            } else if(assetAllocated){
                return BadRequest("Asset Already Allocated");
            }
            else
            {
                if ((allocationDto.AssetLookupId == 1 && cabinExists) || (allocationDto.AssetLookupId == 2 && seatExist))
                {
                    var newAllocation = new Allocation { EmployeeId = allocationDto.EmployeeId, AssetLookupId = allocationDto.AssetLookupId, AssetId = allocationDto.AssetId };
                    _repository.Add(newAllocation);
                    return Ok();

                }
                else {
                    return BadRequest("Asset dosen't exist");
                }

            }
        }

        

    }

}
