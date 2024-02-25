namespace Server.Repositories.User
{
    public interface IUserRepository : IRepository<Data.User>
    {
        Task<IEnumerable<Data.User>> GetUsersById(IEnumerable<int> ids);
        Task<IEnumerable<Data.User>> GetUsersFromRole(int id);

        Task<bool> UserNameAlreadyExists(string username);
        Task<bool> EmailAlreadyExists(string emailAddress);
        Task<bool> CheckPasswordAsync(Data.User user, string password);
        Task AddRoleToUser(Data.User user, Data.Role role);

        Task RemoveRoleToUser(Data.User user, Data.Role role);

        Task SetDefaultRolesToNewUsers(IEnumerable<Data.Role> roles);

        Task<IEnumerable<Data.Role>> GetDefaultRolesToNewUsers();
        Task<bool> ConfirmEmail(string token, Data.User user);
        Task ResetPassword(string token, Data.User user, string newPassword);
        Task<string> GenerateEmailConfirmationToken(Data.User user);
        Task<string> GeneratePasswordResetToken(Data.User user);
    }
}
