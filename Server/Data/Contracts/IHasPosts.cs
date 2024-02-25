using Server.Data;

namespace Server.Data.Contracts
{
    public interface IHasPosts
    {
        public ICollection<Post> Posts { get; set; }
    }
}
