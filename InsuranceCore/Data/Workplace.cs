using InsuranceCore.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCore.Data
{
    public class Workplace: IPoco
    {
        [Key]
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
