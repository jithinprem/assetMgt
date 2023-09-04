using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Model
{
    public class MeetingRoom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RoomID { get; set; }
        public int Chairs { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public string RoomName { get; set; }

        public virtual Facility Facility { get; set; }
    }
}
