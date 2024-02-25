using Server.Data.JoiningEntity;

namespace Server.Data.Contracts
{
    public interface IHasPostTag
    {
        public ICollection<PostTag> PostTags { get; set; }
    }
}
