using System.ComponentModel.DataAnnotations;

namespace Server.Models.LifeInsurance
{
    public class JobsRiskModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public int Status { get; set; }
    }
}
