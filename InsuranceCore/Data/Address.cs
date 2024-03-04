using InsuranceCore.Data.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCore.Data
{
    public class Address : IPoco
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AddressId")]
        [Required] public City City { get; set; }

        [ForeignKey("AddressId")]
        [Required] public District District { get; set; }

        [Required] public string FullAddress { get; set; }

        [Required] public User User { get; set; }
    }
}
