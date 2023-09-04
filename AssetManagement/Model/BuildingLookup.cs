using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Model
{
    public class BuildingLookup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string BuildingAbbreviation { get; set; }

    }
}
