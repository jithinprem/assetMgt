using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Model
{
    public class Seat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SeatId { get; set; }
        public string SeatName { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        
    }
}
