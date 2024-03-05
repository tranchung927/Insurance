using Microsoft.AspNetCore.Identity;
using InsuranceCore.Data.Contracts;
using InsuranceCore.Data.JoiningEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCore.Data
{
    public class User : IdentityUser<int>, IPoco, IHasUserRoles, IHasUserName, IHasEmail, IHasRegisteredAt, IHasLastLogin, IHasPosts
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public override string UserName { get; set; }

        public string? ProfilePictureUrl { get; set; }

        [Required]
        [MaxLength(320)]
        public override string Email { get; set; }

        [Required]
        [NotMapped]
        public string Password { get; set; }

        [MaxLength(1000)]
        public string? UserDescription { get; set; }

        [Required]
        public DateTimeOffset RegisteredAt { get; set; }

        [Required]
        public  DateTimeOffset LastLogin { get; set; }

        public string? RefreshToken { get; set; }

        public DateTimeOffset? RefreshTokenExpiration { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<UserRole> UserRoles { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
