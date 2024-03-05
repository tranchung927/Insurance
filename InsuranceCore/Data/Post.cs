using InsuranceCore.Data.Contracts;
using InsuranceCore.Data.JoiningEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCore.Data
{
    public class Post : IPoco, IHasContent, IHasName, IHasAuthor, IHasCategory, IHasCreationDate, IHasModificationDate, IHasPostTag
    {
        [Key]
        public int Id { get; set; }

        [Required] public string Content { get; set; }

        [Required][MaxLength(250)] public string Name { get; set; }

        [Required] public User Author { get; set; }

        [Required] public Category Category { get; set; }

        [Required]
        public DateTimeOffset PublishedAt { get; set; }

        public DateTimeOffset? ModifiedAt { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
