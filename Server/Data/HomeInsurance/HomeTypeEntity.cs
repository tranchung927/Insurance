using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.HomeInsurance
{
    [Table("home_type")]
    public class HomeTypeEntity
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
