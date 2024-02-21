using Server.Data.HomeInsurance;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.HomeInsurance
{
    public class HomeCoefficientModel
    {
        public int Id { get; set; }

        public int HomeTypeId { get; set; }

        public int SizeTypeId { get; set; }

        public float Coefficient { get; set; }

        public int Status { get; set; } = 1;
    }
}
