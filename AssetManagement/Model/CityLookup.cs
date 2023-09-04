using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Model
{
    public class CityLookup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityAbbreviation { get; set; }

    }
}
