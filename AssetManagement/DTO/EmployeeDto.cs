using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.DTO
{
    public class EmployeeDto
    {
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
    }
}
