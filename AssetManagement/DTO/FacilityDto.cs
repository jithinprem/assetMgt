using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTO
{
    public class FacilityDto
    {
        [Required]
        public string CityName { get; set; }
        [Required]
        public string BuildingName { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public string FacilityName { get; set; }
    }
}
