using InsuranceCore.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCore.Data
{
    public class Product: IPoco
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Name { get; set; }

    }
}
