using AssetManagement.Data;
using AssetManagement.DTO;
using AssetManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;
        private readonly IRepository<Allocation> _allocationRepository;
        
        public EmployeeController(IRepository<Employee> repository, IRepository<Allocation> allocationRepository) {
            _repository = repository;
            
            _allocationRepository = allocationRepository;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(List<EmployeeDto> employees)
        {
            try {
                foreach (var employee in employees)
                {
                    _repository.Add(new Employee { EmployeeName = employee.EmployeeName, DepartmentId = employee.DepartmentId });
                }
                return Ok();
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
            
        }

        [HttpGet]
        [Route("GetbyName")]
        public IActionResult GetByName(string name) {
            var employee = _repository.GetAll()
                            .Where(e => e.EmployeeName == name);

            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetbySeat")]
        public IActionResult GetBySeat(string assetIdToFindSt, string assetTypeSt) {

            int assetIdToFind = Convert.ToInt32(assetIdToFindSt);
            int assetType = Convert.ToInt32(assetTypeSt);

            var employeeWithAsset = _repository.GetAll()
                                    .Join(
                                        _allocationRepository.GetAll(),
                                        employee => employee.EmployeeId,
                                        allocation => allocation.EmployeeId,
                                        (employee, allocation) => new
                                        {
                                            Employee = employee,
                                            Allocation = allocation
                                        }
                                    )
                                    .Where(joinResult => joinResult.Allocation.AssetLookupId == assetType && joinResult.Allocation.AssetId == assetIdToFind)
                                    .Select(joinResult => joinResult.Employee);
            return Ok(employeeWithAsset);
                                    
        }


        /* ---------------- to complete ----------------------------*/

        //[HttpGet]
        //[Route("GetbyFacility")]
        //public IActionResult GetByFacility(int id) {
        //    var employeesInFacility = _context.Employees
        //                                .Join(
        //                                    _context.Allocations,
        //                                    employee => employee.EmployeeId,
        //                                    allocation => allocation.EmployeeId,
        //                                    (employee, allocation) => new
        //                                    {
        //                                        Employee = employee,
        //                                        Allocation = allocation
        //                                    }
        //                                )
        //                                .Join(
        //                                    _context.Cabins,
        //                                    joinResult => new { joinResult.Allocation.AssetLookupId, joinResult.Allocation.CabinId },
        //                                    cabin => new { AssetLookupId = 1, CabinId = cabin.CabinId },
        //                                    (joinResult, cabin) => new
        //                                    {
        //                                        joinResult.Employee,
        //                                        joinResult.Allocation,
        //                                        Cabin = cabin
        //                                    }
        //                                );
        //}

    }
}
