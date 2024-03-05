using InsuranceCore.Data.Permission;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.Role;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;
using InsuranceCore.Specifications;
using InsuranceCore.Models.DTOs.Permission;

namespace InsuranceCore.Services.RoleService
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
