using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.LifeInsurance
{
    [Table("jobs_risk")]
    public class JobsRiskEntity
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }

        [Range(0, 2)]
        public float Value { get; set; }

        [Range(0, 9)]
        public int Status { get; set; }
    }
}
