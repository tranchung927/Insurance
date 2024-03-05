using InsuranceCore.Data.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCore.Data
{
    public class VehicleProperty: IPoco
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Property { get; set; }

        [Range(0, 9)]
        public int Value { get; set; }

        [Range(0, 9)]
        public int Status { get; set; } = 1;

        public int VehicleTypeId { get; set; }

        [ForeignKey("VehicleTypeId")]
        public VehicleType VehicleType { get; set; }
    }
}
