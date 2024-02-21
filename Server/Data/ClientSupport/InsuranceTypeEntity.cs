using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.ClientSupport
{
    [Table("insurance_type")]
    public class InsuranceTypeEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }

        [Range(0, 9)]
        public int Status { get; set; }
    }
}
