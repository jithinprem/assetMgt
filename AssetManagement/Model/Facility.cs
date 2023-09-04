using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Model
{
    public class Facility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public int CityId { get; set; }
        [ForeignKey("BuildingId")]
        public int BuildingId { get; set; }
        public int Floor { get; set; }

        [ForeignKey("BuildingId")]
        public virtual BuildingLookup BuildingLookup { get; set; }
    }
}
