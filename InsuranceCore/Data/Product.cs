using InsuranceCore.Data.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCore.Data
{
    public class Product: IPoco, IHasName
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Code { get; set; }

        [Range(0, 9)]
        public int Status { get; set; } = 1;

        [ForeignKey("ProductId")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
