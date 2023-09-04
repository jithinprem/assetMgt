using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DTO
{
    public class SeatDto
    {
        [Required]
        public int FacilityId { get; set; }

    }
}
