using InsuranceCore.Data;

namespace InsuranceCore.Data.Contracts
{
    public interface IHasPosts
    {
        public ICollection<Post> Posts { get; set; }
    }
}
