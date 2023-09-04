using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.DTO
{
    public class AllocationDto
    {
        public int EmployeeId { get; set; }
        public int AssetLookupId { get; set; }
        public int AssetId { get; set; } // refers to the id of cabin or seat
    }
}
