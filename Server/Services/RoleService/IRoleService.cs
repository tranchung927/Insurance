using Server.Data.Permission;
using Server.Data;
using Server.Models.DTOs.Role;
using Server.Specifications.FilterSpecifications;
using Server.Specifications.SortSpecification;
using Server.Specifications;
using Server.Models.DTOs.Permission;

namespace Server.Services.RoleService
{
    public interface IRoleService
    {
        Task<IEnumerable<GetRoleDto>> GetAllRoles();

        public Task<IEnumerable<GetRoleDto>> GetRoles(FilterSpecification<Role>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Role>? sortSpecification = null);

        public Task<int> CountRolesWhere(FilterSpecification<Role>? filterSpecification = null);

        Task<GetRoleDto> GetRole(int id);

        Task<Role> GetRoleEntity(int id);

        Task<GetRoleDto> AddRole(AddRoleDto role);

        Task UpdateRole(UpdateRoleDto role);

        Task DeleteRole(int id);

        Task AddPermissionAsync(int roleId, Permission permission);

        Task RemovePermissionAsync(int roleId, Permission permission);

        Task<IEnumerable<PermissionDto>> GetPermissionsAsync(int roleId);
    }
}
