using InsuranceCore.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCore.Data
{
    public class DeathRate: IPoco
    {
        [Key]
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
