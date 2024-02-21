using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.LifeInsurance
{
    [Table("death_rate")]
    public class DeathRateEntity
    {
        public int Id { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }

        [Range(0, 1)]
        public float Male { get; set; }

        [Range(0, 1)]
        public float Female { get; set; }

        [Range(0, 9)]
        public int Status { get; set; }
    }
}
