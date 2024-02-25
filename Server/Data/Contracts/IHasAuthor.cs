using Server.Data;

namespace Server.Data.Contracts
{
    public interface IHasAuthor
    {
        public User Author { get; set; }
    }
}
