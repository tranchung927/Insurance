using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using InsuranceCore.Data.JoiningEntity;
using Microsoft.AspNetCore.Identity;
using InsuranceCore.Data.Contracts;

namespace InsuranceCore.Data
{
    public class Role: IdentityRole<int>, IPoco, IHasName, IHasUserRoles
    {

        [Required]
        [MaxLength(20)]
        public override string Name { get; set; }

        [ForeignKey("RoleId")]
        public virtual ICollection<UserRole> UserRoles { get; set; }

        [ForeignKey("RoleId")]
        public virtual ICollection<DefaultRoles> DefaultRoles { get; set; }
    }
}
