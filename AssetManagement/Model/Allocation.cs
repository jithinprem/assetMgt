using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Model
{
    public class Allocation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AllocationId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("AssetLookup")]
        public int AssetLookupId { get; set; }
        public int AssetId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual AssetLookup AssetLookup { get; set; }

    }
}
