using InsuranceCore.Data;

namespace InsuranceCore.Data.Contracts
{
    public interface IHasAuthor
    {
        public User Author { get; set; }
    }
}
