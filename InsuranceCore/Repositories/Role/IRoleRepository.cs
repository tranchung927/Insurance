using System.Security;
using InsuranceCore.Data.Permission;

namespace InsuranceCore.Repositories.Role
{
    public interface IRoleRepository : IRepository<Data.Role>
    {
       
        Task<IEnumerable<Data.Role>> GetRolesFromUser(int id);

        Task<bool> NameAlreadyExists(string name);

        Task AddPermissionAsync(int roleId, Permission permission);

        Task RemovePermissionAsync(int roleId, Permission permission);

        Task<IEnumerable<Permission>> GetPermissionsAsync(int roleId);
    }
}
