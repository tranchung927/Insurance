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

        // Đây là khóa ngoại của bảng
        [ForeignKey("VehicleType")] // Chỉ định tên thuộc tính khóa ngoại
        public int VehicleTypeId { get; set; }

        // Navigation property: dùng để truy cập các đối tượng liên quan đến nó
        public VehicleTypeEntity VehicleType { get; set; }
    }
}
