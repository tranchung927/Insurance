using Server.Data.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.ClientSupport
{
    [Table("ticket")]
    public class TicketEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Problem { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Comment { get; set; }

        [Range(0, 9)]
        public int Status { get; set; }

        // khóa phụ đến bảng User (của nhân viên nhận hỗ trợ)
        // sẽ có một form danh sách toàn bộ các vấn đề và nhân viên sau khi đăng nhập vào web sẽ xem danh sách và bấm vào chọn hỗ trợ
        // khi nhân viên chọn hỗ trợ vấn đề nào đó sẽ đẩy id của nhân viên đó vào (để xem KPI của nhân viên hỗ trợ)
        public string UsersId { get; set; }

        [ForeignKey("UsersId")]
        public UserEntity User { get; set; }

        // khóa phụ đến bảng InsuranceType
        public int InsuranceTypeId { get; set; }

        [ForeignKey("InsuranceTypeId")]
        public InsuranceTypeEntity InsuranceType { get; set; }
    }
}
