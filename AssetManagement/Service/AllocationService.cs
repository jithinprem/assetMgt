using AssetManagement.Data;
using AssetManagement.DTO;
using AssetManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Service
{
    public class AllocationService
    {
        private readonly IRepository<Allocation> _repository;

        public AllocationService(IRepository<Allocation> repository)
        {
            _repository = repository;
        }

        public bool IsEmployeeAlloted(AllocationDto allocationDto) {
            // Define the filter criteria to check if an allocation exists for the given EmployeeId
            Func<Allocation, bool> allocationFilter = allocation => allocation.EmployeeId == allocationDto.EmployeeId;

            // Use the GetEntitiesByFilter method to find allocations based on the filter criteria
            var allocationsForEmployee = _repository.GetEntitiesByFilter(allocationFilter);

            // Check if there are any allocations for the given EmployeeId
            bool employeeExistsInAllocations = allocationsForEmployee.Any();

            return employeeExistsInAllocations;

        }

        public bool IsAssetAllocated(AllocationDto allocationDto) {
            // Define the filter criteria to check if an allocation exists for the given EmployeeId
            Func<Allocation, bool> allocationFilter = allocation => allocation.AssetId == allocationDto.AssetId && allocation.AssetLookupId == allocationDto.AssetLookupId;

            // Use the GetEntitiesByFilter method to find allocations based on the filter criteria
            var allAssetAllocated = _repository.GetEntitiesByFilter(allocationFilter);

            // Check if there are any allocations for the given EmployeeId
            bool isAssetAllocated = allAssetAllocated.Any();

            return isAssetAllocated;
        }
    }
}
