using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.VehicleInsurance
{
    [Table("vehicle_property")]
    public class VehiclePropertyEntity
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Property { get; set; }

        [Range(0, 9)]
        public int Value { get; set; }

        [Range(0, 9)]
        public int Status { get; set; } = 1;

        
        public int VehicleTypeId { get; set; }

        [ForeignKey("VehicleTypeId")] 
        public VehicleTypeEntity VehicleType { get; set; }
    }
}
