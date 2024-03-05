using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using InsuranceCore.Data.Contracts;

namespace InsuranceCore.Data
{
    public class HouseCoefficient: IPoco
    {
        [Key]
        public int Id { get; set; }

        // Đây là khóa ngoại của bảng
        [ForeignKey("HouseTypeId")]
        public int HouseTypeId { get; set; }

        public HouseType HouseType { get; set; }

        // Đây là khóa ngoại của bảng
        [ForeignKey("HouseSizeId")]
        public int HouseSizeId { get; set; }

        public HouseSize HouseSize { get; set; }

        [Range(0, 2)]
        public float Coefficient { get; set; }

        [Range(0, 9)]
        public int Status { get; set; } = 1;
    }
}
