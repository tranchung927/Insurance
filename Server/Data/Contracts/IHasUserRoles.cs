using Server.Data.JoiningEntity;

namespace Server.Data.Contracts
{
    public interface IHasUserRoles
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
