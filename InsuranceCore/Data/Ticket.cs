using InsuranceCore.Data.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCore.Data
{
    public class Ticket : IPoco, IHasName
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Problem { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Comment { get; set; }

        [Range(0, 9)]
        public int Status { get; set; }

        public User? User { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}
