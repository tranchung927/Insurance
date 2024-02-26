using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using InsuranceCore.Data.Contracts;

namespace InsuranceCore.Data
{
    public class Category : IPoco, IHasName, IHasPosts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
