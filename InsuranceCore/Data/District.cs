using InsuranceCore.Data.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCore.Data
{
    public class District : IPoco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DistrictName { get; set; }

        [Required] public City City { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
