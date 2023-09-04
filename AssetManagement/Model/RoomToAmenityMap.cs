using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Model
{
    public class RoomToAmenityMap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RAMapId { get; set; }
        [ForeignKey("MeetingRoom")]
        public int RoomId { get; set; }
        [ForeignKey("Amenity")]
        public int AmenityId { get; set; }

        public virtual MeetingRoom MeetingRoom { get; set; }
        public virtual Amenity Amenity { get; set; }
    }
}
