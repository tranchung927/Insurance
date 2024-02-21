using Server.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace Server.Repositories.Users.Interface
{
    public interface IUsers_Repo
    {
        public Task<IdentityResult> SignUp(SignUpModel model);
        public Task<string> SignIn(SignInModel model);
        public Task<string> GetIdByNameIdentifier(string NameIdentifier);
    }
}
