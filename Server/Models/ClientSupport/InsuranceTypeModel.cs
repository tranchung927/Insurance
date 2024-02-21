
using System.ComponentModel.DataAnnotations;

namespace Server.Models.ClientSupport
{
    public class InsuranceTypeModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }

        [Range(0, 9)]
        public int Status { get; set; }
    }
}
