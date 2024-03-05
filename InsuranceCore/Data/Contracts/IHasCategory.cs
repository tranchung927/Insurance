using InsuranceCore.Data;

namespace InsuranceCore.Data.Contracts
{
    public interface IHasCategory
    {
        public Category Category { get; set; }
    }
}
