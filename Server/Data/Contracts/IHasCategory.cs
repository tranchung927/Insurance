using Server.Data;

namespace Server.Data.Contracts
{
    public interface IHasCategory
    {
        public Category Category { get; set; }
    }
}
