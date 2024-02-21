using System.ComponentModel.DataAnnotations;

namespace Server.Models.LifeInsurance
{
    public class DeathRateModel
    {
        public int Id { get; set; }

        public int Age { get; set; }

        public float Male { get; set; }

        public float Female { get; set; }

        public int Status { get; set; }
    }
}
