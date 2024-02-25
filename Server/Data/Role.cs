using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Server.Data.JoiningEntity;
using Microsoft.AspNetCore.Identity;
using Server.Data.Contracts;

namespace Server.Data
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
