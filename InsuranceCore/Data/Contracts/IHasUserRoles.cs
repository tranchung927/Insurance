using InsuranceCore.Data.JoiningEntity;

namespace InsuranceCore.Data.Contracts
{
    public interface IHasUserRoles
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
