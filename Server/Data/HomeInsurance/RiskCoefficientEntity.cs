using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.HomeInsurance
{
    [Table("risk_coefficient")]
    public class RiskCoefficientEntity
    {
        // đây là khóa chính
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
