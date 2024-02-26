using InsuranceCore.Data.JoiningEntity;

namespace InsuranceCore.Data.Contracts
{
    public interface IHasPostTag
    {
        public ICollection<PostTag> PostTags { get; set; }
    }
}
