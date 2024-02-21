using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.LifeInsurance
{
    [Table("workplace")]
    public class WorkplaceEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Describe { get; set; }

        [Range(0, 1)]
        public float Factor { get; set; }

        [Range(0, 9)]
        public int Status { get; set; }
    }
}
