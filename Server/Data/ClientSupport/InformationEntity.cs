using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Server.Data.Users;

namespace Server.Data.ClientSupport
{
    [Table("information")]
    public class InformationEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Problem { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Comment { get; set; }

        [Range(0, 9)]
        public int Status { get; set; }

        // khóa phụ đến bảng User
        public string UsersId { get; set; }

        [ForeignKey("UsersId")]
        public UserEntity User { get; set; }

        // khóa phụ đến bảng InsuranceType
        public int InsuranceTypeId { get; set; }

        [ForeignKey("InsuranceTypeId")]
        public InsuranceTypeEntity InsuranceType { get; set; }
    }
}
