using System.ComponentModel.DataAnnotations;

namespace Server.Models.HomeInsurance
{
    public class RiskCoefficientModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Value { get; set; } = 1;

        public int Status { get; set; } = 1;
    }
}
