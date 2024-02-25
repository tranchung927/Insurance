using Server.Data;
using Server.Models.DTOs.Account;
using Server.Models.DTOs.Role;
using Server.Models.DTOs.User;
using Server.Specifications.FilterSpecifications;
using Server.Specifications.SortSpecification;
using Server.Specifications;

namespace Server.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<GetAccountDto>> GetAllAccounts();

        public Task<IEnumerable<GetUserDto>> GetUsers(FilterSpecification<User>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<User>? sortSpecification = null);

        public Task<int> CountUsersWhere(FilterSpecification<User>? filterSpecification = null);

        Task<GetAccountDto> GetAccount(int id);

        Task<GetUserDto> GetUser(int id);

        Task<GetAccountDto> GetAccount(string userName);

        Task<User> GetUserEntity(int id);

        Task<GetAccountDto> AddAccount(AddAccountDto account);

        Task AddUserRole(UserRoleDto userRole);

        Task RemoveUserRole(UserRoleDto userRole);

        Task<bool> SignIn(AccountLoginDto accountLogin);

        Task UpdateAccount(UpdateAccountDto account);

        Task DeleteAccount(int id);

        Task<IEnumerable<GetUserDto>> GetUsersFromRole(int id);

        Task<IEnumerable<GetRoleDto>> GetDefaultRolesAssignedToNewUsers();

        Task SetDefaultRolesAssignedToNewUsers(List<int> roleIds);

        Task<bool> ConfirmEmail(string token, int userId);

        Task ResetPassword(string token, int userId, string newPassword);

        Task<bool> EmailIsConfirmed(int userId);

        Task<string> GenerateConfirmEmailToken(int userId);

        Task<string> GeneratePasswordResetToken(int userId);

        Task RevokeRefreshToken(int userId);
    }
}
