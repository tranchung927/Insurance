using System.ComponentModel.DataAnnotations;
using System.Data;

namespace InsuranceCore.Data
{
    public class DefaultRoles
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
