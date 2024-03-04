using InsuranceCore.Data.Contracts;
using InsuranceCore.Data.JoiningEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCore.Data
{
    public class City : IPoco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }

        [ForeignKey("CityId")]
        public virtual ICollection<District> Districts { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
