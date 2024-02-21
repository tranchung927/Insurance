using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.HomeInsurance
{
    [Table("home_coefficient")]
    public class HomeCoefficientEntity
    {
        [Key]
        public int Id { get; set; }

        // Đây là khóa ngoại của bảng
        [ForeignKey("HomeType")] 
        public int HomeTypeId { get; set; }

        public HomeTypeEntity HomeType { get; set; }

        // Đây là khóa ngoại của bảng
        [ForeignKey("SizeType")]
        public int SizeTypeId { get; set; }

        public SizeTypeEntity SizeType { get; set; }

        [Range(0, 2)]
        public float Coefficient { get; set; }

        [Range(0, 9)]
        public int Status { get; set; } = 1;
    }
}
