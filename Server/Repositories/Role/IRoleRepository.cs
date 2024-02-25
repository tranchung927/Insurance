using System.Security;
using Server.Data.Permission;

namespace Server.Repositories.Role
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
