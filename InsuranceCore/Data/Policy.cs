using InsuranceCore.Data.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCore.Data
{
    public class Policy : IPoco
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Code { get; set; }
        [Required] public Product Product { get; set; }
        [Required] public User User { get; set; }
    }
}
