using InsuranceCore.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCore.Data
{
    public class HouseRiskCoefficient: IPoco
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }

        [Range(0, 2)]
        public float Value { get; set; } = 1;

        [Range(0, 9)]
        public int Status { get; set; } = 1;
    }
}
