using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.VehicleInsurance
{
    [Table("vehicle_type")]
    public class VehicleTypeEntity
    {
        // đây là khóa chính
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }

        [Range(0, 9)]
        public int Status { get; set; } = 1;

    }
}
