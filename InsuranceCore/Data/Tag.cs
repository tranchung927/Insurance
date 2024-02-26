using InsuranceCore.Data.JoiningEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using InsuranceCore.Data.Contracts;

namespace InsuranceCore.Data
{
    public class Tag: IPoco, IHasName, IHasPostTag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("TagId")]
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
